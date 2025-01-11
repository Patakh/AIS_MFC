using AisLogistics.App.Models;
using AisLogistics.DataLayer.Entities.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AisLogistics.App.Service
{
    //TODO брать данные из employeeManage
    public static class AuditService
    {
        public static DbContext AddWithAudit<T>(this DbContext context, T model, EmployeeInfo employeeInfo)
        {
            ArgumentNullException.ThrowIfNull(model);
            ArgumentNullException.ThrowIfNull(context);
            ArgumentNullException.ThrowIfNull(employeeInfo);

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<T, DServicesAudit>(); });
            IMapper mapper = new Mapper(config);
            var entity = context.Add(model);
            var audit = mapper.Map<T, DServicesAudit>(model,
                q => q.AfterMap((arg1, servicesAudit) =>
                {
                    servicesAudit.Changed = AuditTypeRepository.GetJson(arg1.GetType(), entity.State);
                    servicesAudit.DateAdd = DateTime.Now;
                    servicesAudit.SEmployeesId = employeeInfo.Id;
                    servicesAudit.SEmployeesJobPositionId = employeeInfo.Job.Id;
                    servicesAudit.SOfficesId = employeeInfo.Office.Id;
                }));

            context.Add(audit);
            return context;
        }


        public static DbContext UpdateWithAudit<T>(this DbContext context, T model, EmployeeInfo employeeInfo)
        {
            ArgumentNullException.ThrowIfNull(model);
            ArgumentNullException.ThrowIfNull(context);
            ArgumentNullException.ThrowIfNull(employeeInfo);

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<T, DServicesAudit>(); });
            IMapper mapper = new Mapper(config);
            var entity = context.Update(model);
            var audit = mapper.Map<T, DServicesAudit>(model,
                q => q.AfterMap((arg1, servicesAudit) =>
                {
                    servicesAudit.Id = Guid.NewGuid();
                    servicesAudit.Changed = AuditTypeRepository.GetJson(arg1.GetType(), entity.State);
                    servicesAudit.DateAdd = DateTime.Now;
                    servicesAudit.SEmployeesId = employeeInfo.Id;
                    servicesAudit.SEmployeesJobPositionId = employeeInfo.Job.Id;
                    servicesAudit.SOfficesId = employeeInfo.Office.Id;
                }));
            //ChangeTracker.Entries<DServicesAudit>();

            context.Add(audit);
            return context;
        }
    }

    public static class AuditTypeRepository
    {
        private static readonly Dictionary<Type, ChangedAuditBuilder> Dictionary = new()
        {
            {
                typeof(DServicesCommentt),
                new ChangedAuditBuilder()
                    .SetAuditType(ChangedAuditType.Comment)
                    .SetAddDescription(ChangedAuditDescription.AddComment)
            },
            {
                typeof(DServicesCustomer),
                new ChangedAuditBuilder()
                    .SetAuditType(ChangedAuditType.Customer)
                    .SetAddDescription(ChangedAuditDescription.AddCustomer)
                    .SetEditDescription(ChangedAuditDescription.EditCustomer)
            },
            {
                typeof(DServicesCustomersLegal),
                new ChangedAuditBuilder()
                    .SetAuditType(ChangedAuditType.Customer)
                    .SetAddDescription(ChangedAuditDescription.AddCustomer)
                    .SetEditDescription(ChangedAuditDescription.EditCustomer)
            }
        };

        public static ChangedAudit Get(Type type, EntityState entityState)
        {
            return Dictionary.TryGetValue(type, out var data)
                ? data.Get(entityState)
                : new ChangedAuditBuilder(entityState).GetDefault();
        }

        public static string GetJson(Type type, EntityState entityState)
        {
            return JsonConvert.SerializeObject(Get(type, entityState));
        }
    }

    public class ChangedAudit
    {
        public ChangedAuditType AuditType { get; set; }
        public string? Description { get; set; }
    }

    public class ChangedAuditBuilder
    {
        public ChangedAuditBuilder()
        {
            EntityState = EntityState.Detached;
            Audit = new ChangedAudit();
        }
        public ChangedAuditBuilder(EntityState entityState)
        {
            EntityState = entityState;
            Audit = new ChangedAudit();
        }

        private EntityState EntityState { get; set; }
        private string? AddDescription { get; set; }
        private string? EditDescription { get; set; }

        private ChangedAudit Audit { get; }

        public ChangedAuditBuilder SetEntityState(EntityState entityState)
        {
            EntityState = entityState;
            return this;
        }
        public ChangedAuditBuilder SetAuditType(ChangedAuditType auditType)
        {
            Audit.AuditType = auditType;
            return this;
        }
        public ChangedAuditBuilder SetAddDescription(string description)
        {
            AddDescription = description;
            return this;
        }
        public ChangedAuditBuilder SetEditDescription(string description)
        {
            EditDescription = description;
            return this;
        }

        public ChangedAudit Get(EntityState entityState)
        {
            SetEntityState(entityState);
            return Get();
        }
        public ChangedAudit Get()
        {
            Audit.Description = EntityState switch
            {
                EntityState.Added => AddDescription,
                EntityState.Modified => EditDescription,
                _ => ""
            };
            return this.Audit;
        }

        public ChangedAudit GetDefault()
        {
            Audit.AuditType = ChangedAuditType.Default;
            Audit.Description = EntityState switch
            {
                EntityState.Added => ChangedAuditDescription.AddDefault,
                EntityState.Modified => ChangedAuditDescription.EditDefault,
                _ => ""
            };
            return this.Audit;
        }
    }

    public static class ChangedAuditDescription
    {
        private const string Add = "Добавил(а)";
        private const string Edit = "Изменил(а)";
        private const string Remove = "Удалил(а)";

        public const string AddComment = $"{Add} комментарий.";
        public const string AddCustomer = $"{Add} заявителя.";
        public const string AddFile = $"{Add} документ.";
        public const string AddStage = $"{Add} этап.";
        public const string AddSmev = $"{Add} СМЭВ запрос.";
        public const string AddDefault = $"{Add} новую запись.";

        public const string EditCustomer = $"{Edit} данные заявителя.";
        public const string EditDefault = $"{Edit} существующую запись.";
    }

    public enum ChangedAuditType
    {
        Comment,
        Customer,
        File,
        Stage,
        Smev,
        Default
    }
}
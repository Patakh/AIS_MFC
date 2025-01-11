using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.References;
using AisLogistics.App.Models.DTO.Template;
using AisLogistics.DataLayer.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace AisLogistics.App.Service
{
    // Справочники - Misc

    public partial class ReferencesService : IReferencesService
    {
        #region Справочники - Misc

        /// <summary>
        /// Поучить список всех офисов
        /// </summary>
        public async Task<List<OfficeDto>> GetAllOfficesAsync()
        {
            return await _context.SOffices
                .AsNoTracking()
                .Where(x => !x.IsRemove)
                .OrderBy(x => x.OfficeName)
                .Select(x => new OfficeDto()
                {
                    Id = x.Id,
                    OfficeName = x.OfficeName
                }).ToListAsync();
        }

        // <summary>
        /// Поучить список всех офисов
        /// </summary>
        public async Task<List<OfficeDto>> GetAllOfficesTypeAsync(int? type)
        {
            var office = await _context.SServices
                .AsNoTracking()
                .Where(x => !x.IsRemove && (!type.HasValue || x.SServicesTypeId == type))
                .Select(x => new OfficeDto()
                {
                    Id = x.SOffice.Id,
                    OfficeName = x.SOffice.OfficeName
                }).ToListAsync();

            office = office.GroupBy(g => g.Id)
                .Select(s => new OfficeDto() { Id = s.Key, OfficeName = s.First().OfficeName })
                .OrderBy(o => o.OfficeName).ToList();

            return office;
        }

        // <summary>
        /// Поучить список всех офисов
        /// </summary>
        public async Task<OfficeDto?> GetOfficeForQueueAsync(int queueId)
        {
            return await _context.SOffices
                .AsNoTracking()
                .Where(x => !x.IsRemove && x.QueueId == queueId.ToString())
                .Select(x => new OfficeDto()
                {
                    Id = x.Id,
                    OfficeName = x.OfficeName
                }).FirstOrDefaultAsync();
        }
        public async Task<List<OfficeQueueDto>> GetOfficesQueueAsync()
        {
            return await _context.SOffices.Where(w => w.QueueId != null).Select(s => new OfficeQueueDto
            {
                Id = s.QueueId,
                OfficeName = s.OfficeName
            }).ToListAsync();
        }


        // <summary>
        /// Поучить список всех офисов
        /// </summary>
        public async Task<List<EmployeeInfo>> GetEmployeesForQueueAsync(Guid officeId)
        {
            var date = DateTime.Today;

            return await _context.SEmployees.Where(w => w.AspNetUser.AspNetUserClaims.Any(a => a.ClaimType == "OfficeId" &&
                                                                        a.ClaimValue == officeId.ToString()) &&
                                                            w.SEmployeesOfficesJoins.Any(a => a.DateStart <= date &&
                                                                        (a.DateStop == null || a.DateStop >= date) && a.SEmployeesJobPositionId == 1 && !a.IsRemove))
                                             .Select(s => new EmployeeInfo { Id = (Guid)s.AspNetUserId, Name = s.AspNetUser.UserName }).ToListAsync();
        }

        // <summary>
        /// Поучить список всех офисов
        /// </summary>
        public async Task<List<OfficeDto>> GetAllOfficesTypeMfcAsync()
        {
            return await _context.SOffices
                .AsNoTracking()
               .Where(x => !x.IsRemove && x.SOfficesTypeId == (int)OfficeType.Mfc)
                .OrderBy(x => x.OfficeName)
                .Select(x => new OfficeDto()
                {
                    Id = x.Id,
                    OfficeName = x.OfficeName
                }).ToListAsync();
        }



        // <summary>
        /// Поучить список всех офисов и тоспов
        /// </summary>
        public async Task<List<OfficeDto>> GetAllOfficesTypeMfcAndTospAsync()
        {
            return await _context.SOffices
               .AsNoTracking()
               .Where(x => !x.IsRemove && (x.SOfficesTypeId == (int)OfficeType.Mfc || x.SOfficesTypeId == (int)OfficeType.Tosp))
               .OrderBy(x => x.SOfficesTypeId)
               .ThenBy(x => x.OfficeName)
               .Select(x => new OfficeDto()
               {
                   Id = x.Id,
                   OfficeName = x.OfficeName
               }).ToListAsync();
        }

        // <summary>
        /// Поучить список всех офисов и тоспов
        /// </summary>
        public async Task<List<OfficeDto>?> GetAuthorizationOfficesAsync(Guid aspNetUserIdid)
        {
            try
            {
                var date = DateTime.Today;
                return await _context.SOfficesAuthorizations
                   .AsNoTracking()
                   .Where(x => !x.IsRemove && x.SEmployees.AspNetUserId == aspNetUserIdid && x.DateStart.Date <= date.Date && (x.DateStop == null || x.DateStop.Value.Date >= date.Date))
                   .OrderBy(x => x.SOffices.OfficeName)
                   .Select(x => new OfficeDto()
                   {
                       Id = x.SOfficesId,
                       OfficeName = x.SOffices.OfficeName
                   }).ToListAsync();
            }
            catch(Exception ex)
            {
                return null;
            }
        }


        public async Task<List<OfficeDto>> GetAllOfficesTypeMfcAndTospAsync(List<Guid> id)
        {
            return await _context.SOffices
               .AsNoTracking()
               .Where(x => !x.IsRemove && (x.SOfficesTypeId == (int)OfficeType.Mfc || x.SOfficesTypeId == (int)OfficeType.Tosp) && id.Any(a => a == x.Id))
               .OrderBy(x => x.SOfficesTypeId)
               .ThenBy(x => x.OfficeName)
               .Select(x => new OfficeDto()
               {
                   Id = x.Id,
                   OfficeName = x.OfficeName
               }).ToListAsync();
        }


        /// <summary>
        /// Поставщики услуги
        /// </summary>
        /// <param name="serviceId">id услуги</param>
        /// <returns></returns>
        public async Task<List<OfficeDto>> GetOfficesProvidersAll()
        {
            return await _context.SOffices
                .AsNoTracking()
                .Where(w => !w.IsRemove && w.SOfficesTypeId != (int)OfficeType.Mfc && w.SOfficesTypeId != (int)OfficeType.Tosp)
                .OrderBy(x => x.OfficeName)
                .Select(s => new OfficeDto
                {
                    Id = s.Id,
                    OfficeName = s.OfficeName
                })
                .ToListAsync();
        }

        /// <summary>
        /// Поставщики услуги
        /// </summary>
        /// <param name="serviceId">id услуги</param>
        /// <returns></returns>
        public async Task<List<OfficeDto>> GetOfficesProvidersAll(List<Guid> id)
        {
            return await _context.SOffices
                .AsNoTracking()
                .Where(w => !w.IsRemove && w.SOfficesTypeId != (int)OfficeType.Mfc && w.SOfficesTypeId != (int)OfficeType.Tosp && id.Any(a => a == w.Id))
                .OrderBy(x => x.OfficeName)
                .Select(s => new OfficeDto
                {
                    Id = s.Id,
                    OfficeName = s.OfficeName
                })
                .ToListAsync();
        }

        /// <summary>
        /// Получить список всех должностей
        /// </summary>
        public async Task<List<EmployeesJobDto>> GetAllJobsAsync()
        {
            var jobs = _context.SEmployeesJobPositions
                .AsNoTracking()
                .Where(x => !x.IsRemove)
                .OrderBy(x => x.JobPositionName);

            return await jobs.Select(x => new EmployeesJobDto()
            {
                Id = x.Id,
                JobPositionName = x.JobPositionName
            }).ToListAsync();
        }

        /// <summary>
        /// Получить все запросы СМЭВ
        /// </summary>
        public async Task<List<ServiceSmevRequestDto>> GetAllSmevRequestsAsync()
        {
            var result = _context.SSmevRequests
                .AsNoTracking()
                .Where(x => (bool)x.IsRequestActive);

            return await result.Select(x => new ServiceSmevRequestDto()
            {
                Id = x.Id,
                RequestName = x.RequestName
            }).ToListAsync();
        }

        /// <summary>
        /// Получить все запросы СМЭВ
        /// </summary>
        /// <param name="searchPredicate">Условие поиска</param>
        public List<ServiceSmevRequestDto> GetAllSmevRequests(Func<SSmevRequest, bool> searchPredicate)
        {
            var result = _context.SSmevRequests
                .AsNoTracking()
                .Where(searchPredicate);

            return result.Select(x => new ServiceSmevRequestDto()
            {
                Id = x.Id,
                RequestName = x.RequestName
            }).ToList();
        }

        /// <summary>
        /// Все типы тарифов услуг
        /// </summary>
        public async Task<List<ServiceTariffTypeDto>> GetAllServiceTariffTypesAsync()
        {
            return await _context.SServicesTariffTypes
                .AsNoTracking()
                .Select(x => new ServiceTariffTypeDto()
                {
                    Id = x.Id,
                    TariffTypeName = x.TariffTypeName
                }).ToListAsync();
        }

        /// <summary>
        /// Все типы дней
        /// </summary>
        public async Task<Dictionary<string, string>> GetAllServiceWeekTypesAsync()
        {
            return await _context.SServicesWeeks
                .AsNoTracking()
                .ToDictionaryAsync(x => x.Id.ToString(), x => x.TypeName);
        }

        /// <summary>
        /// Все способы обращений
        /// </summary>
        public async Task<List<WayGetDto>> GetAllServiceWaysGetAsync()
        {
            return await _context.SServicesWayGets
                .AsNoTracking()
                .Select(x => new WayGetDto
                {
                    Id = x.Id,
                    NameWay = x.NameWay
                }).ToListAsync();
        }

        /// <summary>
        /// Все способы оценки
        /// </summary>
        public async Task<List<QualityTypeDto>> GetAllQualityTypesAsync()
        {
            return await _context.SServicesTypeQualities
                .AsNoTracking()
                .Select(x => new QualityTypeDto
                {
                    Id = x.Id,
                    TypeName = x.TypeName
                }).ToListAsync();
        }

        /// <summary>
        /// Все статусы сотрудника
        /// </summary>
        public async Task<Dictionary<string, string>> GetAllEmployeeStatusesAsync()
        {
            return await _context.SEmployeesStatuses
                .AsNoTracking()
                .ToDictionaryAsync(k => k.Id.ToString(), v => v.StatusName);
        }

        /// <summary>
        /// Все роли исполнителя
        /// </summary>
        public async Task<List<RoleExecutorDto>> GetAllRolesExecutorAsync()
        {
            return await _context.SRolesExecutors
                .AsNoTracking()
                .Where(x => !x.IsRemove)
                .Select(x => new RoleExecutorDto()
                {
                    Id = x.Id,
                    RoleName = x.RoleName,
                    Description = x.Description
                })
                .OrderBy(x => x.RoleName)
                .ToListAsync();
        }


        public async Task<List<SelectListDto<string>>> GetTerminalsByOffice(Guid? officeId)
        {
            try
            {
                return await _context.SOfficesAcquirings
                .AsNoTracking()
                .Where(x => x.SOfficesId == officeId)
                .Select(s => new SelectListDto<string>(s.IpAddress, s.AcquiringName))
                .ToListAsync();
            }
            catch (Exception ex)
            {
                return new List<SelectListDto<string>>();
            }
        }

        public async Task<List<SelectListDto<Guid>>> GetRecipientPaymentByProviders(Guid providerId, Guid? officeId)
        {
            try
            {
                return await _context.SRecipientPayments
                .AsNoTracking()
                .Where(x => x.SOfficesId == providerId && x.SOfficesIdMfc == officeId)
                .Select(s => new SelectListDto<Guid>(s.Id, s.OfficeBeneficiaryName))
                .ToListAsync();
            }
            catch (Exception ex)
            {
                return new List<SelectListDto<Guid>>();
            }
        }


        ///// <summary>
        ///// Все стадии услуг
        ///// </summary>
        //public async Task<List<ServicesRoutesStageDto>> GetAllServiceStagesAsync()
        //{
        //    return await _context.SServicesRoutesStages
        //        .AsNoTracking()
        //        .Where(x => !x.IsRemove)
        //        .Include(i => i.SRoutesStage)
        //        .Select(x => new ServicesRoutesStageDto()
        //        {
        //            Id = x.Id,
        //            SServicesId = x.SServicesId,
        //            ParentId = x.ParentId,
        //            StageName = x.SRoutesStage.StageName
        //        })
        //        .OrderBy(x => x.Id)
        //        .ToListAsync();
        //}

        #endregion
    }
}

using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Процедуры к услуге.
    /// </summary>
    public partial class SServicesProcedure
    {
        public SServicesProcedure()
        {
            DServices = new HashSet<DService>();
            SServicesCustomerTariffs = new HashSet<SServicesCustomerTariff>();
            SServicesDocuments = new HashSet<SServicesDocument>();
            SServicesDocumentsResults = new HashSet<SServicesDocumentsResult>();
            SServicesFiles = new HashSet<SServicesFile>();
            SServicesForms = new HashSet<SServicesForm>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Услуга
        /// </summary>
        public Guid SServicesId { get; set; }
        /// <summary>
        /// Наименование процедуры
        /// </summary>
        public string ProcedureName { get; set; }
        /// <summary>
        /// Сотрудник
        /// </summary>
        public string EmployeesFioAdd { get; set; }
        /// <summary>
        /// Дата и время добавления
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Признак удаления
        /// </summary>
        public bool IsRemove { get; set; }
        /// <summary>
        /// Активность
        /// </summary>
        public bool ProcedureActive { get; set; }
        /// <summary>
        /// Путь к доп форме
        /// </summary>
        public string ExtraFormPath { get; set; }
        /// <summary>
        /// Индетификатор Цели ФРГУ
        /// </summary>
        public string FrguTargetId { get; set; }
        /// <summary>
        /// Отправлять в ИС МДМ или нет
        /// </summary>
        public bool IsMdm { get; set; }

        public virtual SService SServices { get; set; }
        public virtual ICollection<DService> DServices { get; set; }
        public virtual ICollection<SServicesCustomerTariff> SServicesCustomerTariffs { get; set; }
        public virtual ICollection<SServicesDocument> SServicesDocuments { get; set; }
        public virtual ICollection<SServicesDocumentsResult> SServicesDocumentsResults { get; set; }
        public virtual ICollection<SServicesFile> SServicesFiles { get; set; }
        public virtual ICollection<SServicesForm> SServicesForms { get; set; }
    }
}

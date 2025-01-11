using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AisLogistics.DataLayer.Common.Dto.Reference
{
    public class EmployeeModelDto
    {
        public Guid Id { get; set; }
        /// <summary>
        /// ФИО сотрудника
        /// </summary>
        public string EmployeeName { get; set; }
        /// <summary>
        /// Номер телефона сотрудника
        /// </summary>
        public string EmployeePhone { get; set; }
        /// <summary>
        /// Электронная почта сотрудника
        /// </summary>
        public string EmployeeEmail { get; set; }
        /// <summary>
        /// Табельный номер
        /// </summary>
        public string EmployeePersonalNumber { get; set; }
        /// <summary>
        /// Номер сертификата
        /// </summary>
        public string EmployeeCertificateNumber { get; set; }
        
        /// <summary>
        /// Серия паспорта
        /// </summary>
        public string EmployeeDocSerial { get; set; }
        /// <summary>
        /// Номер паспорта
        /// </summary>
        public string EmployeeDocNumber { get; set; }
        /// <summary>
        /// Дата выдачи паспорта
        /// </summary>
        public DateTime? EmployeeDocIssueDate { get; set; }
        /// <summary>
        /// Кем выдан
        /// </summary>
        public string EmployeeDocIssuePlace { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? EmployeeDocBirthDate { get; set; }
        /// <summary>
        /// Место рождения
        /// </summary>
        public string EmployeeDocBirthPlace { get; set; }
        /// <summary>
        /// СНИЛС - Страховой номер индивидуального лицевого счёта
        /// </summary>
        public string EmployeeSnils { get; set; }
        /// <summary>
        /// ИНН - Идентификационный номер налогоплательщика
        /// </summary>
        public string EmployeeInn { get; set; }

        public Guid? AspNetUserId { get; set; }

        /// <summary>
        /// Сотрудник добавивший
        /// </summary>
        public Guid SEmployeesIdAdd { get; set; }
        /// <summary>
        /// Сотрудник добавивший запись
        /// </summary>
        public string EmployeesFioAdd { get; set; }
        public string EmployeeLogin {  get; set; }  
    }
}

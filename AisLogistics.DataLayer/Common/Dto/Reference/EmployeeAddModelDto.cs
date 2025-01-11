using System;
using System.ComponentModel.DataAnnotations;

namespace AisLogistics.DataLayer.Common.Dto.Reference
{
    public class EmployeeAddModelDto
    {
        public Guid Id { get; set; }
        /// <summary>
        /// ФИО сотрудника
        /// </summary>

        [Required(ErrorMessage = "Укажите Ф.И.О. сотрудника")]
        public string EmployeeName { get; set; }
        /// <summary>
        /// Номер телефона сотрудника
        /// </summary>
        public string EmployeePhone { get; set; }
        /// <summary>
        /// Электронная почта сотрудника
        /// </summary>

        [Required(ErrorMessage = "Укажите e-mail сотрудника")]
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


        [Required(ErrorMessage = "Укажите дату начала")]
        [DataType(DataType.Date)]
        public DateTime DateStart { get; set; }

        /// <summary>
        /// Офис
        /// </summary>
        public Guid SOfficesId { get; set; }
        /// <summary>
        /// Должность
        /// </summary>
        public int SEmployeesJobPositionId { get; set; }

        /// <summary>
        /// Интенсивность
        /// </summary>
        public decimal EmployeeIntensity { get; set; }

        /// <summary>
        /// Ставка
        /// </summary>
        public decimal EmployeeRate { get; set; }


        /// <summary>
        /// Статус
        /// </summary>
        public int SEmployeesStatusId { get; set; }

        /// <summary>
        /// Исполнение
        /// </summary>
        public bool IsExecution { get; set; }

        /// <summary>
        /// Роль исполнителя
        /// </summary>
        public Guid SRolesExecutorId { get; set; }

        /// <summary>
        /// Активность
        /// </summary>
        public bool IsActive { get; set; }



        [Required(ErrorMessage = "Укажите логин")]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Пароль не должен быть пустым!", AllowEmptyStrings = false)]
        [MinLength(6, ErrorMessage = "Длина пароля должна быть не менее 6 символов!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Укажите роль")]
        public Guid RoleId { get; set; }


        public Guid? AspNetUserId { get; set; }

        /// <summary>
        /// Сотрудник добавивший
        /// </summary>
        public Guid SEmployeesIdAdd { get; set; }
        /// <summary>
        /// Сотрудник добавивший запись
        /// </summary>
        public string EmployeesFioAdd { get; set; }
    }
}

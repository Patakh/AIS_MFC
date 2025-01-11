using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.ViewModels.Cases
{
    public class SearchCasesResponseData : SearchCasesRequestData
    {
        public SelectList OfficesReceptionCustomerList { get; internal set; }
        public SelectList OfficesProviderServicesList { get; internal set; }
        public SelectList ServicesList { get; internal set; }
        public SelectList StatusList { get; internal set; }
        public SelectList StagesList { get; internal set; }
        public SelectList SmevServicesList { get; internal set; }
        public SelectList SmevRequestList { get; internal set; }
    }

    /// <summary>
    /// Данные запроса поиска обращения
    /// </summary>
    public class SearchCasesRequestData
    {
        public SearchCasesRequestData()
        {
            Status = new List<int>() { -1 };
            Stages = new List<int>() { -1 };
            OfficeId = new List<Guid> {Guid.Empty };
            ServiceId = new List<Guid>() { Guid.Empty };
            LivingSituationId = new List<Guid>();
            SmevServices = new List<Guid>() { Guid.Empty };
            SmevRequest = new List<int>() { -1 };
        }
        /// <summary>
        /// Поиск в архиве
        /// </summary>
        public bool IsArchive { get; set; }
        /// <summary>
        /// Поиск в избранном
        /// </summary>
        public bool IsFavorite { get; set; }
        /// <summary>
        /// Строка поиска
        /// </summary>
        public string Query { get; set; } = "";
        /// <summary>
        /// Начало периода
        /// </summary>
        public DateTime? DateStart { get; set; }
        /// <summary>
        /// Конец периода
        /// </summary>
        public DateTime? DateStop { get; set; }
        /// <summary>
        /// Тип заявителя
        /// </summary>
        public int CustomresType { get; set; }
        /// <summary>
        /// Id МФЦ
        /// </summary>
        public string ReceptionOfficeId { get; set; }
        /// <summary>
        /// Id МФЦ
        /// </summary>
        public List<Guid> ReceptionOfficesIdList { get; set; }
        /// <summary>
        /// Id сотрудника
        /// </summary>
        public Guid? EmployeeId { get; set; }
        /// <summary>
        /// Фио сотрудника (Текущий)
        /// </summary>
        public string EmployeeCurrent { get; set; } = "";
        /// <summary>
        /// Фио сотрудника (Принял)
        /// </summary>
        public string EmployeeAdd { get; set; } = "";
        /// <summary>
        /// Тип Статуса СМЭВ запроса
        /// </summary>
        public int? SmevStatusId { get; set; }
        /// <summary>
        /// Тип Даты
        /// </summary>
        public int? PeriodId { get; set; }
        
        /// <summary>
        /// Список Офисов
        /// </summary>
        public List<Guid> OfficeId { get; set; }
        /// <summary>
        /// Список услуг
        /// </summary>
        public List<Guid> ServiceId { get; set; }
        /// <summary>
        /// Список сервисов
        /// </summary>
        public List<Guid> SmevServices { get; set; }
        /// <summary>
        /// Список запросов
        /// </summary>
        public List<int> SmevRequest { get; set; }
        /// <summary>
        /// Список жизненных ситуаций
        /// </summary>
        public List<Guid> LivingSituationId { get; set; }
        /// <summary>
        /// Статус исполнения
        /// </summary>
        public List<int> Status { get; set; }
        /// <summary>
        /// Список Этапов
        /// </summary>
        public List<int> Stages { get; set; }
    }
}

namespace AisLogistics.App.Models.DTO.Notifications
{
    public class EmployeeNotificationDto
    {
        /// <summary>
        /// Уведомления примечаний
        /// </summary>
        public List<CommentInfo> CommentsAlert { get; set; }
        /// <summary>
        /// Уведомление новых услуг
        /// </summary>
        public List<NewServicesInfo> NewServicesAlert { get; set; }
        /// <summary>
        /// Уведомления СМЭВ
        /// </summary>
        public List<SmevResponseInfo> SmevResponseAlert { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        public EmployeeNotificationDto()
        {
            CommentsAlert = new List<CommentInfo>();
            NewServicesAlert = new List<NewServicesInfo>();
            SmevResponseAlert = new List<SmevResponseInfo>();
        }

        /// <summary>
        /// Новая услуга
        /// </summary>
        public class NewServicesInfo
        {
            /// <summary>
            /// Индетификатор уведомления
            /// </summary>
            public Guid Id { get; set; }
            /// <summary>
            ///  Номер обращения
            /// </summary>
            public string CaseId { get; set; }
            /// <summary>
            ///  id услуги
            /// </summary>
            public Guid? ServicesId { get; set; }
            /// <summary>
            /// Фио заявителя
            /// </summary>
            public string ApplicantName { get; set; }
            /// <summary>
            /// Наименование услуги
            /// </summary>
            public string ServicesName { get; set; }
            /// <summary>
            /// Фио сотрудника добавивший этап
            /// </summary>
            public string EmployeeNameAdd { get; set; }
            /// <summary>
            /// Дата добавления этапа
            /// </summary>
            public DateTime? DateAddStage { get; set; }
            /// <summary>
            /// Тип уведомления
            /// </summary>
            public int TypeAlerts { get; set; }
        }
        /// <summary>
        ///  Примечание
        /// </summary>
        public class CommentInfo
        {
            /// <summary>
            /// Индетификатор уведомления
            /// </summary>
            public Guid Id { get; set; }
            /// <summary>
            ///  Номер обращения
            /// </summary>
            public string CaseId { get; set; }
            /// <summary>
            ///  id услуги
            /// </summary>
            public Guid? ServicesId { get; set; }
            /// <summary>
            /// Фио заявителя
            /// </summary>
            public string ApplicantName { get; set; }
            /// <summary>
            /// Содержимое комментария
            /// </summary>
            public string TextComment { get; set; }
            /// <summary>
            /// Дата добавления комментария
            /// </summary>
            public DateTime? DateAddComment { get; set; }
            /// <summary>
            /// Фио сотрудника добавивший примечание
            /// </summary>
            public string EmployeeNameAdd { get; set; }
            /// <summary>
            /// Тип уведомления
            /// </summary>
            public int TypeAlerts { get; set; }
        }
        /// <summary>
        /// СМЭВ ответ
        /// </summary>
        public class SmevResponseInfo
        {
            /// <summary>
            /// Индетификатор уведомления
            /// </summary>
            public Guid Id { get; set; }
            /// <summary>
            ///  Номер обращения
            /// </summary>
            public string CaseId { get; set; }
            /// <summary>
            ///  id услуги
            /// </summary>
            public Guid? ServicesId { get; set; }
            /// <summary>
            /// Фио заявителя
            /// </summary>
            public string ApplicantName { get; set; }
            /// <summary>
            /// Наименование CМЭВ запроса
            /// </summary>
            public string SmevName { get; set; }
            /// <summary>
            /// Дата ответа СМЭВ
            /// </summary>
            public DateTime? DateSmevResponse { get; set; }
            /// <summary>
            /// Тип уведомления
            /// </summary>
            public int TypeAlerts { get; set; }
        }
    }
}

namespace AisLogistics.API.Models.Request.Jitsi
{
    public class SaveCallRequest
    {
        /// <summary>
        /// Id
        /// </summary>        
        public Guid id { get; set; }

        /// <summary>
        /// Id МФЦ
        /// </summary>        
        public string idMfc { get; set; }

        /// <summary>
        /// Id Услуги
        /// </summary>        
        public string idService { get; set; }

        /// <summary>
        /// Id Сотрудника
        /// </summary>        
        public string idEmployee { get; set; }

        /// <summary>
        /// Id ФТП
        /// </summary>        
        public string idFtp { get; set; }

        /// <summary>
        /// Номер дела
        /// </summary>        
        public string caseNumber { get; set; }

        /// <summary>
        /// ФИО заявителя
        /// </summary>        
        public string customerName { get; set; }

        /// <summary>
        /// Телефон заявителя
        /// </summary>        
        public string customerPhone { get; set; }
        /// <summary>
        /// Формат аудиофайла
        /// </summary>
        public string audioFormat { get; set; }
        /// <summary>
        /// Тип звонка
        /// </summary>       
        public Jitsi_call_type callType { get; set; }
        /// <summary>
        /// IP адрес
        /// </summary>        
        public string ipAddress { get; set; }
        /// <summary>
        /// Дата звонка
        /// </summary>
        public DateTime? dateCall { get; set; }
        /// <summary>
        /// Время разговора
        /// </summary>
        public string callDuration { get; set; }
        /// <summary>
        /// Байты
        /// </summary>
        public sbyte[] fileByte { get; set; }
    }


    /// <summary>
    /// Типы звонков
    /// </summary>
    public enum Jitsi_call_type
    {
        /// <summary>
        /// Входящий звонок
        /// </summary>
        incoming,
        /// <summary>
        /// Исхорящий звонок
        /// </summary>
        outgoing,
        /// <summary>
        /// Исхорящий звонок
        /// </summary>
        outgoing_callback
    }
}

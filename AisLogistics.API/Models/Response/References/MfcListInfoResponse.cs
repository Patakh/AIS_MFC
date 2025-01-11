namespace AisLogistics.API.Models.Responce
{
    public class MfcListInfoResponse
    {
        /// <summary>
        ///  Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///  Id МФЦ для электронной очереди
        /// </summary>
        public string? QueueId { get; set; }

        /// <summary>
        ///  Наименование
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        ///  Адрес
        /// </summary>      
        public string? Address { get; set; }

        /// <summary>
        ///  Номер телефона
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        ///  Веб-сайт
        /// </summary>
        public string? Website { get; set; }

        /// <summary>
        ///  Электронная почта
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        ///  Количество окон
        /// </summary>
        public int? CountWindows { get; set; }
        /// <summary>
        ///  Широта
        /// </summary>
        public string? Latitude { get; set; }
        /// <summary>
        ///  Долгота
        /// </summary>
        public string? Longitude { get; set; }

        /// <summary>
        ///  Скайп
        /// </summary>
        public string? Skype { get; set; }

        /// <summary>
        ///  Удобства
        /// </summary>
        public string? Inn { get; set; }
        /// <summary>
        ///  Удобства
        /// </summary>
        public string? Ogrn { get; set; }
        /// <summary>
        ///  Удобства
        /// </summary>
        public string? DirectorName { get; set; }
        /// <summary>
        /// Площадь
        /// </summary>
        public decimal? OfficeSquare { get; set; }
        /// <summary>
        /// Фото
        /// </summary>
        public byte[]? OfficeImage { get; set; }
    }
}

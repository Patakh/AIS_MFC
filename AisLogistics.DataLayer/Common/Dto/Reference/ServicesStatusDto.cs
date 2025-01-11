namespace AisLogistics.DataLayer.Common.Dto.Reference
{
    public class ServicesStatusDto
    {
        /// <summary>
        ///  Первичный ключ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование статуса
        /// </summary>
        public string StatusName { get; set; }
        /// <summary>
        /// Завершение услуги
        /// </summary>
        public bool IsDatefact { get; set; }
    }
}

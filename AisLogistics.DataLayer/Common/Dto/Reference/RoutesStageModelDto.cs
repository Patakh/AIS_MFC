namespace AisLogistics.DataLayer.Common.Dto.Reference
{
    public class RoutesStageModelDto
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование этапа
        /// </summary>
        public string StageName { get; set; }
        /// <summary>
        /// Количество дней на исполнение по умолчанию
        /// </summary>
        public int DayExcution { get; set; }
        /// <summary>
        /// Комментарий к записи
        /// </summary>
        public string Commentt { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public int? SServicesStatusId { get; set; }
    }
}

namespace AisLogistics.App.Models.DTO.References
{
    public class ServiceDocumentResultDto
    {
        public Guid Id { get; set; }
        public Guid SServicesId { get; set; }
        public Guid SDocumentsId { get; set; }

        public string DocumentName { get; set; }

        public string? ProcedureName { get; set; }

        public string TypeName { get; set; }

        /// <summary>
        /// Результат положительный или отрицательный
        /// </summary>
        public bool DocumentResult { get; set; }

        /// <summary>
        /// Способы получения документа
        /// </summary>
        public string DocumentMethod { get; set; }

        /// <summary>
        /// Срок хранения в органе власти
        /// </summary>
        public string DocumentPeriodProvider { get; set; }

        /// <summary>
        /// Срок хранения в мфц
        /// </summary>
        public string DocumentPeriodMfc { get; set; }
    }
}

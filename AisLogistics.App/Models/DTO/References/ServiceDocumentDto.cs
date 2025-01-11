using AisLogistics.App.Extensions;

namespace AisLogistics.App.Models.DTO.References
{
    public class ServiceDocumentDto
    {
        public Guid Id { get; set; }
        public Guid SServicesId { get; set; }

        public string DocumentName { get; set; }

        public string? ProcedureName { get; set; }

        /// <summary>
        /// Необходимость документа. Обязательный - 0, Не обязательный документ - 1, При наличии - 2.
        /// </summary>
        public int DocumentNeeds { get; set; }

        public string DocumentNeedsName
        {
            get
            {
                return ((ServiceDocumentNeedsType)DocumentNeeds).GetDisplayName();
            }
        }

        /// <summary>
        /// Тип документа. Оригинал - 0, Копия - 1
        /// </summary>
        public int DocumentType { get; set; }

        public string DocumentTypeName
        {
            get
            {
                return ((ServiceDocumentType)DocumentType).GetDisplayName();
            }
        }

        /// <summary>
        /// Количество копий документа
        /// </summary>
        public int DocumentCount { get; set; }

        public Guid SDocumentsId { get; set; }

      
        public string TypeName { get; set; }

        public bool IsUploadingSite { get; set; }
        public string IsUploadingSiteToString => IsUploadingSite ? "Да" : "Нет";
    }
}

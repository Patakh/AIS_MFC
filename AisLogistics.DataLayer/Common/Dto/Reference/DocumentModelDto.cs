using System;

namespace AisLogistics.DataLayer.Common.Dto.Reference
{
    public class DocumentModelDto
    {

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Наименование документа
        /// </summary>
        public string DocumentName { get; set; }
        /// <summary>
        /// Описание документа
        /// </summary>
        public string DocumentDescription { get; set; }
        /// <summary>
        /// Требование к документу
        /// </summary>
        public string DocumentSpecification { get; set; }
        public string EmployeesFioAdd { get; set; }
    }
}

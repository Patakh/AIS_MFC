using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник сервисов СМЭВ (Систе́ма межве́домственного электро́нного взаимоде́йствия)
    /// </summary>
    public partial class SSmev
    {
        public SSmev()
        {
            SSmevRequests = new HashSet<SSmevRequest>();
        }

        /// <summary>
        /// Наименование сервиса СМЭВ
        /// </summary>
        public string SmevName { get; set; }
        /// <summary>
        /// Наименование организации  владельца 
        /// </summary>
        public string SmevProvider { get; set; }
        /// <summary>
        /// Адрес сервиса СМЭВ
        /// </summary>
        public string ProviderUrl { get; set; }
        /// <summary>
        /// Код органа исполнительной власти, используется в запросе
        /// </summary>
        public string ProviderCode { get; set; }
        /// <summary>
        /// Наименование оператора ИС
        /// </summary>
        public string ProviderName { get; set; }
        /// <summary>
        /// Описание сервиса
        /// </summary>
        public string SmevDescription { get; set; }
        /// <summary>
        /// Сид сервиса
        /// </summary>
        public string SmevMnemo { get; set; }
        /// <summary>
        /// СМЭВ 3 запрос или нет
        /// </summary>
        public bool IsSmev3 { get; set; }
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Признак удаления записи
        /// </summary>
        public bool IsRemove { get; set; }

        public virtual ICollection<SSmevRequest> SSmevRequests { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Cписок поставщиков загруженных с ИАС МКГУ
    /// </summary>
    public partial class DIasMkguProviderLoad
    {
        /// <summary>
        /// ID органа власти из фргу
        /// </summary>
        public string FrguProviderId { get; set; }
        /// <summary>
        /// наименование поставщика
        /// </summary>
        public string ProviderName { get; set; }
        /// <summary>
        /// дата последнего обновления
        /// </summary>
        public DateTime? LastUpdate { get; set; }
    }
}

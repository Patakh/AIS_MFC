using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник типов запросов СМЭВ (Систе́ма межве́домственного электро́нного взаимоде́йствия)
    /// </summary>
    public partial class SSmevTypeRequest
    {
        public SSmevTypeRequest()
        {
            SSmevRequests = new HashSet<SSmevRequest>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование типа СМЭВ
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// Комментарий
        /// </summary>
        public string Commentt { get; set; }

        public virtual ICollection<SSmevRequest> SSmevRequests { get; set; }
    }
}

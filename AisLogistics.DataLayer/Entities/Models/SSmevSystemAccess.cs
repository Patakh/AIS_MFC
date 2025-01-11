using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Cправочник систем СМЭВ 3 для доступа к эмулятору СМЭВ 3 на сервисе
    /// </summary>
    public partial class SSmevSystemAccess
    {
        public SSmevSystemAccess()
        {
            DEpguDocumentsLoads = new HashSet<DEpguDocumentsLoad>();
            DEpguDocumentsResponses = new HashSet<DEpguDocumentsResponse>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Наименовение системы
        /// </summary>
        public string SmevName { get; set; }
        /// <summary>
        /// Мнемоника системы
        /// </summary>
        public string SmevMnemonic { get; set; }
        /// <summary>
        /// Разрешить тестовый доступ
        /// </summary>
        public bool TestAccess { get; set; }
        /// <summary>
        /// Разрешить продуктивный доступ
        /// </summary>
        public bool ProductionAccess { get; set; }
        /// <summary>
        /// Открытая часть сертификата
        /// </summary>
        public byte[] Certificate { get; set; }

        public virtual ICollection<DEpguDocumentsLoad> DEpguDocumentsLoads { get; set; }
        public virtual ICollection<DEpguDocumentsResponse> DEpguDocumentsResponses { get; set; }
    }
}

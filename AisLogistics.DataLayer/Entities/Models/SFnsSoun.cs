using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AisLogistics.DataLayer.Entities.Models
{
    public  class SFnsSoun
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Код налогового органа
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Наименование налогового органа
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Адрес налогового органа
        /// </summary>
        public string Address { get; set; }

    }
}

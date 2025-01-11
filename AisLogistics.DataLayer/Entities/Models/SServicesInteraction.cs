using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AisLogistics.DataLayer.Entities.Models
{
    public class SServicesInteraction
    {
        public SServicesInteraction()
        {
            SServices = new HashSet<SService>();
            DServices = new HashSet<DService>();
        }
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string InteractionName { get; set; }

        public virtual ICollection<SService> SServices { get; set; }
        public virtual ICollection<DService> DServices { get; set; }
    }
}

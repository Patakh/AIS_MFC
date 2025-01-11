using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AisLogistics.DataLayer.Entities.Models
{
    public class SForm
    {
        public int Id { get; set; }
        public string FormName { get; set; }
        public string Comment { get; set; }
        public byte[] File { get; set; }
    }
}

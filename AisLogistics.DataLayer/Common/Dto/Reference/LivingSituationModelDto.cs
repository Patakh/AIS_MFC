using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AisLogistics.DataLayer.Common.Dto.Reference
{
    public  class LivingSituationModelDto
    {
        public Guid Id { get; set; }
        [Required]
        public string SituationName { get; set; }
        public string Commentt { get; set; }
        public string EmployeesFioAdd { get; set; }
        public DateTime DateAdd { get; set; }
    }
}

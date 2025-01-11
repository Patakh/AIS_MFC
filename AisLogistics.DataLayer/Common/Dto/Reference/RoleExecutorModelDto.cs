using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AisLogistics.DataLayer.Common.Dto.Reference
{
    public class RoleExecutorModelDto
    {
        public Guid Id { get; set; }

        [Required]
        public string RoleName { get; set; }
        public string Description { get; set; }
        public string EmployeesFioAdd { get; set; }
        public DateTime DateAdd { get; set; }
    }
}

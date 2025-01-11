using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AisLogistics.DataLayer.Common.Dto.Reference
{
    public class IasMkguInfomatAnswerDto
    {
        public Guid Id { get; set; }
        public string DCasesId { get; set; }
        public int SIasMkguQuestionId { get; set; }
        public int SIasMkguQuestionAnswerId { get; set; }
        public DateTime DateAnswer { get; set; }
    }
}

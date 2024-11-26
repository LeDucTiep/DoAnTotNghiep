using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ldtiep.be.DL.Entity
{
    public class Rule : BaseEntity
    {
        public Guid RuleID { get; set; }
        public string RuleName { get; set; }
    }
}

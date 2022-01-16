using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Framework_DP
{
    public class And : LogicalComparison
    {
        public And()
        {
            conditions = new List<Condition>();
        }
        public And(List<Condition> conditions)
        {
            this.conditions = conditions;
        }
        public override string getLogic()
        {
            return "AND";
        }
    }
}

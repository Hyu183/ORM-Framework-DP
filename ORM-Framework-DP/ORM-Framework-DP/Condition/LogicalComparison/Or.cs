using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Framework_DP
{
    public class Or : LogicalComparison
    {
        public Or()
        {
            conditions = new List<Condition>();
        }
        public Or(List<Condition> conditions)
        {
            this.conditions = conditions;
        }
        public override string getLogic()
        {
            return "OR";
        }
    }
}

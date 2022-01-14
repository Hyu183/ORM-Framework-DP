using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Framework_DP
{
    class Or : LogicalComparison
    {
        public Or()
        {
            conditions = new List<Condition>();
        }

        public Or(Condition a, Condition b)
        {
            conditions = new List<Condition>();
            conditions.Add(a);
            conditions.Add(b);
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

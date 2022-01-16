using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Framework_DP
{
    class Not : Condition
    {
        protected Condition condition;

        public Not(Condition condition)
        {
            this.condition = condition;
        }
        public override string parseToSQL()
        {
            return "(NOT" + condition.parseToSQL() + ")"; 
        }
    }
}

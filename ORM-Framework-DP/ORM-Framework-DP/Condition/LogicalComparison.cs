using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Framework_DP
{
    abstract class LogicalComparison : Condition
    {
        protected List<Condition> conditions;

        public abstract string getLogic();
        public override string parseToSQL()
        {
            string opt = getLogic();
            if (conditions.Count == 0)
            {
                return "";
            }
            if (conditions.Count == 1)
            {
                return conditions[0].parseToSQL();
            }
            string res = conditions[0].parseToSQL();
            for (int i = 1; i < conditions.Count; i++)
            {
                res += " " + opt + " " + conditions[i].parseToSQL();
            }
            res = "(" + res + ")";
            return res;
        }
        public Condition Add(Condition condition)
        {
            this.conditions.Add(condition);
            return this;
        }
    }
}

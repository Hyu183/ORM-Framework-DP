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
        public override string parseToSQL(Dictionary<string, string> featureMap)
        {
            string opt = getLogic();
            if (conditions.Count == 0)
            {
                return "";
            }
            string res = conditions[0].parseToSQL(featureMap);
            for (int i = 1; i < conditions.Count; i++)
            {
                res += " " + opt + " " + conditions[i].parseToSQL(featureMap);
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

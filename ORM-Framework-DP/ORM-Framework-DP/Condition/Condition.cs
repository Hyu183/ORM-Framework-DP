using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Framework_DP
{
    abstract class Condition
    {
        public abstract string parseToSQL(Dictionary<string, string> featureMap);
        public static And And(Condition a, Condition b)
        {
            return new And(a, b);
        }
        public static And And()
        {
            return new And();
        }
        public static Or Or(Condition a, Condition b)
        {
            return new Or(a, b);
        }
        public static Or Or()
        {
            return new Or();
        }
        public static LessThan LessThan(string a, Object b, string aggegrateFunction = "")
        {
            return new LessThan(a, b, aggegrateFunction);
        }
        public static LessThanOrEqual LessThanOrEqual(string a, Object b, string aggegrateFunction = "")
        {
            return new LessThanOrEqual(a, b, aggegrateFunction);
        }
        public static GreaterThan GreaterThan(string a, Object b, string aggegrateFunction = "")
        {
            return new  GreaterThan(a, b, aggegrateFunction);
        }
        public static GreaterThanOrEqual GetGreaterThanOrEqual(string a, Object b, string aggegrateFunction = "")
        {
            return new GreaterThanOrEqual(a, b, aggegrateFunction);
        }
        public static Equal Equal(string a, Object b, string aggegrateFunction = "")
        {
            return new Equal(a, b, aggegrateFunction);
        }
        public static Like Like(string a, Object b, string aggegrateFunction = "")
        {
            return new Like(a, b, aggegrateFunction);
        }
        public static Not Not(Condition condition)
        {
            return new Not(condition);
        }
    }
}

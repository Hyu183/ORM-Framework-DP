using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Framework_DP
{
    abstract class Comparison : Condition
    {
        protected string field { get; set; }
        protected Object value { get; set; }
        protected string aggegrateFunction { get; set; }
        public abstract string getComparisonOperator();
        public Comparison(string field, Object value, string aggegrateFunction)
        {
            this.field = field;
            this.value = value;
            this.aggegrateFunction = aggegrateFunction;
        }
        public string parseToString(Object obj)
        {
            Type type = obj.GetType();
            if (type == typeof(string))
                return "\"" + obj.ToString() + "\"";
            else if (type == typeof(DateTime))
            {
                return "\"" + ((DateTime)obj).ToString("yyyy-MM-dd HH:mm:ss") + "\"";
            }
            return obj.ToString();
        }
        public override string parseToSQL()
        {
            if (aggegrateFunction.Length != 0)
            {
                field = aggegrateFunction + "(" + field + ")";
            }
            return field + getComparisonOperator() + parseToString(value);
        }
    }
}

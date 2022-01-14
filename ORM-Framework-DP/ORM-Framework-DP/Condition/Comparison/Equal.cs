using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Framework_DP
{
    class Equal : Comparison
    {
        public Equal(string a, object b, string aggegrateFunction = "") : base(a, b, aggegrateFunction)
        {

        }
        public override string getComparisonOperator()
        {
            return "=";
        }
    }
}

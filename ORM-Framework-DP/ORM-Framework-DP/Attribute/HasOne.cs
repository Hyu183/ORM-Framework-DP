using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Framework_DP
{
    public class HasOne : HasN
    {
        public HasOne(string tableName, params string[] pKPairs) : base(tableName, pKPairs)
        {
        }
    }
}

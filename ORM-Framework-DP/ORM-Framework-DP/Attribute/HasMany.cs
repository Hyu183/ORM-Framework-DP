using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Framework_DP
{
    public class HasMany : Attribute
    {
        
        public string TableName { get; set; }

        public PropertyInfo propertyInfo { get; set; }

        // List to map prob names in class to primary key colume names in the target table
        // Format "prob_name=target_PK_name"
        public string[] PKPairs { get; set; }

        public Dictionary<string, string> PKPairsDic;

        public HasMany(string tableName, params string[] pKPairs)
        {
            TableName = tableName;
            PKPairs = pKPairs;
            PKPairsDic = null;
            propertyInfo = null;
        }
    }
}

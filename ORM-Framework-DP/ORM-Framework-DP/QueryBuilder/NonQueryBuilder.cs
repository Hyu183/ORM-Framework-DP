using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORM_Framework_DP
{
    public abstract class NonQueryBuilder
    {
        public abstract string ConvertValueToString(object value, Type type);

        public abstract string BuildInsert(string tableName, List<string> columnNames, List<object> values);
       
        public abstract string BuildDelete(string tableName, List<string> columnNames, List<object> values);
        
        public abstract string BuildUpdate(string tableName, Dictionary<string, object> primaryKeyValueMap, Dictionary<string,object> newColumnValuesMap);
        public abstract string BuildUpdateWithCondition(string tableName, Dictionary<string, object> newColumnValuesMap, Condition condition);

    }
}
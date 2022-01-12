using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORM_Framework_DP
{
    public class QueryBuilder
    {
        private string ConvertValueToString(object value, Type type)
        {
            if(type== typeof(string))
            {
                return "'" + value + "'";
            }
            else if(type == typeof(DateTime))
            {
                return "'" + ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }

            return value.ToString();
        }

        public  string BuildInsert(string tableName, List<string> columnNames, List<object> values)
        {
            string columnNamesString = "";
            string valuesString = "";
            foreach(var columnName in columnNames)
            {
                columnNamesString += columnName + ",";
            }

            foreach (var value in values)
            {
                valuesString += ConvertValueToString(value,value.GetType()) + ",";
            }

            //remove the last ","
            columnNamesString = columnNamesString[0..^1];
            valuesString = valuesString[0..^1];
            string query = string.Format("INSERT INTO {0} ({1}) VALUES ({2})",tableName,columnNamesString,valuesString);

            return query;
        }
    }
}
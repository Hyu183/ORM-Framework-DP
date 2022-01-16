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
        public string BuildDelete(string tableName, List<string> columnNames, List<object> values)
        {
            string columnNamesString = "";
            string valuesString = "";
            string whereCondition = "";
            foreach (var columnName in columnNames)
            {
                columnNamesString += columnName + ",";
            }

            foreach (var value in values)
            {
                valuesString += ConvertValueToString(value, value.GetType()) + ",";
            }

            for(int i = 1; i< columnNames.Count-1; i++)
            {
                whereCondition += columnNames[i] + " = "  + ConvertValueToString(values[i], values[i].GetType()) + " AND ";  
            }
            whereCondition += columnNames[columnNames.Count - 1] + " = " +  ConvertValueToString(values[columnNames.Count - 1], values[columnNames.Count - 1].GetType());

            columnNamesString = columnNamesString[0..^1];
            valuesString = valuesString[0..^1];
            string query = string.Format("DELETE FROM {0} WHERE {1}", tableName, whereCondition);
            Console.WriteLine(query);

            return query;
        }
    }
}
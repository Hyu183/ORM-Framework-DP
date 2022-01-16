using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORM_Framework_DP
{
    public class MySQLNonQueryBuilder:NonQueryBuilder
    {
        public override string ConvertValueToString(object value, Type type)
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

        public override string BuildInsert(string tableName, List<string> columnNames, List<object> values)
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
        public override string BuildDelete(string tableName, List<string> columnNames, List<object> values)
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


        public override string BuildUpdate(string tableName, Dictionary<string, object> primaryKeyValueMap, Dictionary<string, object> newColumnValuesMap)
        {
            string query = "UPDATE " + tableName + " SET ";           

                

                List<Condition> _condition = new List<Condition>();

                foreach (var key in primaryKeyValueMap.Keys)
                {
                    if (newColumnValuesMap.ContainsKey(key))
                        newColumnValuesMap.Remove(key);
                    _condition.Add(Condition.Equal(key, primaryKeyValueMap[key]));
                }

                Condition condition = Condition.And(_condition);

                foreach(var col in newColumnValuesMap.Keys)
                {
                    query += string.Format(" {0} = {1},", col, ConvertValueToString(newColumnValuesMap[col], newColumnValuesMap[col].GetType()));
                }
                query = query[0..^1];

                query += " WHERE " + condition.parseToSQL();


                return query;
                
            
        }

        public override string BuildUpdateWithCondition(string tableName, Dictionary<string, object> newColumnValuesMap, Condition condition) {
            string query = "UPDATE " + tableName + " SET ";
           

            foreach (var col in newColumnValuesMap.Keys)
            {
                query += string.Format(" {0} = {1},", col, ConvertValueToString(newColumnValuesMap[col], newColumnValuesMap[col].GetType()));
            }
            query = query[0..^1];

            query += " WHERE " + condition.parseToSQL();

            return query;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Framework_DP
{
    public class SQLserverSyntax : DatabaseSyntax
    {
        public string BuildQuery(string tableName, Condition whereConditon, Condition havingCondition, string[] groupByColumeNames)
        {

            string query = GetSelectAllPart(tableName);

            if (whereConditon != null)
            {
                query += " " + GetWherePart(whereConditon);
            }

            if (groupByColumeNames != null)
            {
                query += " " + GetGroupByPart(groupByColumeNames);
            }

            if (havingCondition != null)
            {
                query += " " + GetHavingPart(havingCondition);
            }

            query += ";";

            return query;
        }

        public string BuildSelectWhereFromValuePairs(Dictionary<string, string> columeNameValuePairs, string tableName)
        {
            string query = string.Format("SELECT * FROM {0} WHERE 1", tableName);
            foreach (var pair in columeNameValuePairs)
            {
                query += " AND ";
                string propName = pair.Key;
                string value = pair.Value;
                query += string.Format(" {0}={1} ", propName, value);
            }
            query += ";";
            return query;
        }

        public string ConvertValueToString(object value, Type type)
        {
            if (type == typeof(string))
            {
                return "'" + value + "'";
            }
            else if (type == typeof(DateTime))
            {
                return "'" + ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }

            return value.ToString();
        }

        public string GetAnd()
        {
            return "AND";
        }

        public string GetConnectionString(string host, string dbName, string uid, string port, string password)
        {
            return string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};Trusted_Connection=true;",
                host, dbName, port, password);
        }

        public string GetGroupByPart(string[] columeNames)
        {
            return "GROUP BY " + string.Join(", ", columeNames);
        }

        public string GetHavingPart(Condition condition)
        {
            return string.Format("HAVING {0}", condition.parseToSQL());
        }

        public string GetOr()
        {
            return "OR";
        }

        public string GetSelectAllPart(string tableName)
        {
            return string.Format("SELECT * FROM {0}", tableName);
        }

        public string GetWherePart(Condition condition)
        {
            return string.Format("WHERE {0}", condition.parseToSQL());
        }

        public string BuildInsert(string tableName, List<string> columnNames, List<object> values)
        {
            string columnNamesString = "";
            string valuesString = "";
            foreach (var columnName in columnNames)
            {
                columnNamesString += columnName + ",";
            }

            foreach (var value in values)
            {
                valuesString += ConvertValueToString(value, value.GetType()) + ",";
            }

            //remove the last ","
            columnNamesString = columnNamesString[0..^1];
            valuesString = valuesString[0..^1];
            string query = string.Format("INSERT INTO {0} ({1}) VALUES ({2});", tableName, columnNamesString, valuesString);
            return query;
        }


        public string BuildUpdate(string tableName, Dictionary<string, object> primaryKeyValueMap, Dictionary<string, object> newColumnValuesMap)
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

            foreach (var col in newColumnValuesMap.Keys)
            {
                query += string.Format(" {0} = {1},", col, ConvertValueToString(newColumnValuesMap[col], newColumnValuesMap[col].GetType()));
            }
            query = query[0..^1];

            query += " WHERE " + condition.parseToSQL() + ";";


            return query;


        }

        public string BuildUpdateWithCondition(string tableName, Dictionary<string, object> newColumnValuesMap, Condition condition)
        {
            string query = "UPDATE " + tableName + " SET ";


            foreach (var col in newColumnValuesMap.Keys)
            {
                query += string.Format(" {0} = {1},", col, ConvertValueToString(newColumnValuesMap[col], newColumnValuesMap[col].GetType()));
            }
            query = query[0..^1];

            query += " WHERE " + condition.parseToSQL() + ";";

            return query;
        }

        public string BuildDelete(string tableName, Dictionary<string, object> primaryKeyValueMap)
        {
            string query = "DELETE FROM " + tableName;



            List<Condition> _condition = new List<Condition>();

            foreach (var key in primaryKeyValueMap.Keys)
            {
                _condition.Add(Condition.Equal(key, primaryKeyValueMap[key]));
            }

            Condition condition = Condition.And(_condition);


            query += " WHERE " + condition.parseToSQL() + ";";


            return query;
        }

        public string BuildDeleteWithCondition(string tableName, Condition condition)
        {
            string query = "DELETE FROM " + tableName + " WHERE " + condition.parseToSQL() + ";";

            return query;
        }
    }
}

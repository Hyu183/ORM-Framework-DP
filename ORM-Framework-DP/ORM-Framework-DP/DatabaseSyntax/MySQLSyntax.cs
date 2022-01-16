using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Framework_DP
{
    public class MySQLSyntax : DatabaseSyntax
    {
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

        public string GetConnectionString(string host, string dbName, string port, string uid, string password)
        {
            return string.Format("Server={0}; Database = {1}; port = {2}; UID = {3}; password={4};", 
                host, dbName, port, uid, password);
        }

        public string GetGroupByPart(List<string> columeNames)
        {
            throw new NotImplementedException();
        }

        public string GetHavingPart(string condition)
        {
            throw new NotImplementedException();
        }

        public string GetOr()
        {
            return "OR";
        }

        public string GetSelectAllPart(string tableName)
        {
            return string.Format("SELECT * FROM {0}", tableName);
        }

        public string GetWherePart(string condition)
        {
            throw new NotImplementedException();
        }
    }
}

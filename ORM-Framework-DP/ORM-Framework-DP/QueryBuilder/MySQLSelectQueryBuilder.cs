using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORM_Framework_DP
{
    class MySQLSelectQueryBuilder : SelectQueryBuilder
    {
        public MySQLSelectQueryBuilder(DBConnection db, string tableName) : base(db, tableName)
        {
        }

        public override string BuildSelectWhereFromValuePairs(Dictionary<string, string> columeNameValuePairs, string tableName)
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

        override
        public string getQueryString(Dictionary<string, string> featureMap)
        {
            string query = "";

            query += string.Format("SELECT * FROM {0}", this.tableName);
            //if (this.condition != null)
            //{
            //    query += string.format(" where {0}", this.condition.parsetosql(featuremap));
            //}

            if (!string.IsNullOrEmpty(this.condition))
            {
                query += string.Format(" WHERE {0}", this.condition);
            }


            if (!string.IsNullOrEmpty(this.groupBy))
            {
                query += string.Format(" GROUP BY {0}", this.groupBy);
            }

            if (!string.IsNullOrEmpty(this.having))
            {
                query += string.Format(" HAVING {0}", this.having);
            }

            query += ";";

            return query;
        }       

    }
}
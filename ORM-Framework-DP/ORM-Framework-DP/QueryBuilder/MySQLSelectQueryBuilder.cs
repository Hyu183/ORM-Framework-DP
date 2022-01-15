using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORM_Framework_DP
{
    class MySQLSelectQueryBuilder<T> : SelectQueryBuilder<T> where T : new()
    {
        public MySQLSelectQueryBuilder(DBConnection db, AttributeHelper<T> attributeHelper) : 
            base(db, attributeHelper)
        {
        }

        override
        public string getQueryString(Dictionary<string, string> featureMap)
        {
            string query = "";

            query += string.Format("SELECT * FROM {0}", this.tableName);
            //if (this.condition != null)
            //{
            //    query += string.Format(" WHERE {0}", this.condition.parseToSQL(featureMap));
            //}


            if (!string.IsNullOrEmpty(this.groupBy))
            {
                query += string.Format(" GROUP BY {0}", this.groupBy);
            }

            query += ";";

            return query;
        }       

    }
}
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
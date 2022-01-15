using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Framework_DP
{
    class MySQLDeleteQueryBuilder<T> : DeleteQueryBuilder<T> where T : new()
    {
        public MySQLDeleteQueryBuilder(DBConnection db, AttributeHelper<T> attributeHelper) :
            base(db, attributeHelper)
        {
        }

        override
        public string getQueryString(Dictionary<string, string> featureMap)
        {
            string query = "";

            query += string.Format("DELETE FROM", this.tableName);

            if (!string.IsNullOrEmpty(this.condition))
            {
                query += string.Format(" WHERE {0}", this.condition);
            }

            query += ";";

            return query;
        }

    }
}
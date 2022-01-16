using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Framework_DP
{
    class MySQLUpdateQueryBuilder<T> : UpdateQueryBuilder<T> where T : new()
    {
        public MySQLUpdateQueryBuilder(DBConnection db, AttributeHelper<T> attributeHelper) :
            base(db, attributeHelper)
        {
        }

        override
        public string getQueryString(Dictionary<string, string> featureMap)
        {
            string query = "";

            query += string.Format("UPDATE {0}", this.tableName);

            if (!string.IsNullOrEmpty(this.column))
            {
                query += string.Format(" SET {0}={1}", this.column, this.value);
            }

            if (!string.IsNullOrEmpty(this.condition))
            {
                query += string.Format(" WHERE {0}", this.condition);
            }

            query += ";";

            return query;
        }

    }
}

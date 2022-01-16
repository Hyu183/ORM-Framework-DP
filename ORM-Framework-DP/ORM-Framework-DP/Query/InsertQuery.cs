using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Framework_DP
{
    public class InsertQuery<T>: NonQuery<T> where T: new()
    {
        private T obj;
        public InsertQuery(T obj,DBConnection dBConnection, NonQueryBuilder nonQueryBuilder, AttributeHelper<T> attributeHelper) :base(dBConnection,nonQueryBuilder, attributeHelper) {
            this.obj = obj;
        }

        public override int Execute()
        {
            string tableName = attributeHelper.GetTableName();
            List<string> columnNames = attributeHelper.GetColumnNames();
            List<object> values = attributeHelper.GetColumnValues(obj);

            string query = queryBuilder.BuildInsert(tableName, columnNames,values);

            return dBConnection.Insert(query);
        }
    }
}

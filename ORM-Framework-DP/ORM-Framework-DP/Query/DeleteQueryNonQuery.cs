using System.Collections.Generic;

namespace ORM_Framework_DP
{
    public class DeleteQueryNonQuery<T> : NonQuery<T> where T : new()
    {
        private T obj;
        public DeleteQueryNonQuery(T obj, DBConnection dBConnection, NonQueryBuilder queryBuilder, AttributeHelper<T> attributeHelper) : base(dBConnection, queryBuilder, attributeHelper)
        {
            this.obj = obj;
        }
        public override int Execute()
        {
            string tableName = attributeHelper.GetTableName();
            List<string> columnNames = attributeHelper.GetColumnNames();
            List<object> values = attributeHelper.GetColumnValues(obj);

            string query = queryBuilder.BuildDelete(tableName, columnNames, values);

            return dBConnection.Delete(query);
        }
    }
}
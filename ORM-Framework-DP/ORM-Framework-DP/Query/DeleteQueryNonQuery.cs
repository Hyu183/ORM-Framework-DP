using System.Collections.Generic;

namespace ORM_Framework_DP
{
    public class DeleteQueryNonQuery<T> : NonQuery<T> where T : new()
    {
        private T obj;
        public DeleteQueryNonQuery(T obj, DBConnection dBConnection,  AttributeHelper<T> attributeHelper, DatabaseSyntax databaseSyntax) : base(dBConnection, attributeHelper, databaseSyntax)
        {
            this.obj = obj;
        }
        public override int Execute()
        {
            string tableName = attributeHelper.GetTableName();
            List<string> columnNames = attributeHelper.GetColumnNames();
            List<object> values = attributeHelper.GetColumnValues(obj);

            string query = databaseSyntax.BuildDelete(tableName, columnNames, values);

            return dBConnection.Delete(query);
        }
    }
}
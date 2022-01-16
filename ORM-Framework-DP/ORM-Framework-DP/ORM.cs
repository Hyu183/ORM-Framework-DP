using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORM_Framework_DP
{
    public class ORM<T> where T:new()
    {
        private DBConnection dBConnection;
        private QueryBuilder queryBuilder;
        private AttributeHelper<T> attributeHelper;

        public ORM(DBConnection dBConnection)
        {
            this.dBConnection = dBConnection;
            queryBuilder = new QueryBuilder();
            attributeHelper = new AttributeHelper<T>();
        }

        public InsertQuery<T> Insert(T obj)
        {
            return new InsertQuery<T>(obj,dBConnection, queryBuilder, attributeHelper);
        }

        public UpdateQueryBuilder<T> Update(T obj)
        {
            return new MySQLUpdateQueryBuilder<T>(dBConnection, attributeHelper);
        }

        public DeleteQueryNonQuery<T> Delete(T obj)
        {
            return new DeleteQueryNonQuery<T>(obj, dBConnection, queryBuilder, attributeHelper);
        }

        public DeleteQueryBuilder<T> Delete()
        {
            return new MySQLDeleteQueryBuilder<T>(dBConnection, attributeHelper);
        }

        public SelectQueryBuilder Select()
        {
            return new SelectQueryBuilder(dBConnection, 
                attributeHelper.GetTableName(), dBConnection.GetDatabaseSyntax());
        }
    }
}
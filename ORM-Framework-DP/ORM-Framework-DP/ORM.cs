using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORM_Framework_DP
{
    public class ORM<T> where T:new()
    {
        private DBConnection dBConnection;
        //private NonQueryBuilder nonQueryBuilder;
        private AttributeHelper<T> attributeHelper;

        public ORM(DBConnection dBConnection)
        {
            this.dBConnection = dBConnection;
            //this.nonQueryBuilder = nonQueryBuilder;
            attributeHelper = new AttributeHelper<T>();
        }

        public InsertQuery<T> Insert(T obj)
        {
            return new InsertQuery<T>(obj,dBConnection,attributeHelper, dBConnection.GetDatabaseSyntax());
        }

        public UpdateQuery<T> Update(T obj)
        {
            return new UpdateQuery<T>(obj, dBConnection, attributeHelper, dBConnection.GetDatabaseSyntax());
            //return new MySQLUpdateQueryBuilder<T>(dBConnection, attributeHelper);
        }

        public UpdateQuery<T> Update()
        {
            return new UpdateQuery<T>( dBConnection,attributeHelper, dBConnection.GetDatabaseSyntax());
            //return new MySQLUpdateQueryBuilder<T>(dBConnection, attributeHelper);
        }

        public DeleteQueryNonQuery<T> Delete(T obj)
        {
            return new DeleteQueryNonQuery<T>(obj, dBConnection,  attributeHelper, dBConnection.GetDatabaseSyntax());
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
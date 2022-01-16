using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORM_Framework_DP
{
    public class ORM<T> where T:new()
    {
        private DBConnection dBConnection;
        private NonQueryBuilder nonQueryBuilder;
        private AttributeHelper<T> attributeHelper;

        public ORM(DBConnection dBConnection, NonQueryBuilder nonQueryBuilder)
        {
            this.dBConnection = dBConnection;
            this.nonQueryBuilder = nonQueryBuilder;
            attributeHelper = new AttributeHelper<T>();
        }

        public InsertQuery<T> Insert(T obj)
        {
            return new InsertQuery<T>(obj,dBConnection, nonQueryBuilder, attributeHelper);
        }

        public UpdateQueryBuilder<T> Update(T obj)
        {
            return new MySQLUpdateQueryBuilder<T>(dBConnection, attributeHelper);
        }

        public DeleteQueryNonQuery<T> Delete(T obj)
        {
            return new DeleteQueryNonQuery<T>(obj, dBConnection, nonQueryBuilder, attributeHelper);
        }

        public DeleteQueryBuilder<T> Delete()
        {
            return new MySQLDeleteQueryBuilder<T>(dBConnection, attributeHelper);
        }

        public SelectQueryBuilder Select()
        {
            return new MySQLSelectQueryBuilder(dBConnection, attributeHelper.GetTableName());
        }
    }
}
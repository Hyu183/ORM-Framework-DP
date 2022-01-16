using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Framework_DP
{
    public class DeleteQuery<T>: NonQuery<T> where T: new()
    {
        private T obj;       
        private Condition condition = null;

        public DeleteQuery(T obj,DBConnection dBConnection,  AttributeHelper<T> attributeHelper, DatabaseSyntax databaseSyntax) :base(dBConnection, attributeHelper, databaseSyntax) {
            this.obj = obj;
        }

        public DeleteQuery(DBConnection dBConnection,  AttributeHelper<T> attributeHelper, DatabaseSyntax databaseSyntax) : base(dBConnection,  attributeHelper, databaseSyntax)
        {
            
        }

        

        public DeleteQuery<T> Where(Condition condition)
        {
            this.condition = condition;
            return this;
        }

        public override int Execute()
        {          
            string tableName = attributeHelper.GetTableName();        
            
            string query = "";
            if (condition == null)
            {
                
                Dictionary<string, object> primaryKeyValueMap = attributeHelper.GetPrimaryKeyValueMap(obj);


                query = databaseSyntax.BuildDelete(tableName, primaryKeyValueMap);
            }
            else { query = databaseSyntax.BuildDeleteWithCondition(tableName, condition); };


            return dBConnection.Delete(query);

        }
    }
}

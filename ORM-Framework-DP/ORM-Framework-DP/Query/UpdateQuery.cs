using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Framework_DP
{
    public class UpdateQuery<T>: NonQuery<T> where T: new()
    {
        private T obj;
        private Dictionary<string, object> newValuesMap = new Dictionary<string, object>(); 
        private Condition condition = null;

        public UpdateQuery(T obj,DBConnection dBConnection,  AttributeHelper<T> attributeHelper, DatabaseSyntax databaseSyntax) :base(dBConnection, attributeHelper, databaseSyntax) {
            this.obj = obj;
        }

        public UpdateQuery(DBConnection dBConnection,  AttributeHelper<T> attributeHelper, DatabaseSyntax databaseSyntax) : base(dBConnection,  attributeHelper, databaseSyntax)
        {
            
        }

        public UpdateQuery<T> Set(string colName, object newValue)
        {
            newValuesMap.Add(colName, newValue);
            return this;
        }

        public UpdateQuery<T> Where(Condition condition)
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
                Dictionary<string, object> newColumnValuesMap = attributeHelper.GetColumnValueMap(obj);
                Dictionary<string, object> primaryKeyValueMap = attributeHelper.GetPrimaryKeyValueMap(obj);


                query = databaseSyntax.BuildUpdate(tableName, primaryKeyValueMap, newColumnValuesMap );
            }
            else { query = databaseSyntax.BuildUpdateWithCondition(tableName,  newValuesMap, condition); };

            return dBConnection.Update(query);
           
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Framework_DP
{
    public abstract class NonQuery<T> where T: new()
    {
    
        protected DBConnection dBConnection;
        //protected NonQueryBuilder nonQueryBuilder;
        protected DatabaseSyntax databaseSyntax;
        protected AttributeHelper<T> attributeHelper;

        public NonQuery(DBConnection dBConnection, AttributeHelper<T> attributeHelper, DatabaseSyntax databaseSyntax)
        {           
            this.dBConnection = dBConnection;            
            this.attributeHelper = attributeHelper;
            this.databaseSyntax = databaseSyntax;
        }

        public abstract int Execute();
    }
}

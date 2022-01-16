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
        protected NonQueryBuilder queryBuilder;
        protected AttributeHelper<T> attributeHelper;

        public NonQuery(DBConnection dBConnection, NonQueryBuilder queryBuilder, AttributeHelper<T> attributeHelper)
        {           
            this.dBConnection = dBConnection;
            this.queryBuilder = queryBuilder;
            this.attributeHelper = attributeHelper;
        }

        public abstract int Execute();
    }
}

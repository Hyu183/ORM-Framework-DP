using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Framework_DP
{
    public class DeleteQuery<T> where T : new()
    {
        private string queryString;
        private DBConnection dBConnection;
        private AttributeHelper<T> attributeHelper;
        private Or condition = new Or();
        private string v;
        private AttributeHelper<T> attributeHelper1;

        public DeleteQuery(string v, DBConnection dBConnection, AttributeHelper<T> attributeHelper1)
        {
            this.v = v;
            this.dBConnection = dBConnection;
            this.attributeHelper1 = attributeHelper1;
        }

        public DeleteQuery(string queryString, DBConnection dBConnection, QueryBuilder queryBuilder, AttributeHelper<T> attributeHelper)
        {
            this.queryString = queryString;
            this.dBConnection = dBConnection;
            this.attributeHelper = attributeHelper;
        }

        public List<T> Execute()
        {
            Type type = null;
            Console.WriteLine(queryString);

            return dBConnection.Delete<T>(queryString, type, attributeHelper);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Framework_DP
{
    public class SelectQuery<T> where T : new()
    {
        private string queryString;
        private DBConnection dBConnection;
        private AttributeHelper<T> attributeHelper;

        public SelectQuery(string queryString, DBConnection dBConnection, AttributeHelper<T> attributeHelper)
        {
            this.queryString = queryString;
            this.dBConnection = dBConnection;
            this.attributeHelper = attributeHelper;
        }

        public List<T> Execute()
        {
            Type type = null;
            Console.WriteLine(queryString);

            return dBConnection.Select<T>(queryString, type, attributeHelper);
        }
    }
}

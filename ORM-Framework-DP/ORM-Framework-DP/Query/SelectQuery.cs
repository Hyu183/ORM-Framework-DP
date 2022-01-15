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

        public SelectQuery(string queryString, DBConnection dBConnection)
        {
            this.queryString = queryString;
            this.dBConnection = dBConnection;
        }

        public List<T> Execute()
        {
            string query = "SELECT * FROM company;";
            Type type = null;

            return dBConnection.Select(query, type);
        }
    }
}

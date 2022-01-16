using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Framework_DP
{
    public class _UpdateQuery<T> where T : new()
    {
        private string queryString;
        private DBConnection dBConnection;
        private AttributeHelper<T> attributeHelper;
        private Or condition = new Or();
        private string v;
        private AttributeHelper<T> attributeHelper1;

        public _UpdateQuery(string v, DBConnection dBConnection, AttributeHelper<T> attributeHelper1)
        {
            this.v = v;
            this.dBConnection = dBConnection;
            this.attributeHelper1 = attributeHelper1;
        }

        //public _UpdateQuery(string queryString, DBConnection dBConnection,   AttributeHelper<T> attributeHelper)
        //{
        //    this.queryString = queryString;
        //    this.dBConnection = dBConnection;
        //    this.attributeHelper = attributeHelper;
        //}

        public int Execute()
        {
            Type type = null;

            //return dBConnection.Update<T>(queryString, type, attributeHelper);
            return 0;
        }
    }
}

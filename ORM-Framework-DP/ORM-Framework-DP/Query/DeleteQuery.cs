using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Framework_DP
{
    public class DeleteQuery<T> where T : new()
    {
        private DBConnection dBConnection;
        private Or condition = new Or();
        private string v;
        private AttributeHelper<T> attributeHelper1;

        public DeleteQuery(string v, DBConnection dBConnection, AttributeHelper<T> attributeHelper1)
        {
            this.v = v;
            this.dBConnection = dBConnection;
            this.attributeHelper1 = attributeHelper1;
        }

        public int Execute()
        {
            Type type = null;
            return dBConnection.Delete(v);
        }
    }
}

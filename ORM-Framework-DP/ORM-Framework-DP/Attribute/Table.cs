using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Framework_DP
{
    public  class Table:Attribute
    {
        public string TableName { get; set; }
        public Table(string tableName)
        {
            TableName = tableName;
        }
    }
}

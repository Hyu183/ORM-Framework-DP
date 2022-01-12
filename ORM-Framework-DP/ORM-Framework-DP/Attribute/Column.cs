using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Framework_DP
{
    public class Column : Attribute
    {
        public string ColumnName { get; set; }
        public Column(string columnName)
        {
            ColumnName = columnName;
        }
    }
}

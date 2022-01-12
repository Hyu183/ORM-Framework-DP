using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Framework_DP
{
    class PrimaryKey:Attribute
    {
        public string PrimaryKeyName { get; set; }
        public PrimaryKey(string primaryKeyName)
        {
            PrimaryKeyName = primaryKeyName;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Framework_DP
{
    [Table("tax_code")]
    public class TaxCode
    {
        [PrimaryKey("id")]
        [Column("id")]
        public int ID { get; set; }

        [Column("code_name")]
        public string CodeName { get; set; }

        public TaxCode(int iD, string codeName)
        {
            ID = iD;
            CodeName = codeName;
        }

        public TaxCode(string codeName)
        {
            CodeName = codeName;
        }

        public TaxCode() { }
    }
}

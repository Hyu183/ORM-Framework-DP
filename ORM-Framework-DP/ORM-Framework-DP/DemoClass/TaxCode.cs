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

        public TaxCode(string codeName)
        {
            CodeName = codeName;
        }

        public TaxCode() { }
        public TaxCode(int iD, string codeName)
        {
            ID = iD;
            CodeName = codeName;
        }
        public string toString()
        {
            return string.Format(
                    "id: {0}\n" +
                    "name: {1}\n",
                    ID, CodeName);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Framework_DP
{
    [Table("company")]
    public class Company
    {
        [PrimaryKey("id")]
        [Column("id")]
        public int ID { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("num_of_employee")]
        public int NumOfEmployee { get; set; }

        [Column("established_date")]
        public DateTime EstablishedDate { get; set; }

        [HasMany("employee", "ID=company_id")]
        public List<Employee> Employees { get; set; }

        [Column("tax_code_id")]
        public int TaxCodeID { get; set; }

        [HasOne("tax_code", "TaxCodeID=id")]
        public TaxCode TaxCode { get; set; }

        public Company() { }

        public Company( string name, int numOfEmployee, DateTime establishedDate, int taxCodeID)
        {            
            Name = name;
            NumOfEmployee = numOfEmployee;
            EstablishedDate = establishedDate;
            TaxCodeID = taxCodeID;
        }

        public Company(int iD, string name, int numOfEmployee, DateTime establishedDate, int taxCodeID)
        {
            ID = iD;
            Name = name;
            NumOfEmployee = numOfEmployee;
            EstablishedDate = establishedDate;
            TaxCodeID = taxCodeID;
        }
    }
}

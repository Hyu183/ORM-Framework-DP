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

        // attribute_name=target_colume_name
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


        public string toString()
        {
            //string listEmployeeString = "---Employee list:\n";
            //foreach(Employee employee in Employees)
            //{
            //    listEmployeeString += employee.toString();
            //}
            //listEmployeeString += "--------------\n";

            return 
                string.Format(
                    "id: {0}\n" +
                    "name: {1}\n" +
                    "NumOfEmployee: {2}\n" +
                    "EstablishedDate: {3}\n" +
                    "TaxCodeID: {4}\n" +
                    "TaxCode: {5}\n"
                    , 
                    ID, Name, NumOfEmployee, EstablishedDate.ToString(),
                    TaxCodeID, TaxCode.toString()
                    //TaxCodeID, TaxCode.toString(), listEmployeeString
                    );
        }
    }
}

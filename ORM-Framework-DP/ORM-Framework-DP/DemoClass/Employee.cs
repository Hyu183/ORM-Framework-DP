using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Framework_DP
{
    [Table("employee")]
    public class Employee
    {
        [PrimaryKey("id")]
        [Column("id")]
        public int ID { get; set; }

        [Column("name")]
        public string Name { get; set; }
                
        [Column("sex")]
        public string Sex { get; set; }

        [Column("age")]
        public int Age { get; set; }

        [Column("salary")]
        public int Salary { get; set; }

        [Column("company_id")]
        public int CompanyID { get; set; }

        public Employee() { }

        public Employee( string name, string sex, int age, int salary, int companyID)
        {            
            Name = name;
            Sex = sex;
            Age = age;
            Salary = salary;
            CompanyID = companyID;
        }

        public Employee(int iD, string name, string sex, int age, int salary, int companyID)
        {
            ID = iD;
            Name = name;
            Sex = sex;
            Age = age;
            Salary = salary;
            CompanyID = companyID;
        }

        public string toString()
        {
            return string.Format(
                    "id: {0}\n" +
                    "name: {1}\n" +
                    "sex: {2}\n" +
                    "age: {3}\n" +
                    "salary: {2}\n" +
                    "companyID: {3}\n--------\n",
                    ID, Name, Sex, Age, Salary, CompanyID);
        }

    }
}

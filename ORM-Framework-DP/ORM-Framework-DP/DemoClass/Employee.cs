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

        public void toString()
        {
            Console.WriteLine("Employee: {0}", ID);
            Console.WriteLine("Name: {0}", Name);
            Console.WriteLine("Sex: {0}", Sex);
            Console.WriteLine("Age: {0}", Age);
            Console.WriteLine("Salary: {0}", Salary);
            Console.WriteLine("CompanyID: {0}", CompanyID);
        }

    }
}

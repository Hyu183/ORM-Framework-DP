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

        public Company() { }

        public Company( string name, int numOfEmployee, DateTime establishedDate)
        {            
            Name = name;
            NumOfEmployee = numOfEmployee;
            EstablishedDate = establishedDate;
        }

        public Company(int iD, string name, int numOfEmployee, DateTime establishedDate)
        {
            ID = iD;
            Name = name;
            NumOfEmployee = numOfEmployee;
            EstablishedDate = establishedDate;
        }
    }
}

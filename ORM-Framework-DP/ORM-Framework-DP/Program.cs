using System;

using System.Collections.Generic;
using System.Reflection;
using MySql.Data.MySqlClient;

namespace ORM_Framework_DP
{
    class Program
    {
        static void Main(string[] args)
        {
            DBConnection dBConnection = new SQLserverConnection("DESKTOP-JG2PKFM\\SQLEXPRESS", "company", "", "DESKTOP-JG2PKFM\\DinhKhoi", "");

            ORM<Employee> orm1 = new ORM<Employee>(dBConnection);

            Employee e = new Employee(11, "Nguyen Thi A", "Female", 20, 1000, 1);

            // Insert
            orm1.Insert(e).Execute();

            // Update by object
            //e.Age = 30;
            //orm1.Update(e).Execute();

            // Update using where
            //orm1.Update().Set("salary", 2800).Where(Condition.Equal("company_id", 1)).Execute();


            // Delete by object
            //orm1.Delete(e).Execute();


            //ORM<Company> orm3 = new ORM<Company>(dBConnection);
            //List<Company> companies = orm3.Select().Where(Condition.GreaterThan("id", 0))
            //    .GroupBy("tax_code_id")
            //    .Having(Condition.GreaterThan("name", 1, "COUNT"))
            //    .GetSelectQuery().Execute<Company>();


            //foreach (Company company in companies)
            //{
            //    Console.WriteLine(company.toString());
            //}

            //ORM<TaxCode> ormTaxCode = new ORM<TaxCode>(dBConnection);
            //TaxCode tax = new TaxCode("CFF229");
            //ormTaxCode.Insert(tax).Execute();

            //Condition use
            //Console.WriteLine(Condition.GreaterThan("id", 1).parseToSQL());

            //Console.WriteLine(Condition.And(new List<Condition> { Condition.GreaterThan("id", 1), 
            //    Condition.Equal("name", "Facebook"), Condition.Or(new List<Condition> { Condition.Equal("name", "Facebook"), 
            //        Condition.Equal("name", "Facebook") }) }).parseToSQL());


            dBConnection.Close();
        }
    }
}

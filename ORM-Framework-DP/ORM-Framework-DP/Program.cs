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
            //test insert employee
            DatabaseSyntax databaseSyntax = new MySQLSyntax();
            DBConnection dBConnection = new DBConnection("localhost","company","3360","root","root", databaseSyntax);
            //ORM<Employee> orm = new ORM<Employee>(dBConnection);
            //Employee employee1 = new Employee(6,"ABCD", "Male", 22, 9999, 1);
            //orm.Insert(employee1).Execute();


            //test insert company
            ORM<Company> orm2 = new ORM<Company>(dBConnection);
            //Company company1 = new Company("Arizona",26000,DateTime.Now);

            ////orm2.Insert(company1).Execute();
            orm2.Update(company1).Execute();
            //orm2.Update().Set("name","HEHEH").Where(Condition.Equal("name", "Updated")).Execute();

            List<Company> companies = orm2.Select().Where(Condition.Equal("id", 1))
               .GetSelectQuery().Execute<Company>();

            //orm2.Delete().Where("name = 'Arizona'").GetDeleteQuery().Execute();


            foreach (Company company in companies)
            {
                Console.WriteLine(company.Name);
            }

            //ORM<TaxCode> ormTaxCode = new ORM<TaxCode>(dBConnection);
            //TaxCode tax = new TaxCode("CFF229");
            //ormTaxCode.Insert(tax).Execute();

            //Condition use
            //Console.WriteLine(Condition.GreaterThan("id", 1).parseToSQL());

            //Console.WriteLine(Condition.And(new List<Condition> { Condition.GreaterThan("id", 1), Condition.Equal("name", "Facebook"), Condition.Or(new List<Condition> { Condition.Equal("name", "Facebook"), Condition.Equal("name", "Facebook") }) }).parseToSQL());


            dBConnection.Close();           


            //orm.Insert(employee);

            ////orm.Update(employee);

            //orm.Update().Set().Where();

            ////orm.Delete(employee);
            //orm.Delete().Where();

            //orm.Select().Where();
            //orm.Select().AddProjection().AddProjection().Where().GroupBy().AddProjection().Having().OrderBy();
        }
    }
}

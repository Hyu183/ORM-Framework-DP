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
            DBConnection dBConnection = new MySQLConnection("localhost","company","3360","root","");
            //ORM<Employee> orm = new ORM<Employee>(dBConnection);
            //Employee employee1 = new Employee(6,"ABCD", "Male", 22, 9999, 1);
            //orm.Insert(employee1).Execute();


            //test insert company
            NonQueryBuilder n = new MySQLNonQueryBuilder();
            ORM<Company> orm2 = new ORM<Company>(dBConnection,n);
            Company company1 = new Company(7, "Updated", 20000000, DateTime.Now, 1);
            //AttributeHelper<Company> h = new AttributeHelper<Company>();
            //var res = h.GetPrimaryKeyValueMap(company1);
            //foreach(var key in res.Keys)
            //{
            //    Console.WriteLine("{0}: {1}", key, res[key]);
            //}
            ////orm2.Insert(company1).Execute();
            orm2.Update(company1).Execute();
            //orm2.Update().Set("name","HEHEH").Where(Condition.Equal("name", "Updated")).Execute();

            //List<Company> companies = orm2.Select().Where("id > 1").GroupBy("name")
            //   .Having("count(id) > 2").GetSelectQuery().Execute<Company>();

            //List<Company> companies = orm2.Select().Where("id = 1").GroupBy("name")
            //    .GetSelectQuery().Execute<Company>();

            //orm2.Delete().Where("name = 'Arizona'").GetDeleteQuery().Execute();


            //foreach (Company company in companies)
            //{
            //    Console.WriteLine(company.Name);
            //}

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

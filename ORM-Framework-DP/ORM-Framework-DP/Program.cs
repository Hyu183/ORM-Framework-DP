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
            DBConnection dBConnection = new MySQLConnection("localhost","company","3307","root","");
            //ORM<Employee> orm = new ORM<Employee>(dBConnection);
            //Employee employee1 = new Employee(6,"ABCD", "Male", 22, 9999, 1);
            //orm.Insert(employee1).Execute();


            //test insert company
            ORM<Company> orm2 = new ORM<Company>(dBConnection);
            Company company1 = new Company("Meta",20000,DateTime.Now);
            Company company11 = new Company("Arizona", 26000, DateTime.Now);
            orm2.Insert(company1).Execute();
            orm2.Insert(company11).Execute();
            orm2.Delete().Where("name = 'Arizona'").GetDeleteQuery().Execute();


            //orm2.Delete().Where();

            //orm2.Delete(company1).Execute();
            //TODO

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

using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;

namespace ORM_Framework_DP
{
    public interface DBConnection
    {
        List<object> SelectWithoutRelation(string query,string [] selectedCols);

        int Delete(string query);

        int Insert(string query);

        int Update(string query);
        DatabaseSyntax GetDatabaseSyntax();

        void Close();
        void Open();
    }
}
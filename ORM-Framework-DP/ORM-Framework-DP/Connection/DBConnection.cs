using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORM_Framework_DP
{
    public abstract class DBConnection
    {
        abstract public void Open();
        abstract public void Close();
        abstract public int Insert(string query);
        abstract public List<T> Update<T>(string queryString, Type type, AttributeHelper<T> attributeHelper) where T : new ();
        abstract public int Delete(string query);
        abstract public int Select(string query,Type type);
        abstract protected string CreateConnectionString(string host, string dbName,string port, string uid, string password);
    }
}
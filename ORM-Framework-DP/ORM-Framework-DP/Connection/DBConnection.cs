﻿using System;
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
        abstract public int Update(string query);
        abstract public int Delete(string query);
        abstract public List<T> Select<T>(string query,Type type, AttributeHelper<T> attributeHelper) where T : new();
        abstract public List<Dictionary<string, object>> SelectWithoutRelation(string query);
        abstract protected string CreateConnectionString(string host, string dbName,string port, string uid, string password);
        abstract public DBConnection clone();
    }
}
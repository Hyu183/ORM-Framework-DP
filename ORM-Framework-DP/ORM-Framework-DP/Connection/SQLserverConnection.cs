﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ORM_Framework_DP
{
    public class SQLserverConnection : DBConnection
    {
        private SqlConnection connection;
        private string connectionString;
        private DatabaseSyntax databaseSyntax;

        public SQLserverConnection(string host, string dbName, string uid, string port, string password)
        {
            databaseSyntax = new SQLserverSyntax();
            string cnnString = CreateConnectionString(host, dbName, uid, port, password);
            connectionString = cnnString;
            connection = new SqlConnection(cnnString);
            Open();
        }
        public void Open()
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }

        public void Close()
        {
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }
        protected string CreateConnectionString(string host, string dbName, string uid, string port, string password)
        {
            return databaseSyntax.GetConnectionString(host, dbName, uid, port, password);
        }
        private int ExecuteNonQuery(string query)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = query;
            return cmd.ExecuteNonQuery();
        }
        public List<object> SelectWithoutRelation(string query,string[] selectedCols)
        {
            Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = query;
            SqlDataReader r = command.ExecuteReader();

            List<object> res = new List<object>();
            

            if (selectedCols[0] == "*")
            {
               

                while (r.Read())
                {
                    Dictionary<string, object> columeNameValuePairs = new Dictionary<string, object>();
                    for (int inc = 0; inc < r.FieldCount; inc++)
                    {
                        string propName = r.GetName(inc);
                        columeNameValuePairs.Add(propName, r.GetValue(inc));
                    }
                    //((List<Dictionary<string, object>>)rowValues).Add(columeNameValuePairs);
                    res.Add(columeNameValuePairs);
                }
               
            }
            else
            {
                //rowValues = new List<Dictionary<string, string>>();

                while (r.Read())
                {
                    Dictionary<string, string> columeNameValuePairs = new Dictionary<string, string>();
                    for (int inc = 0; inc < r.FieldCount; inc++)
                    {
                        //string propName = r.GetName(inc);
                        //columeNameValuePairs.Add(propName, r.GetValue(inc));
                        string selectedColName = selectedCols[inc];
                        columeNameValuePairs.Add(selectedColName,r[inc].ToString());
                    }
                    res.Add(columeNameValuePairs);
                }
              
            }
            r.Close();

            return res;
        }

        public int Delete(string query)
        {
            return ExecuteNonQuery(query);
        }

        public int Insert(string query)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = query;
            //cmd.ExecuteNonQuery();
            
            return (int)cmd.ExecuteScalar();
        }

        public int Update(string query)
        {
            return ExecuteNonQuery(query);
        }

        public DatabaseSyntax GetDatabaseSyntax()
        {
            return databaseSyntax;
        }
    }
}

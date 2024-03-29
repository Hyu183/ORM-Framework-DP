﻿using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;

namespace ORM_Framework_DP
{
    public class MySQLConnection : DBConnection
    {
        private MySqlConnection connection;
        private string connectionString;
        private DatabaseSyntax databaseSyntax;

        public MySQLConnection(string host, string dbName,string port, string uid, string password)
        {
            databaseSyntax = new MySQLSyntax();
            string cnnString = CreateConnectionString(host,dbName,port,uid,password);
            connectionString = cnnString;
            connection = new MySqlConnection(cnnString);
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
            if(connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }
        
        protected string CreateConnectionString(string host, string dbName,string port, string uid, string password)
        {
            return databaseSyntax.GetConnectionString(host,dbName,port,uid,password);
        }

        private int ExecuteNonQuery(string query)
        {
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = query;
            return cmd.ExecuteNonQuery();
        }

        public List<object> SelectWithoutRelation(string query,string [] selectedCols)
        {
            Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = query;
            MySqlDataReader r = command.ExecuteReader();
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
                   
                    res.Add(columeNameValuePairs);
                }

            }
            else
            {
               

                while (r.Read())
                {
                    Dictionary<string, string> columeNameValuePairs = new Dictionary<string, string>();
                    for (int inc = 0; inc < r.FieldCount; inc++)
                    {
                        
                        string selectedColName = selectedCols[inc];
                        columeNameValuePairs.Add(selectedColName, r[inc].ToString());
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
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            return (int)cmd.LastInsertedId ;            
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
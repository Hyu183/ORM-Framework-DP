using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORM_Framework_DP
{
    public class MySQLConnection : DBConnection
    {
        private MySqlConnection connection;

        public MySQLConnection(string host, string dbName,string port, string uid, string password)
        {
            string cnnString = CreateConnectionString(host,dbName,port,uid,password);
            connection = new MySqlConnection(cnnString);
            Open();
        }

        public override void Open()
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }

        public override void Close()
        {
            if(connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }
        
        protected override string CreateConnectionString(string host, string dbName,string port, string uid, string password)
        {
            string cnnString = string.Format("Server={0}; Database = {1}; port = {2}; UID = {3}; password={4};", host,dbName,port,uid,password);
            return cnnString;
        }

        private int ExecuteNonQuery(string query)
        {
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = query;
            return cmd.ExecuteNonQuery();
        }

        public override int Delete(string query)
        {
            return ExecuteNonQuery(query);
        }

        public override int Insert(string query)
        {
            return ExecuteNonQuery(query);
        }

        public override int Update(string query)
        {
            return ExecuteNonQuery(query);
        }

        public override int Select(string query, Type type)
        {
            throw new NotImplementedException();
        }
    }
}
using MySql.Data.MySqlClient;
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

        private List<T> ExecuteQuery<T>(string query) where T : new()
        {
            //Open();
            //MySqlCommand cmd = connection.CreateCommand();
            //cmd.CommandText = query;
            //MySqlDataReader myReader;
            //myReader = cmd.ExecuteReader();
            //try
            //{
            //    while (myReader.Read())
            //    {
            //        int id = myReader.GetFieldValue<int>(0);
            //        string name = myReader.GetFieldValue<string>(1);
            //        DateTime dateTime = myReader.GetFieldValue<DateTime>(3);

            //        Console.WriteLine(name);
            //    }
            //}
            //finally
            //{
            //    Console.WriteLine("Yolo");
            //    Close();
            //}
            Open();
            List<T> res = new List<T>();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = query;
            MySqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                T t = new T();

                for (int inc = 0; inc < r.FieldCount; inc++)
                {
                    Type type = t.GetType();
                    PropertyInfo prop = type.GetProperty(r.GetName(inc));
                    prop.SetValue(t, Convert.ChangeType(r.GetValue(inc), prop.PropertyType), null);
                }

                res.Add(t);
            }
            r.Close();

            Close();
            return res;
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

        public override List<Object> Select(string query, Type type)
        {
            List<Object> list = new List<Object>();

            ExecuteQuery(query);

            return list;
        }
    }
}
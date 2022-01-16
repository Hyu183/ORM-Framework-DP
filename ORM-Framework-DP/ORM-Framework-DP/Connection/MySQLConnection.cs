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
        private string connectionString;

        public MySQLConnection(string host, string dbName,string port, string uid, string password)
        {
            string cnnString = CreateConnectionString(host,dbName,port,uid,password);
            connectionString = cnnString;
            connection = new MySqlConnection(cnnString);
            Open();
        }

        public MySQLConnection(string connectionString)
        {
            this.connectionString = connectionString;
            connection = new MySqlConnection(connectionString);
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

        //private List<T> ExecuteQuery<T>(string query, AttributeHelper<T> attributeHelper) where T : new()
        //{
        //    Open();
        //    List<T> res = new List<T>();
        //    MySqlCommand cmd = connection.CreateCommand();
        //    cmd.CommandText = query;
        //    MySqlDataReader r = cmd.ExecuteReader();
        //    while (r.Read())
        //    {
        //        Dictionary<string, object> columeNameValuePairs = new Dictionary<string, object>();

        //        for (int inc = 0; inc < r.FieldCount; inc++)
        //        {
        //            string propName = r.GetName(inc);
        //            columeNameValuePairs.Add(propName, r.GetValue(inc));
        //        }

        //        T t = attributeHelper.BuildObjectFromValues(columeNameValuePairs);

        //        Has Many
        //        List<HasMany> hasManies = attributeHelper.GetHasManyList();
        //        foreach (HasMany many in hasManies)
        //        {
        //            string whereCondition = " WHERE 1";
        //            foreach (var pk in many.PKPairsDic)
        //            {
        //                whereCondition += " AND ";
        //                string propName = pk.Key;
        //                string targetColumeName = pk.Value;
        //                var value = attributeHelper.GetValue(t, propName);
        //                whereCondition += string.Format(" {0}={1} ", targetColumeName, value.ToString());
        //            }
        //            whereCondition += ";";
        //            string manyQuery = string.Format("SELECT * FROM {0} {1}", many.TableName, whereCondition);

        //            Type manyType = many.propertyInfo.PropertyType;
        //            Type itemType = manyType.GetGenericArguments()[0];

        //            MethodInfo method =
        //            typeof(MySQLConnection).GetMethod(nameof(MySQLConnection.SelectNoRelation))
        //                .MakeGenericMethod(itemType);


        //            many.propertyInfo.SetValue(t, method
        //                .Invoke(new MySQLConnection(this.connectionString), new object[] { manyQuery }));
        //        }

        //        res.Add(t);
        //    }
        //    r.Close();

        //    Close();
        //    return res;
        //}

        //public List<T> SelectNoRelation<T>(string query) where T : new()
        //{
        //    Open();
        //    AttributeHelper<T> attributeHelper = new AttributeHelper<T>();
        //    List<T> manyList = new List<T>();
        //    MySqlCommand command = connection.CreateCommand();
        //    command.CommandText = query;
        //    MySqlDataReader r = command.ExecuteReader();

        //    while (r.Read())
        //    {
        //        Dictionary<string, object> manyColumeNameValuePairs = new Dictionary<string, object>();
        //        for (int inc = 0; inc < r.FieldCount; inc++)
        //        {
        //            string propName = r.GetName(inc);
        //            manyColumeNameValuePairs.Add(propName, r.GetValue(inc));
        //        }
        //        T o = attributeHelper.BuildObjectFromValues(manyColumeNameValuePairs);
        //        manyList.Add(o);
        //    }
        //    Close();

        //    return manyList;
        //}

        override
        public List<Dictionary<string,object>> SelectWithoutRelation(string query)
        {
            Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = query;
            MySqlDataReader r = command.ExecuteReader();

            List<Dictionary<string, object>> rowValues = new List<Dictionary<string, object>>();

            while (r.Read())
            {
                Dictionary<string, object> columeNameValuePairs = new Dictionary<string, object>();
                for (int inc = 0; inc < r.FieldCount; inc++)
                {
                    string propName = r.GetName(inc);
                    columeNameValuePairs.Add(propName, r.GetValue(inc));
                }
                rowValues.Add(columeNameValuePairs);
            }
            Close();

            return rowValues;
        }

        public override int Delete(string query)
        {
            return ExecuteNonQuery(query);
        }

        public override int Insert(string query)
        {
            return ExecuteNonQuery(query);
        }

        public override List<T> Update<T>(string query, Type type, AttributeHelper<T> attributeHelper)
        {
            return ExecuteQuery<T>(query, attributeHelper);
        }

        public override List<T> Select<T>(string query, Type type, AttributeHelper<T> attributeHelper)
        {
            //return ExecuteQuery<T>(query, attributeHelper);
            return null;

        }

        public override DBConnection clone()
        {
            return new MySQLConnection(connectionString);
        }
    }
}
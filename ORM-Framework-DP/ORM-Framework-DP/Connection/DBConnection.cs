using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;

namespace ORM_Framework_DP
{
    public class DBConnection
    {
        private MySqlConnection connection;
        private string connectionString;
        private DatabaseSyntax databaseSyntax;

        public DBConnection(string host, string dbName,string port, string uid, string password, DatabaseSyntax syntax)
        {
            databaseSyntax = syntax;
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
            r.Close();

            return rowValues;
        }

        public int Delete(string query)
        {
            return ExecuteNonQuery(query);
        }

        public int Insert(string query)
        {
            return ExecuteNonQuery(query);
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
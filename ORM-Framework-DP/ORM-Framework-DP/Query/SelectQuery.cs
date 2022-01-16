using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Framework_DP
{
    public class SelectQuery
    {
        private string queryString;
        private DBConnection dBConnection;
        private DatabaseSyntax databaseSyntax;

        public SelectQuery(string queryString, DBConnection dBConnection,
            DatabaseSyntax databaseSyntax)
        {
            this.queryString = queryString;
            this.dBConnection = dBConnection;
            this.databaseSyntax = databaseSyntax;
        }

        public List<T> Execute<T>() where T : new()
        {
            List<T> result = new List<T>();
            AttributeHelper<T> attHelper = new AttributeHelper<T>();
            List<Dictionary<string, object>> rowValues = dBConnection.SelectWithoutRelation(queryString);
            foreach (var rowValue in rowValues)
            {
                T t = attHelper.BuildObjectFromValues(rowValue);
                t = SelectHasN(attHelper.GetHasNList(typeof(HasMany)), t, nameof(SelectQuery.ExecuteNoRelation),
                    (nType) => nType.GetGenericArguments()[0]);
                t = SelectHasN(attHelper.GetHasNList(typeof(HasOne)), t, nameof(SelectQuery.ExecuteGetOne),
                    (nType) => nType);
                result.Add(t);
            }

            return result;
        }

        public List<T> ExecuteNoRelation<T>() where T : new()
        {
            List<T> result = new List<T>();
            AttributeHelper<T> attHelper = new AttributeHelper<T>();
            List<Dictionary<string, object>> rowValues = dBConnection.SelectWithoutRelation(queryString);
            foreach (var rowValue in rowValues)
            {
                T t = attHelper.BuildObjectFromValues(rowValue);
                result.Add(t);
            }

            return result;
        }


        public T ExecuteGetOne<T>() where T : new()
        {
            AttributeHelper<T> attHelper = new AttributeHelper<T>();
            List<Dictionary<string, object>> rowValues = dBConnection.SelectWithoutRelation(queryString);
            foreach (var rowValue in rowValues)
            {
                T t = attHelper.BuildObjectFromValues(rowValue);
                return t;
            }

            return new T();
        }

        private T SelectHasN<T>(List<HasN> oneList, T obj, string methodString, Func<Type, Type> calculateItemType) where T : new()
        {
            AttributeHelper<T> attHelper = new AttributeHelper<T>();
            foreach (HasN one in oneList)
            {
                Dictionary<string, string> valuePairs
                    = new Dictionary<string, string>();
                foreach (var pk in one.PKPairsDic)
                {
                    string propName = pk.Key;
                    string targetColumeName = pk.Value;
                    string value = attHelper.GetValue(obj, propName).ToString();
                    valuePairs.Add(targetColumeName, value);

                }
                string oneQuery = databaseSyntax.BuildSelectWhereFromValuePairs(valuePairs, one.TableName);

                //Type itemType = one.propertyInfo.PropertyType;
                Type itemType = calculateItemType(one.propertyInfo.PropertyType);

                MethodInfo method =
                typeof(SelectQuery).GetMethod(methodString)
                    .MakeGenericMethod(itemType);

                one.propertyInfo.SetValue(obj, method
                    .Invoke(new SelectQuery(oneQuery, dBConnection, databaseSyntax), null));
            }

            return obj;
        }
    }
}

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
        private SelectQueryBuilder queryBuilder;

        public SelectQuery(string queryString, DBConnection dBConnection,
            SelectQueryBuilder selectQueryBuilder)
        {
            this.queryString = queryString;
            this.dBConnection = dBConnection;
            this.queryBuilder = selectQueryBuilder;
        }

        public List<T> Execute<T>() where T : new()
        {
            List<T> result = new List<T>();
            AttributeHelper<T> attHelper = new AttributeHelper<T>();
            List<Dictionary<string, object>> rowValues = dBConnection.SelectWithoutRelation(queryString);
            foreach (var rowValue in rowValues)
            {
                T t = attHelper.BuildObjectFromValues(rowValue);
                t = SelectHasMany(attHelper.GetHasManyList(), t);
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

        private T SelectHasMany<T>(List<HasMany> manyList, T obj) where T : new()
        {
            AttributeHelper<T> attHelper = new AttributeHelper<T>();
            foreach (HasMany many in manyList)
            {
                Dictionary<string, string> valuePairs
                    = new Dictionary<string, string>();
                foreach (var pk in many.PKPairsDic)
                {
                    string propName = pk.Key;
                    string targetColumeName = pk.Value;
                    string value = attHelper.GetValue(obj, propName).ToString();
                    valuePairs.Add(propName, value);

                }
                string manyQuery = queryBuilder.BuildSelectWhereFromValuePairs(valuePairs, many.TableName);

                Type manyType = many.propertyInfo.PropertyType;
                Type itemType = manyType.GetGenericArguments()[0];

                //MethodInfo method =
                //typeof(MySQLConnection).GetMethod(nameof(MySQLConnection.SelectNoRelation))
                //    .MakeGenericMethod(itemType);

                SelectQuery selectQuery = new SelectQuery(queryString, dBConnection, queryBuilder);

                MethodInfo method =
                typeof(SelectQuery).GetMethod(nameof(SelectQuery.ExecuteNoRelation))
                    .MakeGenericMethod(itemType);


                many.propertyInfo.SetValue(obj, method
                    .Invoke(new SelectQuery(manyQuery, dBConnection, queryBuilder), null));
            }

            return obj;
        }
    }
}

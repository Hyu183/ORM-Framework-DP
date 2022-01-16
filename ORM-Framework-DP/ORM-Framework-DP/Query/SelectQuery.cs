using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Framework_DP
{
    public class SelectQuery<T> where T : new()
    {
        private string queryString;
        private DBConnection dBConnection;
        private AttributeHelper<T> attributeHelper;
        private SelectQueryBuilder<T> queryBuilder;

        public SelectQuery(string queryString, DBConnection dBConnection, AttributeHelper<T> attributeHelper,
            SelectQueryBuilder<T> selectQueryBuilder)
        {
            this.queryString = queryString;
            this.dBConnection = dBConnection;
            this.attributeHelper = attributeHelper;
            this.queryBuilder = selectQueryBuilder;
        }

        public List<T> Execute()
        {
            List<T> result = new List<T>();
            List<Dictionary<string, object>> rowValues = dBConnection.SelectWithoutRelation(queryString);
            foreach (var rowValue in rowValues)
            {
                T t = attributeHelper.BuildObjectFromValues(rowValue);
                t = SelectHasMany(attributeHelper.GetHasManyList(), t);
                result.Add(t);
            }

            return result;
        }

        public List<T> ExecuteNoRelation()
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

        private T SelectHasMany(List<HasMany> manyList, T obj)
        {
            foreach (HasMany many in manyList)
            {
                Dictionary<string, string> valuePairs
                    = new Dictionary<string, string>();
                foreach (var pk in many.PKPairsDic)
                {
                    string propName = pk.Key;
                    string targetColumeName = pk.Value;
                    string value = attributeHelper.GetValue(obj, propName).ToString();
                    valuePairs.Add(propName, value);

                }
                string manyQuery = queryBuilder.BuildSelectWhereFromValuePairs(valuePairs, many.TableName);

                Type manyType = many.propertyInfo.PropertyType;
                Type itemType = manyType.GetGenericArguments()[0];

                MethodInfo method =
                typeof(MySQLConnection).GetMethod(nameof(MySQLConnection.SelectNoRelation))
                    .MakeGenericMethod(itemType);

                SelectQuery selectQuery = new SelectQuery(queryString, dBConnection, null, queryBuilder);

                MethodInfo method =
                typeof(SelectQuery).GetMethod(nameof(SelectQuery.ExecuteNoRelation))
                    .MakeGenericMethod(itemType);


                many.propertyInfo.SetValue(obj, method
                    .Invoke(new SelectQuery(queryString, dBConnection, null, queryBuilder), new object[] { manyQuery }));
            }

            return obj;
        }
    }
}

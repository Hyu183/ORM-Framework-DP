using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Framework_DP
{
    public interface DatabaseSyntax
    {
        string GetConnectionString(string host, string dbName, string port, string uid, string password);
        string GetWherePart(Condition condition);
        string GetOr();
        string GetAnd();
        string GetSelectAllPart(string tableName);
        string GetGroupByPart(string[] columeNames);
        string GetHavingPart(Condition condition);
        string BuildSelectWhereFromValuePairs(Dictionary<string, string> columeNameValuePairs, string tableName);
        string ConvertValueToString(object value, Type type);

        string BuildQuery(string tableName, Condition whereConditon, 
            Condition havingCondition, string[] groupByColumeNames);

    }
}

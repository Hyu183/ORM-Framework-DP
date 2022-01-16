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
        string GetWherePart(string condition);
        string GetOr();
        string GetAnd();
        string GetSelectAllPart(string tableName);
        string GetGroupByPart(List<string> columeNames);
        string GetHavingPart(string condition);
        string BuildSelectWhereFromValuePairs(Dictionary<string, string> columeNameValuePairs, string tableName);
        string ConvertValueToString(object value, Type type);

    }
}

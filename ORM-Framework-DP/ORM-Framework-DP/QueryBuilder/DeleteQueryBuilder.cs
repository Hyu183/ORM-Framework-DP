using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Framework_DP
{
    public abstract class DeleteQueryBuilder<T> where T : new()
    {
        protected string tableName;
        protected string condition;
        protected string orderByType;
        protected string column;
        protected string value;
        AttributeHelper<T> attributeHelper;

        protected DBConnection dBConnection;

        public DeleteQueryBuilder(DBConnection db, AttributeHelper<T> attributeHelper)
        {
            dBConnection = db;
            this.attributeHelper = attributeHelper;
            tableName = attributeHelper.GetTableName();
        }

        public DeleteQueryBuilder<T> Where(string condition)
        {
            this.condition = condition;
            return this;
        }

        public abstract string getQueryString(Dictionary<string, string> featureMap);

        public DeleteQuery<T> GetDeleteQuery()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            Console.WriteLine("values");
            Console.WriteLine(values);
            Console.WriteLine(getQueryString(values));
            return new DeleteQuery<T>(getQueryString(values), dBConnection, attributeHelper);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Framework_DP
{
    public abstract class UpdateQueryBuilder<T> where T : new()
    {
        protected string tableName;
        protected string condition;
        protected string orderByType;
        protected string column;
        protected string value;
        AttributeHelper<T> attributeHelper;

        protected DBConnection dBConnection;

        public UpdateQueryBuilder(DBConnection db, AttributeHelper<T> attributeHelper)
        {
            dBConnection = db;
            this.attributeHelper = attributeHelper;
            tableName = attributeHelper.GetTableName();
        }

        public UpdateQueryBuilder<T> Where(string condition)
        {
            this.condition = condition;
            return this;
        }

        public UpdateQueryBuilder<T> Set(string column, string value)
        {
            this.column = column;
            this.value = value;
            return this;
        }

        public abstract string getQueryString(Dictionary<string, string> featureMap);

        public _UpdateQuery<T> GetUpdateQuery()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            return new _UpdateQuery<T>(getQueryString(values), dBConnection, attributeHelper);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORM_Framework_DP
{
    public abstract class SelectQueryBuilder
    {
        protected string tableName;
        //protected Condition condition;
        protected string orderByType;
        protected string groupBy;
        //protected Condition havingCondition;

        protected DBConnection dBConnection;

        public SelectQueryBuilder(DBConnection db, string tableName)
        {
            dBConnection = db;
            this.tableName = tableName;
        }

        public SelectQueryBuilder Where()
        {
            return this;
        }

        public SelectQueryBuilder GroupBy(String groupBy)
        {
            this.groupBy = groupBy;
            return this;
        }

        public abstract string getQueryString(Dictionary<string, string> featureMap);

        public SelectQuery GetSelectQuery()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            return new SelectQuery(getQueryString(dic), dBConnection);
        }

    }
}
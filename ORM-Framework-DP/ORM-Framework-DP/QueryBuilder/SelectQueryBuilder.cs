﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORM_Framework_DP
{
    public abstract class SelectQueryBuilder<T> where T : new()
    {
        protected string tableName;
        //protected Condition condition;
        protected string condition;
        protected string orderByType;
        protected string groupBy;
        protected string having;
        //protected Condition havingCondition;
        AttributeHelper<T> attributeHelper;

        protected DBConnection dBConnection;

        public SelectQueryBuilder(DBConnection db, AttributeHelper<T> attributeHelper)
        {
            dBConnection = db;
            this.attributeHelper = attributeHelper;
            tableName = attributeHelper.GetTableName();
        }

        public SelectQueryBuilder<T> Where(string condition)
        {
            this.condition = condition;
            return this;
        }

        public SelectQueryBuilder<T> GroupBy(String groupBy)
        {
            this.groupBy = groupBy;
            return this;
        }

        public SelectQueryBuilder<T> Having(String having)
        {
            this.having = having;
            return this;
        }

        public abstract string getQueryString(Dictionary<string, string> featureMap);

        public abstract string BuildSelectWhereFromValuePairs(Dictionary<string, string> columeNameValuePairs, string tableName);

        public SelectQuery<T> GetSelectQuery()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            return new SelectQuery<T>(getQueryString(dic), dBConnection, attributeHelper, this);
        }

    }
}
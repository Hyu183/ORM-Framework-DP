﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORM_Framework_DP
{
    public class SelectQueryBuilder
    {
        protected string tableName;
        protected Condition whereCondition;
        protected string orderByType;
        protected string[] groupBy;
        protected Condition havingCondition;
        protected string[] selectedCols;
        DatabaseSyntax databaseSyntax;

        protected DBConnection dBConnection;

        //public SelectQueryBuilder(DBConnection db, string tableName, DatabaseSyntax databaseSyntax)
        //{
        //    dBConnection = db;
        //    this.databaseSyntax = databaseSyntax;
        //    this.tableName = tableName;

        //    whereCondition = null;
        //    havingCondition = null;
        //    groupBy = null;
        //}
        public SelectQueryBuilder(DBConnection db, string tableName, string[] selectedCols, DatabaseSyntax databaseSyntax)
        {
            dBConnection = db;
            this.databaseSyntax = databaseSyntax;
            this.tableName = tableName;
            this.selectedCols = selectedCols;
            whereCondition = null;
            havingCondition = null;
            groupBy = null;
        }

        public SelectQueryBuilder Where(Condition condition)
        {
            this.whereCondition = condition;
            return this;
        }

        public SelectQueryBuilder GroupBy(params string[] groupBy)
        {
            this.groupBy = groupBy;
            return this;
        }

        public SelectQueryBuilder Having(Condition condition)
        {
            this.havingCondition = condition;
            return this;
        }

        //private string getQueryString()
        //{
        //    return databaseSyntax.BuildQuery(tableName, whereCondition, havingCondition, groupBy);
        //}

        private string getQueryString()
        {
            return databaseSyntax.BuildQuery(tableName, selectedCols, whereCondition, havingCondition, groupBy);
        }

        public SelectQuery GetSelectQuery()
        {            
            return new SelectQuery(getQueryString(), selectedCols, dBConnection, databaseSyntax);
        }

    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Framework_DP
{
    public class InsertQuery<T>: NonQuery<T> where T: new()
    {
        private T obj;
        public InsertQuery(T obj,DBConnection dBConnection, AttributeHelper<T> attributeHelper, DatabaseSyntax databaseSyntax) :base(dBConnection, attributeHelper, databaseSyntax) {
            this.obj = obj;
        }

        public override int Execute()
        {
            string tableName = attributeHelper.GetTableName();
            List<string> columnNames = attributeHelper.GetColumnNames();
            List<object> values = attributeHelper.GetColumnValues(obj);

            string query = databaseSyntax.BuildInsert(tableName, columnNames,values);

            return dBConnection.Insert(query);
        }
    }
}

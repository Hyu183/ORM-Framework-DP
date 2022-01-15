using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Framework_DP
{
    public class AttributeHelper<T> where T : new()
    {
        public string GetTableName()
        {
            Type type = typeof(T);
            Table table = (Table)type.GetCustomAttributes(typeof(Table), false)[0];
            return table.TableName;
        }

        public List<string> GetColumnNames()
        {
            Type type = typeof(T);
            var props =type.GetProperties();
            List<string> columnNames = new List<string>();
            foreach(var p in props)
            {
                
                Column col = p.GetCustomAttribute<Column>();
                if (col == null)
                {
                    continue;
                };

                columnNames.Add(col.ColumnName);
            }

            return columnNames;
        }

        public List<string> GetPrimaryKeyNames()
        {
            Type type = typeof(T);
            var props = type.GetProperties();
            List<string> primaryKeyNames = new List<string>();
            foreach (var p in props)
            {

                PrimaryKey pKey = p.GetCustomAttribute<PrimaryKey>();
                if (pKey == null)
                {
                    continue;
                };

                primaryKeyNames.Add(pKey.PrimaryKeyName);
            }

            return primaryKeyNames;
        }

        public List<string> GetPropertyNames()
        {
            Type type = typeof(T);
            var props = type.GetProperties();
            List<string> propNames = new List<string>();
            foreach (var p in props)
            {
                propNames.Add(p.Name);
            }

            return propNames;
        }

        public object GetValue(T obj, string columnName)
        {
            Type type = typeof(T);
            
            return type.GetProperty(columnName).GetValue(obj,null);
        }

        public List<object> GetColumnValues(T obj)
        {
            //Dictionary<string, object> values = new Dictionary<string, object>();
            List<object> values = new List<object>();
            List<string> props = GetPropertyNames();

            foreach(var col in props)
            {
                object objectValue = GetValue(obj, col);
                values.Add(objectValue);
            }


            return values;
        }

        public T DataToObject(List<string> data) 
        {
            T obj = new T();

            var props = obj.GetType().GetProperties();
            int dataIndex = 0;

            foreach (var prop in props)
            {
                prop.SetValue(obj, Convert.ChangeType(data[dataIndex++],prop.PropertyType));
            }

            return obj;
        }

        public List<HasMany> GetHasManyList()
        {
            Type type = typeof(T);
            var props = type.GetProperties();

            List<HasMany> listHasMany = new List<HasMany>();

            foreach (var p in props)
            {
                HasMany hasMany = p.GetCustomAttribute<HasMany>();
                if (hasMany == null)
                {
                    continue;
                };
                string[] pKPairs = hasMany.PKPairs;
                Dictionary<string, string> PKPairsDic = new Dictionary<string, string>();
                
                foreach(string k in pKPairs)
                {
                    string[] keys = k.Split('=');
                    PKPairsDic.Add(keys[0], keys[1]);
                }
                hasMany.PKPairsDic = PKPairsDic;

                hasMany.propertyInfo = p;
                listHasMany.Add(hasMany);

            }

            return listHasMany;
        }

        private string getColumeNameFromPropertyName(string propName)
        {
            Type type = typeof(T);
            var props = type.GetProperties();
            foreach (var p in props)
            {
                if (p.Name == propName)
                {
                    Column col = p.GetCustomAttribute<Column>();

                    if (col == null)
                    {
                        return null;
                    }

                    return col.ColumnName;
                }

            }
            return null;
        }

        public T BuildObjectFromValues(Dictionary<string, object> columeValuePair)
        {
            //Dictionary is pairs of colume names and values of these columes
            T obj = new T();

            var props = obj.GetType().GetProperties();

            foreach (var prop in props)
            {
                string columeName = getColumeNameFromPropertyName(prop.Name);
                if (columeName == null)
                {
                    continue;
                }

                object columeValue = columeValuePair[columeName];
                prop.SetValue(obj, Convert.ChangeType(columeValue, prop.PropertyType));
            }

            return obj;
        }
    }
}

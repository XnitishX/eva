using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace Common
{
    public class Utility
    {
        public static List<T> ConvertFromDataTable<T>(DataTable dt) where T : new()
        {
            var list = new List<T>();
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    var entity = new T();
                    foreach (PropertyInfo info in entity.GetType().GetProperties())
                    {
                        //check to make sure that the column exists and has the same data type
                        if (dt.Columns.Contains(info.Name))
                        {
                            if (dt.Columns[info.Name].DataType == info.PropertyType)
                            {
                                if (row[info.Name] != DBNull.Value)
                                {
                                    Type type = Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType;
                                    object value = Convert.ChangeType(row[info.Name], type);
                                    info.SetValue(entity, value, null);
                                }




                            }
                            else
                            {
                                throw new Exception(info.Name + " -> " + dt.Columns[info.Name].DataType.ToString() + " -> " + info.PropertyType.ToString());
                            }

                        }

                    }
                    list.Add(entity);
                }

            }
            catch
            {
                throw;
            }
            return list;
        }


        public static string Serialize<T>(T dataToSerialize)
        {
            try
            {
                var stringwriter = new System.IO.StringWriter();
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(stringwriter, dataToSerialize);
                return stringwriter.ToString();
            }
            catch
            {
                throw;
            }
        }


        public static T Deserialize<T>(string xmlText)
        {
            try
            {
                var stringReader = new System.IO.StringReader(xmlText);
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stringReader);
            }
            catch
            {
                throw;
            }
        }


    }
}

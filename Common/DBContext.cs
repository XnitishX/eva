using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.ComponentModel;
using System.Reflection;
using System.Data;


namespace Common
{
    public class DBContext
    {


        private string connectionString;
        private SqlConnection dbConnection;
        private SqlCommand objSQLCommand;
        private SqlDataReader objSQLReader;




        public string databaseConnection(Enums.SQLConnectionNames connName)
        {
            string SQLConnectionNames = getEnumDescription(connName);
            connectionString = ConfigurationManager.ConnectionStrings[SQLConnectionNames].ToString();
            return connectionString;
        }




        public static string getEnumDescription(Enum en)
        {
            Type type = en.GetType();
            MemberInfo[] info = type.GetMember(en.ToString());
            if (info != null && info.Length > 0)
            {
                object[] attrs = info[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return en.ToString();
        }






        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }


        public DataSet ExecuteQueryDataset(string spName, bool blncloseconnection, Enums.SQLConnectionNames connName, IDictionary<string, object> paramNames)
        {
            dbConnection = new SqlConnection(databaseConnection(connName));
            try
            {
                dbConnection.Open();
                objSQLCommand = new SqlCommand();
                objSQLCommand.Connection = dbConnection;
                objSQLCommand.CommandType = CommandType.StoredProcedure;
                objSQLCommand.CommandText = spName;
                if (paramNames != null)
                {
                    foreach (string item in paramNames.Keys)
                    {
                        object paramValue = paramNames[item];
                        objSQLCommand.Parameters.AddWithValue(item, paramValue ?? DBNull.Value);
                    }
                }
                System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(objSQLCommand);


                DataSet ds = new DataSet();
                adapter.Fill(ds);


                return ds;


            }
            catch (Exception)
            {
                throw;
            }
        }


        public SqlDataReader ExecuteQuery(string spName, bool blncloseconnection, Enums.SQLConnectionNames connName, IDictionary<string, object> paramNames)
        {
            dbConnection = new SqlConnection(databaseConnection(connName));
            try
            {
                dbConnection.Open();
                objSQLCommand = new SqlCommand();
                objSQLCommand.Connection = dbConnection;
                objSQLCommand.CommandType = CommandType.StoredProcedure;
                objSQLCommand.CommandText = spName;
                if (paramNames != null)
                {
                    foreach (string item in paramNames.Keys)
                    {
                        object paramValue = paramNames[item];
                        objSQLCommand.Parameters.AddWithValue(item, paramValue ?? DBNull.Value);
                    }
                }
                objSQLReader = objSQLCommand.ExecuteReader(CommandBehavior.CloseConnection);
                return objSQLReader;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public DataTable ExecuteQueryDataTable(string spName, bool blncloseconnection, Enums.SQLConnectionNames connName, IDictionary<string, object> paramNames)
        {
            SqlDataReader reader;
            DataTable dt = new DataTable();
            SqlConnection dbConn = new SqlConnection(databaseConnection(connName));
            try
            {
                dbConn.Open();
                SqlCommand objSQLComm = new SqlCommand();
                objSQLComm.Connection = dbConn;
                objSQLComm.CommandType = CommandType.StoredProcedure;
                objSQLComm.CommandText = spName;
                if (paramNames != null)
                {
                    foreach (string item in paramNames.Keys)
                    {
                        object paramValue = paramNames[item];
                        objSQLComm.Parameters.AddWithValue(item, paramValue ?? DBNull.Value);
                    }
                }
                reader = objSQLComm.ExecuteReader();
                dt.Load(reader);


                reader.Close();
                if (dbConn.State == ConnectionState.Open)
                {
                    dbConn.Close();
                }
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public int ExecuteSPWithOutputParam(string spName, Enums.SQLConnectionNames connName, IDictionary<string, object> paramNames)
        {
            int retval = 0;
            string paraName = "";
            dbConnection = new SqlConnection(databaseConnection(connName));
            try
            {
                dbConnection.Open();
                objSQLCommand = new SqlCommand();
                objSQLCommand.Connection = dbConnection;
                objSQLCommand.CommandType = CommandType.StoredProcedure;
                objSQLCommand.CommandText = spName;
                if (paramNames != null)
                {
                    foreach (string item in paramNames.Keys)
                    {
                        if (paramNames[item] != null)
                        {
                            object paramValue = paramNames[item];
                            objSQLCommand.Parameters.AddWithValue(item, paramValue ?? DBNull.Value);
                        }
                        else
                        {
                            objSQLCommand.Parameters.AddWithValue(item, 0);
                            objSQLCommand.Parameters[item].Direction = ParameterDirection.Output;
                            paraName = objSQLCommand.Parameters[item].ToString();




                        }
                    }
                }
                objSQLReader = objSQLCommand.ExecuteReader(CommandBehavior.CloseConnection);
                retval = (int)objSQLCommand.Parameters[paraName].Value;
                return retval;
            }
            catch (Exception)
            {
                dbConnection.Close();
                throw;
            }
            finally
            {
                if (dbConnection.State == ConnectionState.Open)
                    dbConnection.Close();
                dbConnection = null;
                objSQLCommand = null;
            }
        }




        public Dictionary<string, object> ExecuteSPWithOutputParam(string spName, Enums.SQLConnectionNames connName, IDictionary<string, object> paramNames, IDictionary<string, object> OutparamNames)
        {


            Dictionary<string, object> retVal = new Dictionary<string, object>();
            dbConnection = new SqlConnection(databaseConnection(connName));
            try
            {
                dbConnection.Open();
                objSQLCommand = new SqlCommand();
                objSQLCommand.Connection = dbConnection;
                objSQLCommand.CommandType = CommandType.StoredProcedure;
                objSQLCommand.CommandText = spName;
                if (paramNames != null)
                {
                    foreach (string key in paramNames.Keys)
                    {
                        object paramValue = paramNames[key];
                        objSQLCommand.Parameters.AddWithValue(key, paramValue ?? DBNull.Value);
                    }
                }


                if (OutparamNames != null)
                {
                    foreach (string key in OutparamNames.Keys)
                    {


                        string outputParamType = (string)OutparamNames[key];


                        switch (outputParamType)
                        {
                            case "System.Int64":
                                objSQLCommand.Parameters.AddWithValue(key, 0);
                                objSQLCommand.Parameters[key].Direction = ParameterDirection.Output;
                                break;
                            case "System.Boolean":
                                objSQLCommand.Parameters.AddWithValue(key, true);
                                objSQLCommand.Parameters[key].Direction = ParameterDirection.Output;
                                break;


                            default:
                                break;
                        }


                    }
                }
                objSQLReader = objSQLCommand.ExecuteReader(CommandBehavior.CloseConnection);


                foreach (string key in OutparamNames.Keys)
                {
                    retVal[key] = objSQLCommand.Parameters[key].Value;
                }
                return retVal;
            }
            catch (Exception)
            {
                dbConnection.Close();
                throw;
            }
            finally
            {
                if (dbConnection.State == ConnectionState.Open)
                    dbConnection.Close();
                dbConnection = null;
                objSQLCommand = null;
            }
        }


        public int ExecuteNonQuery(string spName, bool bisscalar, Enums.SQLConnectionNames connName, IDictionary<string, object> paramNames)
        {
            int icount;
            dbConnection = new SqlConnection(databaseConnection(connName));
            try
            {
                dbConnection.Open();
                objSQLCommand = new SqlCommand();
                objSQLCommand.Connection = dbConnection;
                objSQLCommand.CommandType = CommandType.StoredProcedure;
                objSQLCommand.CommandText = spName;
                if (paramNames != null)
                {
                    foreach (string item in paramNames.Keys)
                    {
                        object paramValue = paramNames[item];
                        objSQLCommand.Parameters.AddWithValue(item, paramValue ?? DBNull.Value);
                    }
                }
                if (bisscalar == true)
                {
                    icount = Convert.ToInt16(objSQLCommand.ExecuteScalar());
                }
                else
                {
                    icount = objSQLCommand.ExecuteNonQuery();
                }
                return icount;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (dbConnection.State == ConnectionState.Open)
                    dbConnection.Close();
                dbConnection = null;
                objSQLCommand = null;
            }
        }


        public T ExecuteScalar<T>(string spName, bool blncloseconnection, Enums.SQLConnectionNames connName, IDictionary<string, object> paramNames)
        {
            dbConnection = new SqlConnection(databaseConnection(connName));
            try
            {
                dbConnection.Open();
                objSQLCommand = new SqlCommand();
                objSQLCommand.Connection = dbConnection;
                objSQLCommand.CommandType = CommandType.StoredProcedure;
                objSQLCommand.CommandText = spName;
                if (paramNames != null)
                {
                    foreach (string item in paramNames.Keys)
                    {
                        object paramValue = paramNames[item];
                        objSQLCommand.Parameters.AddWithValue(item, paramValue ?? DBNull.Value);
                    }
                }
                object result = (object)objSQLCommand.ExecuteScalar();
                if ((result == null) || (result == DBNull.Value))
                {
                    return default(T);
                }
                return (T)result;
            }


            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (dbConnection.State != ConnectionState.Closed)
                {
                    dbConnection.Close();
                }
            }


        }


        public int ExecuteScalar(string spName, bool blncloseconnection, Enums.SQLConnectionNames connName, IDictionary<string, object> paramNames)
        {
            dbConnection = new SqlConnection(databaseConnection(connName));
            try
            {


                dbConnection.Open();
                objSQLCommand = new SqlCommand();
                objSQLCommand.Connection = dbConnection;
                objSQLCommand.CommandType = CommandType.StoredProcedure;
                objSQLCommand.CommandText = spName;
                if (paramNames != null)
                {
                    foreach (string item in paramNames.Keys)
                    {
                        object paramValue = paramNames[item];
                        objSQLCommand.Parameters.AddWithValue(item, paramValue ?? DBNull.Value);
                    }
                }
                int result = Convert.ToInt32(objSQLCommand.ExecuteScalar());


                return result;
            }


            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (dbConnection.State != ConnectionState.Closed)
                {
                    dbConnection.Close();
                }
            }


        }




        public int ExecuteScalarWithOutputParam(string spName, Enums.SQLConnectionNames connName, IDictionary<string, object> paramNames)
        {
            int retval = 0;
            string paraName = "";
            dbConnection = new SqlConnection(databaseConnection(connName));
            try
            {
                dbConnection.Open();
                objSQLCommand = new SqlCommand();
                objSQLCommand.Connection = dbConnection;
                objSQLCommand.CommandType = CommandType.StoredProcedure;
                objSQLCommand.CommandText = spName;
                if (paramNames != null)
                {
                    foreach (string item in paramNames.Keys)
                    {
                        if (paramNames[item] != null)
                        {
                            object paramValue = paramNames[item];
                            objSQLCommand.Parameters.AddWithValue(item, paramValue ?? DBNull.Value);
                        }
                        else
                        {
                            objSQLCommand.Parameters.Add(item, SqlDbType.Int);
                            objSQLCommand.Parameters[item].Direction = ParameterDirection.ReturnValue;
                            paraName = objSQLCommand.Parameters[item].ToString();
                        }
                    }
                }
                objSQLReader = objSQLCommand.ExecuteReader(CommandBehavior.CloseConnection);
                retval = (int)objSQLCommand.Parameters[paraName].Value;


                return retval;
            }
            catch (Exception)
            {
                dbConnection.Close();
                throw;
            }
            finally
            {
                if (dbConnection.State == ConnectionState.Open)
                    dbConnection.Close();
                dbConnection = null;
                objSQLCommand = null;
            }
        }






    }
}

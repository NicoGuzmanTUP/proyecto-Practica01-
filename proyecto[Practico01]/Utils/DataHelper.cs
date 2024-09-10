using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Practico01_.Utils
{
    public class DataHelper
    {
        public static DataHelper? _instance;
        private SqlConnection _connection;

        public DataHelper()
        {
            _connection = new SqlConnection(Properties.Resources.CnnString);
        }

        public static DataHelper GetInstance()
        {
            if( _instance == null)
            {
                _instance = new DataHelper();
            }
            return _instance;
        }

        public DataTable? ExecuteSpQuery(string sp, List<ParameterSQL>? parameters)
        {
            DataTable? dt = new DataTable();
            SqlCommand? cmd = null;

            try
            {
                _connection.Open();
                cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    foreach (ParameterSQL param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Name, param.Value);
                    }
                }
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException) {
                dt = null;
            }
            finally
            {
                if(_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }

            return dt;
        }

        public int ExecuteSPDML(string sp, List<ParameterSQL>? parameters)
        {
            int rows;
            try
            {
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Name, param.Value);
                    }
                }
                rows = cmd.ExecuteNonQuery();
                _connection.Close();
            }
            catch (SqlException)
            {
                rows = 0;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }                        

            return rows;
        }

        public SqlConnection GetConnection()
        {
            return _connection;
        }


    }
}

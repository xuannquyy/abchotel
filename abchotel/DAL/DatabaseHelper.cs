using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abchotel.DAL
{
    public class DatabaseHelper
    {
        private static string connectionString =
            ConfigurationManager.ConnectionStrings["abchotel.Properties.Settings.Setting"].ConnectionString;

        public static DataTable GetData(string query, CommandType commandType, params (string, object)[] parameters)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Đây là phần quan trọng được thêm vào
                    cmd.CommandType = commandType;

                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                            cmd.Parameters.AddWithValue(param.Item1, param.Item2 ?? DBNull.Value);
                    }

                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // Hàm này giữ lại để code cũ của bạn (ở FormRoom, FormCustomer) không bị lỗi
        // Nó tự động gọi hàm mới với CommandType.Text (là mặc định)
        public static DataTable GetData(string query, params (string, object)[] parameters)
        {
            return GetData(query, CommandType.Text, parameters);
        }

        public static int ExecuteNonQuery(string query, CommandType commandType, params (string, object)[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = commandType;
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                            cmd.Parameters.AddWithValue(param.Item1, param.Item2 ?? DBNull.Value);
                    }

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static int ExecuteNonQuery(string query, params (string, object)[] parameters)
        {
            return ExecuteNonQuery(query, CommandType.Text, parameters);
        }

        public static object ExecuteScalar(string query, CommandType commandType, params (string, object)[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = commandType;
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                            cmd.Parameters.AddWithValue(param.Item1, param.Item2 ?? DBNull.Value);
                    }

                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static object ExecuteScalar(string query, params (string, object)[] parameters)
        {
            return ExecuteScalar(query, CommandType.Text, parameters);
        }
    }
}

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AutoTimeTable.SourceCode
{
    public class DatabaseLayer
    {
        static string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public static SqlConnection con;

        public static SqlConnection conOpen()
        {
            if (con == null)
            {
                con = new SqlConnection(cs);
            }
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            return con;
        }

        public static bool Insert(string query)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(query, conOpen());
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    return true;
                }
                return false;

            }
            catch (Exception)
            {

                return false;
            }

        }
        public static bool Update(string query)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(query, conOpen());
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    return true;
                }
                return false;

            }
            catch (Exception)
            {

                return false;
            }

        }
        public static bool Delete(string query)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(query, conOpen());
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    return true;
                }
                return false;

            }
            catch (Exception)
            {

                return false;
            }

        }
        public static DataTable Retrieve(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(query, conOpen());
                sda.Fill(dt);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        return dt;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;

            }

        }










    }
}

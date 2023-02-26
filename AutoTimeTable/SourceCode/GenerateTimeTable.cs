using System;
using System.Data;
using System.Data.SqlClient;

namespace AutoTimeTable.SourceCode
{
    public class GenerateTimeTable
    {
        public static string AutoGenerateTimeTable(DateTime StartDate, DateTime EndDate)
        {
            string Messages = string.Empty;
            try
            {
                SqlCommand command = new SqlCommand("GenerateTimeTablesForAllSession", DatabaseLayer.conOpen());
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@StartDate", StartDate);
                command.Parameters.AddWithValue("@EndDate", EndDate);
                SqlParameter RuturnValue = new SqlParameter("@Message", SqlDbType.NVarChar, 200);
                RuturnValue.Direction = ParameterDirection.Output;
                command.Parameters.Add(RuturnValue);
                command.ExecuteNonQuery();
                Messages = (string)command.Parameters["@Message"].Value;
            }
            catch (Exception ex)
            {
                Messages = ex.Message;
            }
            return Messages;
        }


    }
}

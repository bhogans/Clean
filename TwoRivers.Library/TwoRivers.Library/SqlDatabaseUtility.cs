using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TwoRivers.Library
{
    public class SqlDatabaseUtility
    {
        public static SqlConnection GetConnection(string connectionName)
        {
            string cnstr = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            SqlConnection cn = new SqlConnection(cnstr);
            cn.Open();
            return cn;
        }

        public static SqlDataReader ExecuteQuery(
            string connectionName,
            string storedProcName,
            Dictionary<string, SqlParameter> procParameters
        )
        {
            // open a database connection
            SqlConnection cn = GetConnection(connectionName);

            // create a SQL command to execute the stored procedure
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = storedProcName;

            // assign parameters passed in to the command
            foreach (var procParameter in procParameters)
            {
                cmd.Parameters.Add(procParameter.Value);
            }

            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public static int ExecuteCommand(
            string connectionName,
            string storedProcName,
            Dictionary<string, SqlParameter> procParameters
        )
        {
            int rc;

            using (SqlConnection cn = GetConnection(connectionName))
            {
                // create a SQL command to execute the stored procedure
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = storedProcName;

                // assign parameters passed in to the command
                foreach (var procParameter in procParameters)
                {
                    cmd.Parameters.Add(procParameter.Value);
                }

                rc = cmd.ExecuteNonQuery();
            }

            return rc;
        }
    }
}

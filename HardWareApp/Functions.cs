using System;
using System.Data;
using System.Data.SqlClient;
using DotNetEnv;
using System.IO; // for Path

namespace HardWareApp
{
    internal class Functions
    {
        private readonly SqlConnection Con;
        private readonly string ConStr;

        public Functions()
        {
            // Load environment variables from .env
            string fullPath = Path.GetFullPath("../../../.env");
            Env.Load(fullPath);

            string server = Env.GetString("DB_SERVER");
            string user = Env.GetString("DB_USER");
            string database = Env.GetString("DB_NAME");
            string password = Env.GetString("DB_PASSWORD");

            ConStr = $"Server={server};Database={database};User Id={user};Password={password};TrustServerCertificate=True;";
            Con = new SqlConnection(ConStr);
        }

        // -------------------------------
        // SELECT queries
        // -------------------------------
        public DataTable GetData(string query)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(query, ConStr))
                {
                    sda.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Database read error: " + ex.Message);
            }

            return dt;
        }


        public DataTable GetData(string query, params SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(ConStr))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Database read error (with parameters): " + ex.Message);
            }

            return dt;
        }


        // -------------------------------
        // INSERT / UPDATE / DELETE 
        // -------------------------------

        public int SetData(string query)
        {
            int affectedRows = 0;
            try
            {
                if (Con.State == ConnectionState.Closed)
                    Con.Open();

                using (SqlCommand cmd = new SqlCommand(query, Con))
                {
                    affectedRows = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Database write error: " + ex.Message);
            }
            finally
            {
                Con.Close();
            }

            return affectedRows;
        }

        // -------------------------------
        // INSERT / UPDATE / DELETE
        // -------------------------------
        public int SetData(string query, params SqlParameter[] parameters)
        {
            int affectedRows = 0;
            try
            {
                if (Con.State == ConnectionState.Closed)
                    Con.Open();

                using (SqlCommand cmd = new SqlCommand(query, Con))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    affectedRows = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Database write error: " + ex.Message);
            }
            finally
            {
                Con.Close();
            }

            return affectedRows;
        }
    }
}


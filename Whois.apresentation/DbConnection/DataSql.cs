using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Whois.apresentation.DbConnection
{

    public class DataSql
    {
        public String UrlSearched { get; set; }
        public String AvaliableRegister { get; set; }
        public String DtTime { get; set; }

        private string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        private List<string> lista = new List<string>();

        public void SqlPush()
        {
            SqlConnection connection = new SqlConnection(connStr);
            SqlCommand command = new SqlCommand("INSERT INTO Table_nm_avaliable(nmURL,boolAvaliable,dtSearch) VALUES('" + UrlSearched + "','" + AvaliableRegister + "','" + DtTime + "')", connection);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        public List<string> SqlPull()
        {
            SqlConnection connection = new SqlConnection(connStr);
            SqlCommand command = new SqlCommand("SELECT * FROM Table_nm_avaliable", connection);
          
            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(dr[0] + " - " + dr["nmURL"] + " - " + dr["boolAvaliable"]);
                }
            }
           



             finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }

            return lista;

        }

    }
}

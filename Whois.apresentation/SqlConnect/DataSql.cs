using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Whois.apresentation.SqlConnect
{

    public class DataSql
    {
        public String UrlSearched { get; set; }
        public String AvaliableRegister { get; set; }

        public void SqlSaver()
        {
            string connString = @"Data Source=DESKTOP-U9I9SMQ\SQLEXPRESS;Initial Catalog=dbWHOIS;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connString);
            SqlCommand command = new SqlCommand("INSERT INTO Table_nm_avaliable(nmURL,boolAvaliable) VALUES('" + UrlSearched + "','" + AvaliableRegister + "')", connection);

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
    }
}

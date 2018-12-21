using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Whois.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Whois.apresentation.WhoisInterface
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connString = @"Data Source=DESKTOP-U9I9SMQ\SQLEXPRESS;Initial Catalog=dbWHOIS;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Table_nm_avaliable", connection);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                lstResults.Items.Add(dr[0] + " - " + dr["nmURL"] + " - " +dr["boolAvaliable"]);
            }


        }
    }
}
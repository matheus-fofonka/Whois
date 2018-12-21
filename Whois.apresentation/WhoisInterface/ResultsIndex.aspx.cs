using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Whois.Entities;
using Whois.apresentation;
using Whois.apresentation.DbConnection;

namespace Whois.apresentation.WhoisInterface
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSql sql = new DataSql();
            var lst = sql.SqlPull();

            foreach (var dados in lst)
            {
                lstResults.Items.Add(dados);
            }
        }
    }
}
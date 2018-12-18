using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Threading;
using Whois.NET;
using Whois;

namespace Whois.apresentation.WhoisInterface
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //Se o domínio está registrado ou disponível para registro.
        //Data de registro do domínio.Data da última alteração.
        //Data de expiração do domínio.Lista de Name Servers.

        protected void Button1_Click(object sender, EventArgs e)
        { if (txtURL.Text != "" && txtURL.Text != "digite uma URL")
            {
                var whois = new WhoisLookup();
                var response = whois.Lookup(txtURL.Text);
                string sub = (response.Content).Substring(0,12);
                var servers = response.ParsedResponse.NameServers;

                if (sub != "No match for")
                {
                    txtURL.Text = "Domínio está registrado. ";
                    lblSTATUS.ForeColor = System.Drawing.Color.Green;
                    lblDomain.Text = response.ParsedResponse.DomainName.ToString();
                    lblDtRegister.Text = response.ParsedResponse.Registered.ToString();
                    lblDtUpdate.Text = response.ParsedResponse.Updated.ToString();
                    lblDtExpiration.Text = response.ParsedResponse.Expiration.ToString();
                    foreach (string value in servers)
                    {
                        ListBox1.Items.Add(value);
                    }

                }
                else { lblSTATUS.ForeColor = System.Drawing.Color.Red; txtURL.Text = "Domínio disponível para registro. "; }
            }
            else {txtURL.Text = ("digite uma URL"); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtURL_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


    

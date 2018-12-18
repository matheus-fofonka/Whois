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
        //BulletedList1.Items.Add(response.Content);
        protected void Button1_Click(object sender, EventArgs e)
        { if (txtURL.Text != "" && txtURL.Text != "digite uma URL")
            {
                var whois = new WhoisLookup();
                var response = whois.Lookup(txtURL.Text);
                lblDomain.Text = response.ParsedResponse.RegistryDomainId;
                lblDtRegister.Text = response.ParsedResponse.Registered.ToString();
                lblDtUpdate.Text = response.ParsedResponse.Updated.ToString();
                lblDtExpiration.Text = response.ParsedResponse.Expiration.ToString();
               // var serverList = response.ParsedResponse.NameServers;
               // serverList.Add
            }
            else {txtURL.Text = ("digite uma URL"); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}


    

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
using Whois.Entities;
using Whois.apresentation;

namespace Whois.apresentation.WhoisInterface
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public bool av;

        protected void Button1_Click(object sender, EventArgs e)
        {
            ListBox1.Items.Clear();
            LoadServerList();
        }


        protected void Page_Load(object sender, EventArgs e)
        {


        }

        public void LoadServerList()
        {
            var whois = new WhoisLookup();
            var response = whois.Lookup(txtURL.Text);

            var servers = response.ParsedResponse.NameServers;
            foreach (string value in servers)
            {
                ListBox1.Items.Add(value);
            }
        }

        public void ActionForSearch()
        {
            if (txtURL.Text != "" && txtURL.Text != "digite uma URL" && txtURL.Text != "Domínio está registrado. " && txtURL.Text != "Domínio disponível para registro. ")
            {
                Dominio dom = new Dominio();
                var whois = new WhoisLookup();
                var response = whois.Lookup(txtURL.Text);
                string sub = (response.Content).Substring(0, 12);


                if (sub != "No match for")
                {
                    av = false;
                    txtURL.Text = "Domínio está registrado. ";

                    lblDomain.Text = response.ParsedResponse.DomainName.ToString();
                    dom.NmDomain = response.ParsedResponse.DomainName.ToString();
                    lblDtRegister.Text = response.ParsedResponse.Registered.ToString();
                    dom.DtRegistration = response.ParsedResponse.Registered.ToString();
                    lblDtUpdate.Text = response.ParsedResponse.Updated.ToString();
                    dom.DtAlteration = response.ParsedResponse.Updated.ToString();
                    lblDtExpiration.Text = response.ParsedResponse.Expiration.ToString();
                    dom.DtExpiration = response.ParsedResponse.Expiration.ToString();

                }
                else { av = true; txtURL.Text = "Domínio disponível para registro. "; }

                dom.Exportar();
            }
            else { txtURL.Text = ("digite uma URL"); };

        }
    }
}











﻿using System;
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

namespace Whois.apresentation.WhoisInterface
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public bool av;

        //Se o domínio está registrado ou disponível para registro.
        //Data de registro do domínio.Data da última alteração.
        //Data de expiração do domínio.Lista de Name Servers.

        protected void Button1_Click(object sender, EventArgs e)
        {
            action();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        public void action()
        {
            List<Dominio> dominios = new List<Dominio>();


            if (txtURL.Text != "" && txtURL.Text != "digite uma URL")
            {
                Dominio dom = new Dominio();
                oDominio oDominio = new oDominio();
                var whois = new WhoisLookup();
                var response = whois.Lookup(txtURL.Text);
                string sub = (response.Content).Substring(0, 12);
                oDominio.nmDomínio = response.ParsedResponse.DomainName.ToString();
                oDominio.Exportar();

                if (sub != "No match for")
                {
                    av = false;

                    txtURL.Text = "Domínio está registrado. ";
                    lblSTATUS.ForeColor = System.Drawing.Color.Green;
                    lblDomain.Text = response.ParsedResponse.DomainName.ToString();
                    dom.NmDomain = response.ParsedResponse.DomainName.ToString();
                    lblDtRegister.Text = response.ParsedResponse.Registered.ToString();
                    dom.DtRegistration = response.ParsedResponse.Registered.ToString();
                    lblDtUpdate.Text = response.ParsedResponse.Updated.ToString();
                    dom.DtAlteration = response.ParsedResponse.Updated.ToString();
                    lblDtExpiration.Text = response.ParsedResponse.Expiration.ToString();
                    dom.DtExpiration = response.ParsedResponse.Expiration.ToString();
                    var servers = response.ParsedResponse.NameServers;
                    dominios.Add(dom);
                    ListBox1.Items.Clear();
                    foreach (string value in servers)
                    {
                        ListBox1.Items.Add(value);
                        //dom.ListServers.Add(value);
                    }
                    
                }
                else { av = true; lblSTATUS.ForeColor = System.Drawing.Color.Red; txtURL.Text = "Domínio disponível para registro. "; }
                dom.Exportar();
            }
            else { txtURL.Text = ("digite uma URL"); };

        }
    }
}









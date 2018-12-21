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
using Whois.apresentation.DbConnection;


namespace Whois.apresentation.WhoisInterface
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Dominio dom = new Dominio();
        DataSql sql = new DataSql();

        public bool av;

        protected void Button1_Click(object sender, EventArgs e)
        {
            ListBox1.Items.Clear();

            txtURL.Text = TreatURL();

            AddInfo();

        }

        public string TreatURL()
        {
            string[] sptURL = txtURL.Text.Split('.');

            if (sptURL[0].Substring(0, 3) == "htt" || sptURL[0].Substring(0, 3) == "www")
            {
                sptURL[0] = "";
            }

            string arrayToStr = String.Join(".", sptURL);
            char[] strForCharArr = arrayToStr.ToCharArray();

            if (strForCharArr[0] == '.')
            {
                arrayToStr = "";
                for (int i = 1; i < strForCharArr.Length; i++)
                {
                    arrayToStr = (arrayToStr + strForCharArr[i]);
                }
            }           
            return arrayToStr;
        }


        public void AddInfo()
        {
            if (txtURL.Text != "" && txtURL.Text != "digite uma URL" && txtURL.Text != "Domínio está registrado. " && txtURL.Text != "Domínio disponível para registro. ")
            {
                var whois = new WhoisLookup();
                var response = whois.Lookup(txtURL.Text);
                string sub = (response.Content).Substring(0, 12);
                if (txtURL.Text != "")
                {
                    sql.UrlSearched = txtURL.Text;
                }
                else
                {
                    sql.UrlSearched = "Não detectado!!";
                }
                string url = txtURL.Text;
                int treatUrl = url.IndexOf(".");

                if (sub != "No match for")
                {

                    av = false;
                    txtURL.Text = "Domínio está registrado. ";

                    lblSTATUS.ForeColor = System.Drawing.Color.Red;
                    lblSTATUS.Text = "Registrado";
                    lblDomain.Text = response.ParsedResponse.DomainName.ToString();
                    dom.NmDomain = response.ParsedResponse.DomainName.ToString();
                    lblDtRegister.Text = response.ParsedResponse.Registered.ToString();
                    dom.DtRegistration = response.ParsedResponse.Registered.ToString();
                    lblDtUpdate.Text = response.ParsedResponse.Updated.ToString();
                    dom.DtAlteration = response.ParsedResponse.Updated.ToString();
                    lblDtExpiration.Text = response.ParsedResponse.Expiration.ToString();
                    dom.DtExpiration = response.ParsedResponse.Expiration.ToString();


                    var servers = response.ParsedResponse.NameServers;
                    foreach (string value in servers)
                    {
                        ListBox1.Items.Add(value);
                    }
                }
                else
                {
                    lblSTATUS.ForeColor = System.Drawing.Color.Green;
                    lblSTATUS.Text = "Pronto pra registro";
                    av = true;
                    txtURL.Text = "Domínio disponível para registro. ";
                    ListBox1.Items.Add("Ainda não possui servidores.");
                }
                string avString;
                if (av == true)
                {
                    avString = "Avaliable";
                }
                else
                {
                    avString = "unavailable";
                }
                sql.AvaliableRegister = avString;
                dom.Export();
                sql.SqlPush();
            }
            else { txtURL.Text = ("digite uma URL"); };

        }


        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}











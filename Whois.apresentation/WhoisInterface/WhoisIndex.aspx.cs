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
            lblContent.Text = "";

            LstContent.Items.Clear();
            ListBox1.Items.Clear();

            txtURL.Text = TreatURL();

            if (txtURL.Text != "digite uma URL")
            {
                AddInfo();
            }
            else
            {
                lblSTATUS.ForeColor = System.Drawing.Color.Blue;
                lblSTATUS.Text = "STATUS";
            }


        }
        //trata a string tirando a / final; http(s) e www
        public string TreatURL()
        {//verifica se a resposta não é a atribuição de outro metodo
            if (txtURL.Text != "" && txtURL.Text != "digite uma URL" && txtURL.Text != "Domínio está registrado. " && txtURL.Text != "Domínio disponível para registro. ")
            {
                //separa a url pelos ponto e verifica a subString do primeiro array e apaga se for http ou www
                string[] sptURL = txtURL.Text.Split('.');

                if (sptURL[0].Substring(0, 3) == "htt" || sptURL[0].Substring(0, 3) == "www")
                {
                    sptURL[0] = "";
                }
                //junto de novo mas tenho q transformar em um array char pra apagar um . extra 
                string arrayToStr = String.Join(".", sptURL);
                char[] strForCharArrDot = arrayToStr.ToCharArray();

                if (strForCharArrDot[0] == '.')
                {
                    arrayToStr = "";
                    for (int i = 1; i < strForCharArrDot.Length; i++)
                    {
                        arrayToStr = (arrayToStr + strForCharArrDot[i]);
                    }
                }
                // aki inverto o array char pra apagar a / q aparece no final das urls
                string invertedStr = new String(arrayToStr.Reverse().ToArray());

                char[] strForCharInverter = invertedStr.ToCharArray();

                if (strForCharInverter[0] == '/')
                {
                    arrayToStr = "";
                    for (int i = 1; i < strForCharInverter.Length; i++)
                    {
                        arrayToStr = (arrayToStr + strForCharInverter[i]);
                    }
                    arrayToStr = new String(arrayToStr.Reverse().ToArray());
                }

                return arrayToStr;
            }
            else
            {
                //aki uso essa string que eu filtro no inicio pra não ter q fazer um retorno em Tuples
                txtURL.Text = ("digite uma URL");
                return txtURL.Text;
            }
        }


        public void AddInfo()
        {

            {
                var whois = new WhoisLookup();
                var response = whois.Lookup(txtURL.Text);
                //faço essa substing pra filtrar a resposta padrão de domínio não registrado
                string sub = (response.Content).Substring(0, 12);
                if (txtURL.Text != "")
                {//salvo a url no banco depois dos tratamentos
                    sql.UrlSearched = txtURL.Text;
                }
                else
                {
                    sql.UrlSearched = "Não detectado!!";
                }
                string url = txtURL.Text;

                if (sub != "No match for")
                {

                    av = false;
                    txtURL.Text = "Domínio está registrado. ";

                    lblSTATUS.ForeColor = System.Drawing.Color.Red;
                    lblSTATUS.Text = "Registrado";
                    try
                    {   // add as variaveis na classe dominio para serializar e adiciona nas labels do front 
                        lblDomain.Text = response.ParsedResponse.DomainName.ToString();
                        dom.NmDomain = response.ParsedResponse.DomainName.ToString();
                        lblDtRegister.Text = response.ParsedResponse.Registered.ToString();
                        dom.DtRegistration = response.ParsedResponse.Registered.ToString();
                        lblDtUpdate.Text = response.ParsedResponse.Updated.ToString();
                        dom.DtAlteration = response.ParsedResponse.Updated.ToString();
                        lblDtExpiration.Text = response.ParsedResponse.Expiration.ToString();
                        dom.DtExpiration = response.ParsedResponse.Expiration.ToString();

                        //add os Name servers pra listBox
                        var servers = response.ParsedResponse.NameServers;
                        foreach (string value in servers)
                        {
                            ListBox1.Items.Add(value);
                        }
                    }//Como esse metodo whois não abrange todas TLD ele manda tem outro metodo q manda todo o conteudo da request
                    catch (Exception)
                    {
                        txtURL.Text = "Tld fora do alcance !";
                        lblSTATUS.Text = "INFO sobre o domínio abaixo da lista de servers";
                        lblSTATUS.ForeColor = System.Drawing.Color.BlueViolet;
                        lblContent.Text = "Informações sobre o domínio";
                        String[] Cont = (response.Content).Split('\n');
                        foreach (var item in Cont)
                        {
                            LstContent.Items.Add(item);
                        }
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
                    avString = "unavailable";//Sobe a url, a data e a disponibilidade do dominio pro SQL_Server e a Classe Dominio é serializada em xml
                }
                sql.DtTime = (DateTime.Now).ToString();
                sql.AvaliableRegister = avString;
                dom.Export();
                sql.SqlPush();
            }


        }

    }
}











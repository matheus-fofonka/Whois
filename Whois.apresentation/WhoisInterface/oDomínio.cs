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
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Whois.Entities;

namespace Whois.apresentation.WhoisInterface
{
    public class oDominio
    {
            public string nmDomínio { get; set; }
          //  public string disponibility { get; set; }

            public bool Exportar()
            {
                try
                {
                    FileStream stream = new FileStream(@"C:\Users\mfofonka\source\repos\Whois\Dominio.xml", FileMode.Create);
                    XmlSerializer serializador = new XmlSerializer(typeof(Dominio));
                    serializador.Serialize(stream, this);
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            public static Dominio Importar()
            {
                try
                {
                    FileStream stream = new FileStream(@"C:\dominio", FileMode.Open);
                    XmlSerializer desserializador = new XmlSerializer(typeof(Dominio));
                    Dominio dominio  = (Dominio)desserializador.Deserialize(stream);
                    return dominio;
                }
                catch
                {
                    return null;
                }
            }
        }
    }

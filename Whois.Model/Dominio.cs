using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Whois.Entities;

namespace Whois.Entities
{
    [XmlRoot("Dominios")]
    [XmlInclude(typeof(Dominio))]
    [Serializable]

    public class Dominio
    {
        [XmlElement("NmDomain")]
        public string NmDomain { get; set; }
        [XmlElement("DtRegistration")]
        public string DtRegistration { get; set; }
        [XmlElement("DtAlteration")]
        public string DtAlteration { get; set; }
        [XmlElement("DtExpiration")]
        public string DtExpiration { get; set; }
        //   [XmlElement("ListServers")]
        // public List<string> ListServers { get; set; }

        public bool Exportar()
        {
            try
            {
                Type[] personTypes = { typeof(List<Dominio>), typeof(Dominio) };
                FileStream stream = new FileStream(@"C:\Users\mfofonka\source\repos\Whois\NewDominio.xml", FileMode.OpenOrCreate);
                XmlSerializer serializador = new XmlSerializer(dominios.GetType(), new XmlRootAttribute("dominios"));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
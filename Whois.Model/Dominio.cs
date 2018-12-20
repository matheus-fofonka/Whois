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

        public bool Exportar()
        {
            try
            {
                FileStream stream = new FileStream(@"C:\Users\mfofonka\source\repos\Whois\Dominio.xml", FileMode.Append);
                XmlSerializer serializador = new XmlSerializer(typeof(Dominio));
                serializador.Serialize(stream, this);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
    }

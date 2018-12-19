using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Whois.Entities;
using Whois.apresentation;

namespace Whois.apresentation
{
    public class Serialization
    {

        public static void Serializer(string Path)
        {

            Type[] personTypes = { typeof(List<Dominio>), typeof(Dominio) };
            XmlSerializer serializer = new XmlSerializer(typeof(List<Dominio>), personTypes);
            FileStream fs = new FileStream(Path + "Dominio.xml", FileMode.Create);
         //   serializer.Serialize(fs,);
            ///.clear();
            fs.Close();
        }

        public static void DesSerializer(string Path)
        {
            Type[] personTypes = { typeof(List<Dominio>), typeof(Dominio) };
            XmlSerializer serializer = new XmlSerializer(typeof(List<Dominio>), personTypes);
            FileStream fs = new FileStream(Path + "Dominio.xml", FileMode.Create);
            /// = (list<Dominio>)serializer.Deserializer(fs);
            ///.clear();
            fs.Close();
        }
    }
}

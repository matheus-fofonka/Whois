using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whois.Entities
{
   public class Dominio
    {
        public DateTime DtRegistration { get; set; }
        public DateTime DtAlteration { get; set; }
        public DateTime DtExpiration { get; set; }
        public string ListServers { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Magazin : BaseEntity
    {
        public Magazin()
        {
        }

        public Magazin(int numar, string den, string comandaCadru, int clientId)
        {
            Numar = numar;
            Den = den;
            ComandaCadru = comandaCadru;
            ClientId = clientId;
        }

        public int Numar { get; set; }
        public string Den { get; set; }
        public string ComandaCadru { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Entities
{
    public class BaseCardEntity
    {
        public string CardOwnerName { get; set; }
        public string CardType { get; set; }
        public int CardNumber { get; set; }
        public int CardSecurityCode { get; set; }
        public DateTime CardExpiration { get; set; }
    }
}

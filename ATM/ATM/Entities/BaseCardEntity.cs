using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Entities
{
    public class BaseCardEntity
    {
        private string _CardOwnerName;

        public string CardOwnerName
        {
            get { return _CardOwnerName; }
            set
            {
                _CardOwnerName = value;
            }
        }
        private string _CardType;
        public string CardType
        {
            get { return _CardType; }
            set
            {
                _CardType = value;
            }
        }
        private int _CardNumber;
        public int CardNumber
        {
            get { return _CardNumber; }
            set
            {
                _CardNumber = value;
            }
        }
        private int _CardSecurityCode;
        public int CardSecurityCode
        {
            get { return _CardSecurityCode; }
            set
            {
                _CardSecurityCode = value;
            }
        }
        private DateTime _CardExpiration;
        public DateTime CardExpiration
        {
            get { return CardExpiration; }
            set
            {
                _CardExpiration = value;
            }
        }
    }
}

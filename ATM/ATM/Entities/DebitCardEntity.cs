using ATM.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Entities
{
    public class DebitCardEntity : ICard
    {
        private decimal _CardNumber;

        public decimal CardNumber
        {
            get { return _CardNumber; }
            set
            {
                _CardNumber = value;
            }
        }

        // *** INTERFACE METHODS ***
        public List<BaseCardEntity> GetAllCards(Guid accountNumber)
        {
            throw new NotImplementedException();
        }

        public BaseCardEntity GetCard(int cardNumber)
        {
            throw new NotImplementedException();
        }

        
    }
}

using ATM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Interfaces
{
    public interface ICard
    {
        public BaseCardEntity GetCard(int cardNumber);
        public List<BaseCardEntity> GetAllCards(Guid accountNumber);
    }
}

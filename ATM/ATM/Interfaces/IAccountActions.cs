using ATM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Interfaces
{
    public interface IAccountActions
    {
        public decimal WithdrawFunds();
        public bool DepositFunds();
        public bool GetNewCard();
        public List<BaseCardEntity> ShowBankCards();
        public decimal GetBalance();
        public Guid GetAccountNumber();

    }
}

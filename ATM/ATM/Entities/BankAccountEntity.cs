using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Entities
{
    public class BankAccountEntity
    {
        public int AccountNumber { get; set; }
        public BaseCardEntity[] Cards { get; set; }
        public int MaxTransactionLimit { get; set; }
        public int MaxCashWithdrawalLimit { get; set; }
        public int BankPin { get; set; }
    }
}

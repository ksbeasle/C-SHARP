using ATM.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Entities
{
    public class BankAccountEntity : IAccountActions
    {
        private Guid _AccountNumber;
        public Guid AccountNumber
        {
            get { return _AccountNumber; }
            set
            {
                _AccountNumber = value;
            }
        }
        private BaseCardEntity[]? _Cards;
        public BaseCardEntity[]? Cards
        {
            get { return _Cards; }
            set
            {
                _Cards = value;
            }
        }
        private float _MaxTransactionLimit;
        public float MaxTransactionLimit
        {
            get { return _MaxTransactionLimit; }
            set
            {
                _MaxTransactionLimit = value;
            }
        }
        private float _MaxCashWithdrawalLimit;
        public float MaxCashWithdrawalLimit
        {
            get { return _MaxCashWithdrawalLimit; }
            set
            {
                _MaxCashWithdrawalLimit = value;
            }
        }
        private int _BankPin;
        public int BankPin
        {
            get { return _BankPin; }
            set
            {
                _BankPin = value;
            }
        }
        private decimal _Balance;
        public decimal Balance
        {
            get { return _Balance; }
            set
            {
                _Balance = value;
            }
        }

        public float Withdrawal()
        {
            throw new NotImplementedException();
        }
    }
}

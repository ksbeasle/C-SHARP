using ATM.Interfaces;
using System.Text.RegularExpressions;
namespace ATM.Entities
{
    public class BankAccountEntity : IAccountActions
    {

        private const decimal MAX_TRANSACTION_LIMIT = 5000;
        private Guid _AccountNumber;
        public Guid AccountNumber
        {
            get { return _AccountNumber; }
            set
            {
                _AccountNumber = value;
            }
        }
        private List<BaseCardEntity>? _Cards;
        public List<BaseCardEntity>? Cards
        {
            get { return _Cards; }
            set
            {
                _Cards = value;
            }
        }
        private string _BankPin;
        public string BankPin
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

        private string _Username;
        public string Username
        {
            get { return _Username; }
            set
            {
                _Username = value;
            }
        }

        // *** VALIDATIONS ***
        private bool isValidBankPin(string pin)
        {
            Regex rx = new Regex(@"^[\d]{4}$"); // 4 digit pin only
            if (rx.IsMatch(pin)) // -- hopefully this works even as a string???
            {
                return true;
            }
            return false;
        }

        // *** INTERFACE METHODS ***
        public float WithdrawFunds()
        {
            throw new NotImplementedException();
        }

        decimal IAccountActions.WithdrawFunds()
        {
            throw new NotImplementedException();
        }

        public bool DepositFunds()
        {
            throw new NotImplementedException();
        }

        public bool GetNewCard()
        {
            throw new NotImplementedException();
        }

        public List<BaseCardEntity> ShowBankCards()
        {
            throw new NotImplementedException();
        }

        public decimal GetBalance()
        {
            throw new NotImplementedException();
        }

        public Guid GetAccountNumber()
        {
            throw new NotImplementedException();
        }
    }
}

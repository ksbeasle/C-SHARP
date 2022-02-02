using ATM.Interfaces;
using System.Text.RegularExpressions;
namespace ATM.Entities
{
    public class BankAccountEntity : IAccountActions
    {
        public BankAccountEntity(Guid accountNumber, int bankPin)
        {
            AccountNumber = AccountNumber;
            BankPin = bankPin;
            // TODO: CAll setters?
        }

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
        private int _BankPin;
        public int BankPin
        {
            get { return _BankPin; }
            set
            {
                try
                {
                    Regex rx = new Regex(@"^[\d]{4}$"); // 4 digit pin only
                    if (rx.IsMatch(value.ToString())) // -- hopefully this works even as a string???
                    {
                        _BankPin = value;
                    }
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
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

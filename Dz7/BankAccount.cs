using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz7
{
    class BankAccount
    {
        public enum BankAccountType
        {
            current,
            savings
        }
        private int _accountNumber;
        private double _balance;
        private BankAccountType _bat;
        static int magnifier = 1;
        public BankAccount(double balance, BankAccountType bat)
        {
            _accountNumber = magnifier;
            _balance = balance;
            _bat = bat;
            IncreaseNumber();
        }
        public BankAccount()
        {
            _accountNumber = magnifier;
            IncreaseNumber();
        }
        public void SetAccountNumber(int accNum)
        {
            _accountNumber = accNum;
        }
        public int GetAccountNumber()
        {
            return _accountNumber;
        }
        public void SetBalance(double balance)
        {
            if (balance < 0)
            {
                Console.WriteLine("Баланс не может быть отрицательным. Установка положительного значения");
                _balance = Math.Abs(balance);
            }
            else
            {
                _balance = balance;
            }
        }
        public double GetBalance()
        {
            return _balance;
        }
        public void SetBankAccountType(int bat)
        {
            if (bat == 1)
            {
                _bat = BankAccountType.current;
            }
            else if (bat == 2)
            {
                _bat = BankAccountType.savings;
            }
            else
            {
                Console.WriteLine("Неверный выбор. Устанавлиеватся значение по умолчанию");
            }
        }
        public BankAccountType GetBankAccountType()
        {
            return _bat;
        }
        private void IncreaseNumber()
        {
            magnifier++;
        }
        public void AddBalance(double money)
        {
            _balance += money;
        }
        public void RemoveBalance(double money)
        {

            if (_balance < money)
            {
                Console.WriteLine("\nНедостаточно денег на счете");
            }
            else
            {
                _balance -= money;
            }
        }
        public void Transfer(BankAccount ba, double money)
        {
            if (money < 0)
            {
                Console.WriteLine("\nСумма не может быть отрицательной");
            }
            else
            {
                if (ba._balance < money)
                {
                    Console.WriteLine("\nНедостаточно денег на счете");
                }
                else
                {
                    _balance += money;
                    ba._balance -= money;
                    Console.WriteLine($"\nПереведено {money} на счет");
                }
            }
        }
        public void Print()
        {
            Console.WriteLine($"\nНомер счета: {_accountNumber}\nБаланс: {_balance}\nТип: {_bat}");
        }
    }
}

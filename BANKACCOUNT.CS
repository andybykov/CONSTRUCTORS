
using System;
using System.Collections;

class BankAccount 
{
    private long accNo;
    private decimal accBal;
    private AccountType accType;
    private Queue tranQueue = new Queue();
    private static long nextNumber = 123;

    private readonly decimal amount;
    private readonly DateTime when;


    public long Number() => accNo;
    public decimal Balance() => accBal;
    public string Type() => accType.ToString();

    public BankAccount()
    {
        accNo = NextNumber();
        accType = AccountType.Checking;
        accBal = 0;
    }

    public BankAccount(AccountType aType)
    {
        accNo = NextNumber();
        accType = aType;
        accBal = 0;
    }

    public BankAccount(decimal aBal)
    {
        accNo = NextNumber();
        accType = AccountType.Checking;
        accBal = aBal;
    }

    public BankAccount(AccountType aType, decimal aBal)
    {
        accNo = NextNumber();
        accType = aType;
        accBal = aBal;
    }

    public void Populate(decimal balance)
    {
        accNo = NextNumber();
        accBal = balance;
        accType = AccountType.Checking;
    }

    public bool Withdraw(decimal amount)
    {
        bool sufficientFunds = accBal >= amount;
        if (sufficientFunds)
        {
            accBal -= amount;
            BankTransaction tran = new BankTransaction(-amount);
            tranQueue.Enqueue(tran);
        }
        return sufficientFunds;
    }


    public decimal Deposit(decimal amount)
    {
        accBal += amount;
        BankTransaction tran = new BankTransaction(amount);
        tranQueue.Enqueue(tran);
        return accBal;
    }

    private static long NextNumber()
    {
        return nextNumber++;
    }

    public Queue Transactions()
    {
        return tranQueue;
    }
}

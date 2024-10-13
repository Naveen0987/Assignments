using System;
using System.Collections.Generic;
using System.Threading;

public class Account
{
    public string AccountId { get; private set; }
    public decimal Balance { get; private set; }
    private readonly object balanceLock = new object();

    public Account(string accountId, decimal initialBalance = 0)
    {
        AccountId = accountId;
        Balance = initialBalance;
    }

    public bool Withdraw(decimal amount)
    {
        lock (balanceLock)
        {
            if (amount > Balance)
            {
                Console.WriteLine($"Insufficient funds in account {AccountId}.");
                return false;
            }

            Balance -= amount;
            return true;
        }
    }

    public void Deposit(decimal amount)
    {
        lock (balanceLock)
        {
            Balance += amount;
        }
    }
}

public class Transaction
{
    public string FromAccountId { get; private set; }
    public string ToAccountId { get; private set; }
    public decimal Amount { get; private set; }

    public Transaction(string fromAccountId, string toAccountId, decimal amount)
    {
        FromAccountId = fromAccountId;
        ToAccountId = toAccountId;
        Amount = amount;
    }

    public override string ToString()
    {
        return $"Transferred {Amount} from {FromAccountId} to {ToAccountId}";
    }
}

public class AccountManager
{
    private readonly List<Transaction> transactions = new List<Transaction>();
    private readonly object transactionLock = new object();

    public void Transfer(Account fromAccount, Account toAccount, decimal amount)
    {
        Thread transferThread = new Thread(() =>
        {
            if (fromAccount.Withdraw(amount))
            {
                toAccount.Deposit(amount);
                Transaction transaction = new Transaction(fromAccount.AccountId, toAccount.AccountId, amount);
                lock (transactionLock)
                {
                    transactions.Add(transaction);
                    Console.WriteLine(transaction);
                }
            }
            else
            {
                Console.WriteLine($"Transfer failed from {fromAccount.AccountId} to {toAccount.AccountId}.");
            }
        });

        transferThread.Start();
        transferThread.Join(); 
    }

    public void PrintTransactions()
    {
        lock (transactionLock)
        {
            Console.WriteLine("Transaction History:");
            foreach (var transaction in transactions)
            {
                Console.WriteLine(transaction);
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Account account1 = new Account("001", 500);
        Account account2 = new Account("002", 300);
        Account account3 = new Account("003", 400);

        AccountManager manager = new AccountManager();

        manager.Transfer(account1, account2, 200);
        manager.Transfer(account2, account3, 100);
        manager.Transfer(account3, account1, 50);

        Console.WriteLine($"Account 1 Balance: {account1.Balance}");
        Console.WriteLine($"Account 2 Balance: {account2.Balance}");
        Console.WriteLine($"Account 3 Balance: {account3.Balance}");

        manager.PrintTransactions();
    }
}

using bytebank_ATENDIMENTO.bytebank.Exceptions;
using bytebank_ATENDIMENTO.bytebank.Modelos.Conta;
using bytebank.Modelos.Conta;

namespace bytebank_ATENDIMENTO.bytebank.Service;

public class ByteBankService
{
  private readonly List<ContaCorrente?> _accountsList = new()
  {
    new ContaCorrente(123, new Cliente("111111111", "Bob", "Developer"),200),
    new ContaCorrente(876, new Cliente("222222222", "Maria", "Director"),500),
    new ContaCorrente(123, new Cliente("333333333", "John", "Account Manager"),1000)
  };

  public void CustomerService()
  {
    try
    {
      var option = '0';

      while (option != '6')
      {
        Console.Clear();
        Console.WriteLine($"=================================================\n" +
                          $"====                 Service                 ====\n" +
                          $"====  1 - Register Account                   ====\n" +
                          $"====  2 - List Accounts                      ====\n" +
                          $"====  3 - Remove Account                     ====\n" +
                          $"====  4 - Order Accounts                     ====\n" +
                          $"====  5 - Search Account                     ====\n" +
                          $"====  6 - Leave System                       ====\n" +
                          $"=================================================");
        Console.WriteLine("\n\n");
        Console.Write("Enter an option: ");
        try
        {
          option = Console.ReadLine()![0];
        }
        catch (Exception e)
        {
          throw new ByteBankException(e.Message);
        }

        switch (option)
        {
          case '1':
            RegisterAccount();
            break;
          case '2':
            ListAccounts();
            break;
          case '3':
            RemoveAccount();
            break;
          case '4':
            OrderAccounts();
            break;
          case '5':
            SearchAccount();
            break;
          case '6':
            LeaveSystem();
            break;
          default:
            Console.WriteLine("Option not implemented.");
            break;
        }
      }
    }
    catch (ByteBankException e)
    {
      Console.WriteLine(e.Message);
    }
  }

  private void RegisterAccount()
  {
    Console.Clear();
    Console.WriteLine($"=================================================\n" +
                      $"====            Register account             ====\n" +
                      $"=================================================");
    Console.WriteLine("\n");
    Console.WriteLine("====           Inform account details         ====");

    Console.Write("Agency Number: ");
    var numberAgency = int.Parse(Console.ReadLine()!);

    Console.Write("Holder Name: ");
    var holderName = Console.ReadLine()!;

    Console.Write("CPF: ");
    var cpf = Console.ReadLine()!;

    Console.Write("Profession: ");
    var profession = Console.ReadLine()!;
    
    Console.Write("Initial balance: ");
    var balance = double.Parse(Console.ReadLine()!);

    var account = new ContaCorrente(numberAgency, new Cliente(cpf, holderName, profession),balance);
    _accountsList.Add(account);
    Console.WriteLine("Account registered successfully!");
    Console.ReadKey();
  }

  private void ListAccounts()
  {
    Console.Clear();
    Console.WriteLine($"=================================================\n" +
                      $"====              List accounts              ====\n" +
                      $"=================================================");
    Console.WriteLine("\n");

    if (_accountsList.Count <= 0)
    {
      Console.WriteLine("There are no registered accounts!");
      Console.ReadKey();
      return;
    }

    foreach (ContaCorrente? account in _accountsList)
    {
      Console.WriteLine(account!.ToString());
      Console.ReadKey();
    }
  }

  private void RemoveAccount()
  {
    Console.Clear();
    Console.WriteLine($"=================================================\n" +
                      $"====              Remove account             ====\n" +
                      $"=================================================");
    Console.WriteLine("\n");
    Console.Write("Enter an account number: ");
    var accountNumber = Console.ReadLine()!;

    ContaCorrente? account = null;

    foreach (var accounts in _accountsList)
      if (accounts!.Conta.Equals(accountNumber))
        account = accounts;

    if (account != null)
    {
      _accountsList.Remove(account);
      Console.WriteLine("Account removed on the list!");
    }
    else
      Console.WriteLine("Account for removal not found.");

    Console.ReadKey();
  }

  private void OrderAccounts()
  {
    Console.Clear();
    Console.WriteLine($"=================================================\n" +
                      $"====              Order accounts             ====\n" +
                      $"=================================================");
    Console.WriteLine("\n");

    _accountsList.Sort();
    Console.WriteLine("Accounts list ordered.");
    Console.ReadKey();
  }

  private void SearchAccount()
  {
    Console.Clear();
    Console.WriteLine($"=================================================\n" +
                      $"====              Search account             ====\n" +
                      $"=================================================");
    Console.WriteLine("\n");

    Console.Write("Want to search for (1) Number Account, (2) Holder CPF, (3) Agency Number: ");
    switch (int.Parse(Console.ReadLine()!))
    {
      case 1:
        Console.Write("\nEnter an number account: ");
        var numberAccount = Console.ReadLine();
        var searchAccount = SearchForAccountNumber(numberAccount);
        Console.WriteLine(searchAccount!.ToString());
        Console.ReadKey();
        break;
      case 2:
        Console.Write("\nEnter holder CPF: ");
        var cpf = Console.ReadLine();
        var searchCpf = SearchForHolderCpf(cpf);
        Console.WriteLine(searchCpf!.ToString());
        Console.ReadKey();
        break;
      case 3:
        Console.Write("\nEnter Agency number: ");
        var agency = int.Parse(Console.ReadLine()!);
        var agencyNumber = SearchForAgencyNumber(agency);
        DisplayAccountsList(agencyNumber);
        Console.ReadKey();
        break;
      default:
        Console.WriteLine("Invalid option.");
        break;
    }

    ContaCorrente? SearchForAccountNumber(string? numberAccount)
    {
      return _accountsList.FirstOrDefault(account => account!.Conta.Equals(numberAccount));
    }

    ContaCorrente? SearchForHolderCpf(string? cpf)
    {
      return _accountsList.FirstOrDefault(account => account!.Titular.Cpf.Equals(cpf));
    }

    List<ContaCorrente> SearchForAgencyNumber(int agencyNumber)
    {
      var search = (
        from account in _accountsList
        where account.Numero_agencia.Equals(agencyNumber)
        select account
      ).ToList();

      return search;
    }

    void DisplayAccountsList(List<ContaCorrente>? accountsPerAgency)
    {
      if (accountsPerAgency == null)
        Console.WriteLine("Don't have accounts for this agency.");
      else
        foreach (var account in accountsPerAgency)
          Console.WriteLine(account.ToString());
    }
  }

  private static void LeaveSystem()
  {
    Console.WriteLine("Leaving system...");
    Console.ReadKey();
  }
}
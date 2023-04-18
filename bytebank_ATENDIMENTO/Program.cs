// Console.WriteLine("Welcome to the AnyBank.");

using System.Collections;
using bytebank_ATENDIMENTO.bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Util;
using bytebank.Modelos.Conta;

#region Test Arrays

void ArrayAges()
{
  int[] ages = { 30, 40, 17, 21, 18 };

  for (int i = 0; i < ages.Length; i++)
  {
    Console.WriteLine($"Age {i}: {ages[i]}");
  }

  Console.WriteLine($"Average ages: {ages.Average()}");
}

// ArrayAges();

void SearchWords()
{
  string[] words = new string[5];

  for (int i = 0; i < words.Length; i++)
  {
    Console.Write($"Write a single words: ");
    words[i] = Console.ReadLine();
  }

  Console.Write("Write a word to search: ");
  var search = Console.ReadLine();

  foreach (var word in words)
  {
    if (word.Equals(search))
    {
      Console.WriteLine($"Word \"{search}\" found.");
      break;
    }
  }
}

// SearchWords();

Array samples = new double[5];
samples.SetValue(5.9, 0);
samples.SetValue(1.8, 1);
samples.SetValue(7.1, 2);
samples.SetValue(10, 3);
samples.SetValue(6.9, 4);

void TestMedian(Array? array)
{
  if (array == null || array.Length == 0)
  {
    Console.WriteLine("Array for median search, it's empty or null.");
  }

  var sortNumbers = (double[])array?.Clone()!;
  Array.Sort(sortNumbers);

  var size = sortNumbers.Length;
  var middle = size / 2;
  var median = size % 2 != 0 ? sortNumbers[middle] : (sortNumbers[middle] + sortNumbers[middle - 1]) / 2;

  Console.WriteLine($"\nWith base in samples, the median == {median}");
}

// TestMedian(samples);

void TestAccounts()
{
  // ContaCorrente[] accountList =
  // {
  //   new(852, new Cliente("1111111", "Bob", "Dev")),
  //   new(852, new Cliente("2222222", "Maria", "Financial Manager")),
  //   new(852, new Cliente("3333333", "John", "Manager")),
  //   new(852, new Cliente("4444444", "Bia", "Director"))
  // };
  //
  // for (int i = 0; i < accountList.Length; i++)
  // {
  //   Console.WriteLine($"\nIndex {i}: {accountList[i]}");
  // }


  AccountsList accountsList = new AccountsList();
  accountsList.Add(new ContaCorrente(852, new Cliente("1111111", "Bob", "Dev")));
  accountsList.Add(new ContaCorrente(852, new Cliente("2222222", "Maria", "Financial Manager")));
  accountsList.Add(new ContaCorrente(852, new Cliente("3333333", "John", "Manager")));
  accountsList.Add(new ContaCorrente(852, new Cliente("3333333", "John", "Manager")));
  accountsList.Add(new ContaCorrente(852, new Cliente("3333333", "John", "Manager")));
  accountsList.Add(new ContaCorrente(852, new Cliente("3333333", "John", "Manager")));

  var account1 = new ContaCorrente(921, new Cliente("Suzy", "5555555", "Teacher"));
  accountsList.Add(account1);
  // Console.WriteLine();
  accountsList.ShowAccount();
  // Console.WriteLine();
  // accountsList.Remove(account1);
  // accountsList.ShowAccount();

  var indexId = 2;
  ContaCorrente accountTest = accountsList[indexId];
  Console.WriteLine();
  Console.WriteLine($"Index ID: {indexId} - Account: {accountTest.Conta} - Number: {accountTest.Numero_agencia}");
}

// TestAccounts();

#endregion


ArrayList _accountsList = new ArrayList();

void CustomerService()
{
  char option = '0';

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
    option = Console.ReadLine()[0];

    switch (option)
    {
      case '1':
        RegisterAccount();
        break;
      case '2':
        ListAccounts();
        break;
      default:
        Console.WriteLine("Option not implemented.");
        break;
    }
  }
}

void RegisterAccount()
{
  Console.Clear();
  Console.WriteLine($"=================================================\n" +
                    $"====            Register account             ====\n" +
                    $"=================================================");
  Console.WriteLine("\n");
  Console.WriteLine("====           Inform account details         ====");
  
  Console.Write("Agency Number: ");
  int numberAgency = int.Parse(Console.ReadLine());
  
  Console.Write("Holder Name: ");
  string holderName = Console.ReadLine();
  
  Console.Write("CPF: ");
  string cpf = Console.ReadLine();
  
  Console.Write("Profession: ");
  string profession = Console.ReadLine();

  ContaCorrente account = new ContaCorrente(numberAgency, new Cliente(cpf, holderName, profession));
  _accountsList.Add(account);
  Console.WriteLine("Account registered successfully!");
  Console.ReadKey();
}

void ListAccounts()
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

  foreach (ContaCorrente account in _accountsList)
  {
    Console.WriteLine($"====    Account details   ====\n\n" +
                      $"Number account: {account.Conta}\n" +
                      $"Holder Name: {account.Titular.Nome}\n" +
                      $"CPF: {account.Titular.Cpf}\n" +
                      $"Profession: {account.Titular.Profissao}\n");
    Console.ReadKey();
  }
}

CustomerService();
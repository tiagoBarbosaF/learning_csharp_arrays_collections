using System.Collections;
using bytebank_ATENDIMENTO.bytebank.Exceptions;
using bytebank_ATENDIMENTO.bytebank.Service;
using bytebank_ATENDIMENTO.bytebank.Util;
using bytebank_Modelos.bytebank.Modelos.ADM.Utilitario;
using bytebank_Modelos.bytebank.Modelos.Conta;
using bytebank_PixKeyGenerator;
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
  accountsList.Add(new ContaCorrente(852, new Cliente("1111111", "Bob", "Dev"),100));
  accountsList.Add(new ContaCorrente(852, new Cliente("2222222", "Maria", "Financial Manager"),100));
  accountsList.Add(new ContaCorrente(852, new Cliente("3333333", "John", "Manager"),100));
  accountsList.Add(new ContaCorrente(852, new Cliente("3333333", "John", "Manager"),100));
  accountsList.Add(new ContaCorrente(852, new Cliente("3333333", "John", "Manager"),100));
  accountsList.Add(new ContaCorrente(852, new Cliente("3333333", "John", "Manager"),100));

  var account1 = new ContaCorrente(921, new Cliente("Suzy", "5555555", "Teacher"),100);
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

// var service = new ByteBankService();
// service.CustomerService();

var listKeys = PixGenerator.GetPixKeys(5);

foreach (var key in listKeys!)
{
  Console.WriteLine(key);
}
#region List examples

// List<ContaCorrente> _accountList2 = new List<ContaCorrente>()
// {
//   new(123,new Cliente("111111111","Bob", "Developer")),
//   new(123,new Cliente("222222222","Maria", "Director")),
//   new(123,new Cliente("333333333","John", "Account Manager"))
// };
//
// List<ContaCorrente> _accountList3 = new List<ContaCorrente>()
// {
//   new(456,new Cliente("444444444","Mary", "Developer")),
//   new(456,new Cliente("555555555","Paul", "Director")),
//   new(456,new Cliente("666666666","Bia", "Account Manager"))
// };
//
// Console.WriteLine("List 2:");
// for (int i = 0; i < _accountList2.Count; i++)
// {
//   Console.WriteLine($"Index [{i}] - Account: {_accountList2[i].Conta}, Holder: {_accountList2[i].Titular}");
// }
//
// _accountList2.AddRange(_accountList3);
// Console.WriteLine();
// Console.WriteLine("List 2 adding List 3:");
// for (int i = 0; i < _accountList2.Count; i++)
// {
//   Console.WriteLine($"Index [{i}] - Account: {_accountList2[i].Conta}, Holder: {_accountList2[i].Titular}");
// }
//
// _accountList2.Reverse();
// Console.WriteLine();
// Console.WriteLine("List 2 reverse:");
// for (int i = 0; i < _accountList2.Count; i++)
// {
//   Console.WriteLine($"Index [{i}] - Account: {_accountList2[i].Conta}, Holder: {_accountList2[i].Titular}");
// }
//
// Console.WriteLine();
// var range = _accountList3.GetRange(0,2);
// Console.WriteLine("List 3 range index:");
// for (int i = 0; i < range.Count; i++)
// {
//   Console.WriteLine($"Index [{i}] - Account: {range[i].Conta}, Holder: {range[i].Titular}");
// }
//
// Console.WriteLine();
// _accountList3.Clear();
// Console.WriteLine("List 3 clear:");
// for (int i = 0; i < _accountList3.Count; i++)
// {
//   Console.WriteLine($"Index [{i}] - Account: {_accountList3[i].Conta}, Holder: {_accountList3[i].Titular}");
// }

#endregion
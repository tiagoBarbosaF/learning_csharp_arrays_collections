using bytebank_ATENDIMENTO.bytebank.Modelos.Conta;
using bytebank.Modelos.Conta;

namespace bytebank_ATENDIMENTO.bytebank.Util;

public class AccountsList
{
  private ContaCorrente[] _accounts = null;
  private int _nextPosition = 0;

  public AccountsList(int initialSize = 5)
  {
    _accounts = new ContaCorrente[initialSize];
  }

  public void Add(ContaCorrente contaCorrente)
  {
    Console.WriteLine($"Adding account in position: {_nextPosition}");
    CheckCapacity(_nextPosition + 1);
    _accounts[_nextPosition] = contaCorrente;
    _nextPosition++;
  }

  public void Remove(ContaCorrente contaCorrente)
  {
    int indexAccount = -1;
    for (int i = 0; i < _nextPosition; i++)
    {
      ContaCorrente actualAccount = _accounts[i];
      if (actualAccount == contaCorrente)
      {
        indexAccount = i;
        break;
      }
    }

    for (int i = indexAccount; i < _nextPosition - 1; i++)
    {
      _accounts[i] = _accounts[i + 1];
    }

    _nextPosition--;
    _accounts[_nextPosition] = null;
  }

  private void CheckCapacity(int necessarySize)
  {
    if (_accounts.Length >= necessarySize)
    {
      return;
    }

    Console.WriteLine($"Increasing list capacity.");
    ContaCorrente[] newArray = new ContaCorrente[necessarySize];

    for (int i = 0; i < _accounts.Length; i++)
    {
      newArray[i] = _accounts[i];
    }

    _accounts = newArray;
  }

  public ContaCorrente HighestBalance()
  {
    ContaCorrente contaCorrente = null;
    double highestValue = 0;

    for (int i = 0; i < _accounts.Length; i++)
    {
      if (_accounts[i] != null)
      {
        if (highestValue < _accounts[i].Saldo)
        {
          highestValue = _accounts[i].Saldo;
          contaCorrente = _accounts[i];
        }
      }
    }

    return contaCorrente;
  }

  public void ShowAccount()
  {
    for (int i = 0; i < _accounts.Length; i++)
    {
      if (_accounts[i] != null)
      {
        var account = _accounts[i];
        Console.WriteLine($"Index {i}: Account: {account.Conta} - Number: {account.Numero_agencia}");
      }
    }
  }

  public ContaCorrente AccountByIndex(int index)
  {
    if (index < 0 || index >= _nextPosition)
    {
      throw new ArgumentOutOfRangeException(nameof(index));
    }

    return _accounts[index];
  }

  public ContaCorrente this[int index]
  {
    get => AccountByIndex(index);
  }
}
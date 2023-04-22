using bytebank.Modelos.Conta;

namespace bytebank_ATENDIMENTO.bytebank.Modelos.Conta
{
  public class ContaCorrente : IComparable<ContaCorrente>
  {
    private int _numero_agencia;

    private string _conta;

    private double saldo;

    public Cliente Titular { get; set; }

    public string Nome_Agencia { get; set; }

    public int Numero_agencia
    {
      get { return _numero_agencia; }
      set
      {
        if (value > 0)
        {
          _numero_agencia = value;
        }
      }
    }

    public string Conta
    {
      get { return _conta; }
      set
      {
        if (value != null)
        {
          _conta = value;
        }
      }
    }

    public double Saldo
    {
      get { return saldo; }
      set
      {
        if (!(value < 0.0))
        {
          saldo = value;
        }
      }
    }

    public static int TotalDeContasCriadas { get; set; }

    public bool Sacar(double valor)
    {
      if (saldo < valor)
      {
        return false;
      }

      if (valor < 0.0)
      {
        return false;
      }

      saldo -= valor;
      return true;
    }

    public void Depositar(double valor)
    {
      if (!(valor < 0.0))
      {
        saldo += valor;
      }
    }

    public bool Transferir(double valor, ContaCorrente destino)
    {
      if (saldo < valor)
      {
        return false;
      }

      if (valor < 0.0)
      {
        return false;
      }

      saldo -= valor;
      destino.saldo += valor;
      return true;
    }

    public ContaCorrente(int numero_agencia, Cliente titular)
    {
      Numero_agencia = numero_agencia;
      Conta = Guid.NewGuid().ToString().Substring(0, 8);
      Titular = titular;
      Saldo = 100;
      TotalDeContasCriadas++;
    }

    public int CompareTo(ContaCorrente? other)
    {
      if (other == null)
      {
        return 1;
      }
      else
      {
        return Numero_agencia.CompareTo(other.Numero_agencia);
      }
    }

    public override string ToString()
    {
      return $"\nAccount:\n" +
             $"- Agency number: {Numero_agencia}\n" +
             $"- Number account: {Conta}\n" +
             $"- Balance: {Saldo}\n" +
             $"Holder\n" +
             $"- Name: {Titular.Nome}\n" +
             $"- CPF: {Titular.Cpf}\n" +
             $"- Profession: {Titular.Profissao}\n";
    }
  }
}
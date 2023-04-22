namespace bytebank_ATENDIMENTO.bytebank.Exceptions;

public class ByteBankException : Exception
{
  public ByteBankException()
  {
  }

  public ByteBankException(string message) : base($"Threw an exception -> {message}")
  {
  }

  public ByteBankException(string message, Exception inner) : base(message, inner)
  {
  }
}
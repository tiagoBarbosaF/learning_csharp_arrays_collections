namespace bytebank_Modelos.bytebank.Modelos.ADM.Utilitario;

internal class UtilAuthentication
{
  public bool PasswordValidation(string truePassword, string tentativePassword)
  {
    return truePassword.Equals(tentativePassword);
  }
}
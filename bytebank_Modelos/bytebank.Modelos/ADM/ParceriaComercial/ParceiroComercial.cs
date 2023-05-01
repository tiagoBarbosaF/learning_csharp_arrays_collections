using bytebank_Modelos.bytebank.Modelos.ADM.Utilitario;
using bytebank.Modelos.ADM.SistemaInterno;

namespace bytebank_Modelos.bytebank.Modelos.ADM.ParceriaComercial
{
  public class ParceiroComercial : IAutenticavel
  {
    private UtilAuthentication authenticator = new();
    public string Password { get; set; }

    public bool Authenticate(string password)
    {
      return authenticator.PasswordValidation(Password, password);
    }
  }
}
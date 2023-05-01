using bytebank_Modelos.bytebank.Modelos.ADM.Utilitario;
using bytebank.Modelos.ADM.Funcionarios;
using bytebank.Modelos.ADM.SistemaInterno;

namespace bytebank_Modelos.bytebank.Modelos.ADM.Funcionarios
{
  public abstract class FuncionarioAutenticavel : Funcionario, IAutenticavel
  {
    private UtilAuthentication authenticator = new();
    public string Password { get; set; }

    public FuncionarioAutenticavel(double salario, string cpf)
      : base(salario, cpf)
    {
    }

    public bool Authenticate(string password)
    {
      return authenticator.PasswordValidation(Password, password);
    }
  }
}
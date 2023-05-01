namespace bytebank.Modelos.ADM.SistemaInterno
{
    public interface IAutenticavel
    {
        bool Authenticate(string password);
    }
}

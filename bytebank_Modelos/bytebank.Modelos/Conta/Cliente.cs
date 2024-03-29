﻿namespace bytebank.Modelos.Conta
{
  public class Cliente
  {
    public string Cpf { get; set; }

    private string _nome;

    public string Nome
    {
      get { return _nome; }
      set
      {
        if (value.Length < 3)
        {
          Console.WriteLine("Nome do titular precisa ter pelo menos 3 caracteres.");
        }
      }
    }

    //public string Nome { get; set; }
    public string Profissao { get; set; }

    public static int TotalClientesCadastrados { get; set; }

    public Cliente(string cpf, string nome, string profissao)
    {
      Cpf = cpf;
      _nome = nome;
      Profissao = profissao;
      TotalClientesCadastrados += 1;
    }

    private Cliente()
    {
    }

    public override string ToString()
    {
      return $"Name: {Nome} - CPF: {Cpf} - Profession: {Profissao}";
    }
  }
}
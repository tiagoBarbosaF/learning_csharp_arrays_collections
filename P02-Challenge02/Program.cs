List<string> nomesDosEscolhidos = new List<string>()
{
  "Bruce Wayne",
  "Carlos Vilagran",
  "Richard Grayson",
  "Bob Kane",
  "Will Farrel",
  "Lois Lane",
  "General Welling",
  "Perla Letícia",
  "Uxas",
  "Diana Prince",
  "Elisabeth Romanova",
  "Anakin Wayne"
};


var nameSearch = "Anakin Wayne";
void searchName()
{
  foreach (var name in nomesDosEscolhidos)
  {
    if (name.Equals(nameSearch))
    {
      Console.WriteLine($"Name found: {name}");
      break;
    }
  }
}

Console.WriteLine($"Looking for the name: {nameSearch}\n");
searchName();
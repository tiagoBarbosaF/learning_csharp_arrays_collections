// Console.WriteLine("Welcome to the AnyBank.");

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

Console.WriteLine(samples.ToString());
foreach (var sample in samples)
{
  Console.Write($"{sample} ");
}

void TestMedian(Array? array)
{
  if (array == null || array.Length == 0)
  {
    Console.WriteLine("Array for median search, it's empty or null.");
  }

  var sortNumbers = (double[])array?.Clone()!;
  Array.Sort(sortNumbers);
  Console.WriteLine();
  foreach (var number in sortNumbers)
  {
    Console.Write($"{number} ");
  }

  var size = sortNumbers.Length;
  var middle = size / 2;
  var median = size % 2 != 0 ? sortNumbers[middle] : (sortNumbers[middle] + sortNumbers[middle - 1]) / 2;

  Console.WriteLine($"\nWith base in samples, the median == {median}");
}

TestMedian(samples);
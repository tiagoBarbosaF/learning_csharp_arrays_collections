double[] numbers = {3.2,15.4,2.8,45.9,28.1};

var average = numbers.Average();

foreach (var number in numbers)
{
  Console.WriteLine($"Numbers: {number}");
}
Console.WriteLine($"Average: {average:F}");
using ClassLibraryPrimeTens;
using System.Collections;
using System.Diagnostics;

int n = 1000;
int segmentCount = 10;
var res = PrimeTens.GetPrimeDistribution(PrimeTens.GetPrimeNumbersEratosthenes(n, new CancellationToken()), segmentCount);
foreach (var item in res)
{
    Console.WriteLine($"{item.start}-{item.end} {item.primeCount} {item.primePercent}");
}
Console.WriteLine();


int k = 40;
var r = PrimeTens.GetMinMaxTens(PrimeTens.GetPrimeNumbersEratosthenes(n, new CancellationToken()), k, new CancellationToken());
Console.WriteLine($"{r.minRangeStart}-{r.minRangeStart + k - 1} {r.minCount}");
Console.WriteLine($"{r.maxRangeStart}-{r.maxRangeStart + k - 1} {r.maxCount}");


//int n = 1_000_000;
//CancellationToken ct = new();
//(int min_count, int min_loc, int max_count, int max_loc) result;
//Stopwatch sw = Stopwatch.StartNew();
//BitArray nums = PrimeTens.GetPrimeNumbersEratosthenes(n, ct);
//result = PrimeTens.GetMinMaxTens(nums, ct);
//sw.Stop();
//Console.WriteLine("Timed tens of 1_000_000 Erathosphenes");
//Console.WriteLine($"min {result.min_loc}-{result.min_loc + 9}\n" +
//                $"min count {result.min_count}\n" +
//                $"max {result.max_loc}-{result.max_loc + 9}\n" +
//                $"max count {result.max_count}\n" +
//                $"time {sw.ElapsedMilliseconds}ms");
//Console.WriteLine();
//Console.WriteLine("Timed tens of 1_000_000 Square root");
//sw.Restart();
//BitArray nums2 = PrimeTens.GetPrimeNumbersSqrt(n, ct);
//result = PrimeTens.GetMinMaxTens(nums2, ct);
//sw.Stop();
//Console.WriteLine($"min {result.min_loc}-{result.min_loc + 9}\n" +
//                $"min count {result.min_count}\n" +
//                $"max {result.max_loc}-{result.max_loc + 9}\n" +
//                $"max count {result.max_count}\n" +
//                $"time {sw.ElapsedMilliseconds}ms");
//Console.WriteLine();
//Console.WriteLine("range without prime numbers before 1_000_000");
//{
//    int num = 1_000_000;
//    var resu = PrimeTens.FindMaxRangeWithoutPrimeNumbers(num);
//    Console.WriteLine($"range {resu.start}-{resu.end} length {resu.end - resu.start + 1}");
//}
//Console.WriteLine();
//Console.WriteLine("divisors of 1_000_000");
//{
//    int num = 1_000_000;
//    var resu = PrimeTens.FindDivisors(num);
//    Console.WriteLine("{");
//    foreach (var item in resu)
//    {
//        Console.WriteLine("\t" + item);
//    }
//    Console.WriteLine("}");
//}
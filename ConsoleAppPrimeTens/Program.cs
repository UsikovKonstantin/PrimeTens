using ClassLibraryPrimeTens;
using System.Diagnostics;
using System.Collections;

int n = 1_000_000;
CancellationToken ct = new();
(int, int, int, int) result;
Stopwatch sw = Stopwatch.StartNew();
BitArray nums = PrimeTens.GetPrimeNumbersEratosthenes(n, ct);
result = PrimeTens.GetMinMaxTens(nums, ct);
sw.Stop();
Console.WriteLine(sw.ElapsedMilliseconds);
Console.WriteLine($"{result.Item1} {result.Item2} {result.Item3} {result.Item4}");

sw.Restart();
BitArray nums2 = PrimeTens.GetPrimeNumbersSqrt(n, ct);
result = PrimeTens.GetMinMaxTens(nums2, ct);
sw.Stop();
Console.WriteLine(sw.ElapsedMilliseconds);
Console.WriteLine($"{result.Item1} {result.Item2} {result.Item3} {result.Item4}");
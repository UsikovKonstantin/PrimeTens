using ClassLibraryPrimeTens;
using System.Diagnostics;

int n = 1_000_000;

Stopwatch sw = Stopwatch.StartNew();
bool[] nums = PrimeTens.GetPrimeNumbersEratosthenes(n);
PrimeTens.GetMinMaxTens(nums, out int a, out int b, out int c, out int d);
sw.Stop();
Console.WriteLine(sw.ElapsedMilliseconds);
Console.WriteLine($"{a} {b} {c} {d}");

sw.Restart();
bool[] nums2 = PrimeTens.GetPrimeNumbersSqrt(n);
PrimeTens.GetMinMaxTens(nums2, out int a2, out int b2, out int c2, out int d2);
sw.Stop();
Console.WriteLine(sw.ElapsedMilliseconds);
Console.WriteLine($"{a2} {b2} {c2} {d2}");
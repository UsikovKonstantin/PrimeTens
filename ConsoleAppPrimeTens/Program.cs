using ClassLibraryPrimeTens;
using System.Collections;

CancellationToken ct = new();

AllTests();

void AllTests() {
    Console.Write("GetPrimeNumbersEratosthenesTest: ");
    Console.WriteLine(GetPrimeNumbersEratosthenesTest());
    Console.Write("GetArrayTest: ");
    Console.WriteLine(GetArrayTest());
    Console.Write("GetPrimeNumbersSqrtTest: ");
    Console.WriteLine(GetPrimeNumbersSqrtTest());
    Console.Write("IsPrimeTest: ");
    Console.WriteLine(IsPrimeTest());
    Console.Write("GetMinMaxSegmentsTest: ");
    Console.WriteLine(GetMinMaxSegmentsTest());
    Console.Write("GetDivisorsTest: ");
    Console.WriteLine(GetDivisorsTest());
    Console.Write("GetMaxRangeWithoutPrimeNumbersTest: ");
    Console.WriteLine(GetMaxRangeWithoutPrimeNumbersTest());
    Console.Write("GetPrimeDistributionTest: ");
    Console.WriteLine(GetPrimeDistributionTest());
}

bool GetPrimeNumbersEratosthenesTest() {
    bool[] arr = new bool[16] { false, false, true, true, false, true, false, true, false, false, false, true, false, true, false, false };
    BitArray test = new BitArray(arr);
    BitArray test2 = PrimeTens.GetPrimeNumbersEratosthenes(15, ct);
    for (int i = 0; i < arr.Length; i++) {
        if (test2[i] != test[i]) return false;
    }
    return true;
}

bool GetArrayTest() {
    bool[] arr = new bool[16] { false, false, true, true, true, true, true, true, true, true, true, true, true, true, true, true };
    BitArray test = new BitArray(arr);
    BitArray test2 = PrimeTens.GetArray(15);
    for (int i = 0; i < arr.Length; i++) {
        if (test2[i] != test[i]) return false;
    }
    return true;
}

bool GetPrimeNumbersSqrtTest() {
    bool[] arr = new bool[16] { false, false, true, true, false, true, false, true, false, false, false, true, false, true, false, false };
    BitArray test = new BitArray(arr);
    BitArray test2 = PrimeTens.GetPrimeNumbersSqrt(15, ct);
    for (int i = 0; i < arr.Length; i++) {
        if (test2[i] != test[i]) return false;
    }
    return true;
}

bool IsPrimeTest() {
    bool[] arr = new bool[15] { true, true, true, false, true, false, true, false, false, false, true, false, true, false, false };
    bool[] test = new bool[15];
    for (int i = 3; i < test.Length; i++) {
        test[i] = PrimeTens.IsPrime(i);
        if (test[i] != arr[i - 1]) return false;
    }
    return true;
}

bool GetMinMaxSegmentsTest() {
    (int, int, int, int) minMaxSegments;
    minMaxSegments = PrimeTens.GetMinMaxSegments(1000, 10, Prime_Method.Erathosphenes, ct);

    bool result = true;
    result &= minMaxSegments.Item1 == 0;
    result &= minMaxSegments.Item2 == 891;
    result &= minMaxSegments.Item3 == 4;
    result &= minMaxSegments.Item4 == 821;
    minMaxSegments = PrimeTens.GetMinMaxSegments(100000, 10, Prime_Method.Erathosphenes, ct);
    result &= minMaxSegments.Item1 == 0;
    result &= minMaxSegments.Item2 == 99951;
    result &= minMaxSegments.Item3 == 4;
    result &= minMaxSegments.Item4 == 99131;
    return result;
}

bool GetDivisorsTest() {
    bool result = true;

    ulong x = 24;
    List<ulong> list = PrimeTens.GetDivisors(x, ct);
    List<ulong> list2 = new List<ulong> { 1, 2, 3, 4, 6, 8, 12, 24 };
    result &= list.SequenceEqual(list2);

    x = 29;
    list = PrimeTens.GetDivisors(x, ct);
    list2 = new List<ulong> { 1, 29 };
    result &= list.SequenceEqual(list2);

    x = 100;
    list = PrimeTens.GetDivisors(x, ct);
    list2 = new List<ulong> { 1, 2, 4, 5, 10, 20, 25, 50, 100 };
    result &= list.SequenceEqual(list2);
    return result;
}

bool GetMaxRangeWithoutPrimeNumbersTest() {
    int x = 10;
    (int start, int end) res = PrimeTens.GetMaxRangeWithoutPrimeNumbers(x, Prime_Method.Erathosphenes, ct);
    (int start, int end) res2 = (8, 10);
    return res.Equals(res2);
}

bool GetPrimeDistributionTest() {
    List<(ulong start, ulong end, ulong primeCount, double primePercent)> list;
    list = PrimeTens.GetPrimeDistribution(100, 10, ct);
    List<(ulong start, ulong end, ulong primeCount, double primePercent)> list2;
    list2 = new() {(1, 10, 4, 0.4), (11, 20, 4, 0.4), (21, 30, 2, 0.2),
    (31,40,2,0.2), (41,50,3,0.3), (51,60,2,0.2),
    (61,70,2,0.2), (71,80, 3,0.3), (81,90,2,0.2),
    (91,100, 1, 0.1)};
    return list.SequenceEqual(list2);
}

//int n = 100;
//int k = 10;

//var res = PrimeTens.GetPrimeDistribution((ulong)n, (ulong)k, new CancellationToken());
//foreach (var item in res) {
//    Console.WriteLine($"{item.start} {item.end} {item.primeCount} {item.primePercent}");
//}
//Console.WriteLine();

//var res2 = PrimeTens.GetPrimeDistribution(n, k, Prime_Method.Erathosphenes, new CancellationToken());
//foreach (var item in res2) {
//    Console.WriteLine($"{item.start} {item.end} {item.primeCount} {item.primePercent}");
//}

//int n = 1000;
//int segmentCount = 10;
//var res = PrimeTens.GetPrimeDistribution(PrimeTens.GetPrimeNumbersEratosthenes(n, new CancellationToken()), segmentCount);
//foreach (var item in res)
//{
//    Console.WriteLine($"{item.start}-{item.end} {item.primeCount} {item.primePercent}");
//}
//Console.WriteLine();


//int k = 40;
//var r = PrimeTens.GetMinMaxTens(PrimeTens.GetPrimeNumbersEratosthenes(n, new CancellationToken()), k, new CancellationToken());
//Console.WriteLine($"{r.minRangeStart}-{r.minRangeStart + k - 1} {r.minCount}");
//Console.WriteLine($"{r.maxRangeStart}-{r.maxRangeStart + k - 1} {r.maxCount}");


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
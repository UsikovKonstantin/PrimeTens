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
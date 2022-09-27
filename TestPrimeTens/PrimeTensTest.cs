using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using ClassLibraryPrimeTens;
using System.Collections;
using System.Collections.Generic;

namespace TestPrimeTens {
    [TestClass]
    public class PrimeTensTest {
        CancellationToken ct = new();

        [TestMethod]
        public void GetPrimeNumbersEratosthenesTest() {
            bool[] arr = new bool[16] { false, false, true, true, false, true, false, true, false, false, false, true, false, true, false, false };
            BitArray test = new BitArray(arr);
            BitArray test2 = PrimeTens.GetPrimeNumbersEratosthenes(15, ct);
            for (int i = 0; i < arr.Length; i++) {
                Assert.IsTrue(test2[i] == test[i]);
            }
        }

        [TestMethod]
        public void GetArrayTest() {
            bool[] arr = new bool[16] { false, false, true, true, true, true, true, true, true, true, true, true, true, true, true, true };
            BitArray test = new BitArray(arr);
            BitArray test2 = PrimeTens.GetArray(15);
            for (int i = 0; i < arr.Length; i++) {
                Assert.IsTrue(test2[i] == test[i]);
            }
        }

        [TestMethod]
        public void GetPrimeNumbersSqrtTest() {
            bool[] arr = new bool[16] { false, false, true, true, false, true, false, true, false, false, false, true, false, true, false, false };
            BitArray test = new BitArray(arr);
            BitArray test2 = PrimeTens.GetPrimeNumbersSqrt(15, ct);
            for (int i = 0; i < arr.Length; i++) {
                Assert.IsTrue(test2[i] == test[i]);
            }
        }

        [TestMethod]
        public void IsPrimeTest() {
            bool[] arr = new bool[15] { true, true, true, false, true, false, true, false, false, false, true, false, true, false, false };
            bool[] test = new bool[15];
            for (int i = 3; i < test.Length; i++) {
                test[i] = PrimeTens.IsPrime(i);
                Assert.IsTrue(test[i] == arr[i - 1]);
            }
        }

        [TestMethod]
        public void GetMinMaxSegmentsTest() {
            (int, int, int, int) result;
            (ulong, ulong, ulong, ulong) result2;
            result = PrimeTens.GetMinMaxSegments(1000, 10, Prime_Method.Erathosphenes, ct);
            result2 = PrimeTens.GetMinMaxSegments(1000, 10, ct);
            Assert.IsTrue(result.Item1 == 0 && result2.Item1 == 0);
            Assert.IsTrue(result.Item2 == 891 && result2.Item2 == 891);
            Assert.IsTrue(result.Item3 == 4 && result2.Item3 == 4);
            Assert.IsTrue(result.Item4 == 821 && result2.Item4 == 821);
            result = PrimeTens.GetMinMaxSegments(100000, 10, Prime_Method.Erathosphenes, ct);
            result2 = PrimeTens.GetMinMaxSegments(100000, 10, ct);
            Assert.IsTrue(result.Item1 == 0 && result2.Item1 == 0);
            Assert.IsTrue(result.Item2 == 99951 && result2.Item2 == 99951);
            Assert.IsTrue(result.Item3 == 4 && result2.Item3 == 4);
            Assert.IsTrue(result.Item4 == 99131 && result2.Item4 == 99131);
        }

        [TestMethod]
        public void GetDivisorsTest() {
            ulong x = 24;
            List<ulong> list = PrimeTens.GetDivisors(x, ct);
            List<ulong> list2 = new List<ulong> { 1, 2, 3, 4, 6, 8, 12, 24 };
            CollectionAssert.AreEqual(list, list2);

            x = 29;
            list = PrimeTens.GetDivisors(x, ct);
            list2 = new List<ulong> { 1, 29 };
            CollectionAssert.AreEqual(list, list2);

            x = 100;
            list = PrimeTens.GetDivisors(x, ct);
            list2 = new List<ulong> { 1, 2, 4, 5, 10, 20, 25, 50, 100 };
            CollectionAssert.AreEqual(list, list2);
        }

        [TestMethod]
        public void GetMaxRangeWithoutPrimeNumbersTest() {
            (int start, int end) res = PrimeTens.GetMaxRangeWithoutPrimeNumbers(10, Prime_Method.Erathosphenes, ct);
            (ulong start, ulong end) res2 = PrimeTens.GetMaxRangeWithoutPrimeNumbers(10, ct);
            (int start, int end) res3 = (8, 10);
            Assert.IsTrue(res.start == (int)res2.start && res.start == res3.start);
            Assert.IsTrue(res.end == (int)res2.end && res.end == res3.end);
        }

        [TestMethod]
        public void GetPrimeDistributionTest() {
            List<(int start, int end, int primeCount, double primePercent)> list;
            list = PrimeTens.GetPrimeDistribution(100, 10, Prime_Method.Erathosphenes, ct);
            List<(ulong start, ulong end, ulong primeCount, double primePercent)> list2;
            list2 = PrimeTens.GetPrimeDistribution(100, 10, ct);
            List<(int start, int end, int primeCount, double primePercent)> list3;
            list3 = new() {(1, 10, 4, 0.4), (11, 20, 4, 0.4),(21, 30, 2, 0.2),
            (31,40,2,0.2), (41,50,3,0.3), (51,60,2,0.2),
            (61,70,2,0.2), (71,80, 3,0.3), (81,90,2,0.2),
            (91,100, 1, 0.1)};
            CollectionAssert.AreEqual(list, list3);
            var list2Converted = list2.ConvertAll(x => ((int)x.start, (int)x.end, (int)x.primeCount, x.primePercent));
            CollectionAssert.AreEqual(list2Converted, list3);
        }

    }
}
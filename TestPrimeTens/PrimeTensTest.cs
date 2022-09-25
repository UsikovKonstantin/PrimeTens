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
            result = PrimeTens.GetMinMaxSegments(1000, 10, Prime_Method.Erathosphenes, ct);
            Assert.IsTrue(result.Item1 == 0);
            Assert.IsTrue(result.Item2 == 891);
            Assert.IsTrue(result.Item3 == 4);
            Assert.IsTrue(result.Item4 == 821);
            result = PrimeTens.GetMinMaxSegments(100000, 10, Prime_Method.Erathosphenes, ct);
            Assert.IsTrue(result.Item1 == 0);
            Assert.IsTrue(result.Item2 == 99951);
            Assert.IsTrue(result.Item3 == 4);
            Assert.IsTrue(result.Item4 == 99131);
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
            int x = 10;
            var res = PrimeTens.GetMaxRangeWithoutPrimeNumbers(x, Prime_Method.Erathosphenes, ct);
            var res2 = (8, 10);
            Assert.AreEqual(res, res2);
        }

        [TestMethod]
        public void GetPrimeDistributionTest() {
            List<(ulong start, ulong end, ulong primeCount, double primePercent)> list;
            list = PrimeTens.GetPrimeDistribution(100, 10, ct);
            List<(ulong start, ulong end, ulong primeCount, double primePercent)> list2;
            list2 = new() { (1, 10, 4, 0.4), (11, 20, 4, 0.4),(21, 30, 2, 0.2),
            (31,40,2,0.2), (41,50,3,0.3), (51,60,2,0.2),
            (61,70,2,0.2), (71,80, 3,0.3), (81,90,2,0.2),
            (91,100, 1, 0.1)};
            CollectionAssert.AreEqual(list, list2);
        }

    }
}
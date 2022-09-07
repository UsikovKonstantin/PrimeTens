using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using ClassLibraryPrimeTens;
using System.Collections;

namespace TestPrimeTens
{
    [TestClass]
    public class PrimeTensTest
    {
        CancellationToken ct = new();
        [TestMethod]
        public void GetPrimeNumbersEratosthenesTest()
        {
            bool[] arr = new bool[16] { false, false, true, true, false, true, false, true, false, false, false, true, false, true, false, false };
            BitArray test = new BitArray(arr);
            BitArray test2 = new BitArray((PrimeTens.GetPrimeNumbersEratosthenes(15, ct)));
            for (int i = 0; i < arr.Length; i++)
            {
                Assert.IsTrue(test2[i] == test[i]);
            }
        }

        [TestMethod]
        public void GetArrayTest()
        {
            bool[] arr = new bool[16] { false, false, true, true, true, true, true, true, true, true, true, true, true, true, true, true };
            BitArray test = new BitArray(arr);
            BitArray test2 = new BitArray((PrimeTens.GetArray(15)));
            for (int i = 0; i < arr.Length; i++)
            {
                Assert.IsTrue(test2[i] == test[i]);
            }
        }

        [TestMethod]
        public void GetPrimeNumbersSqrtTest()
        {
            bool[] arr = new bool[16] { false, false, true, true, false, true, false, true, false, false, false, true, false, true, false, false };
            BitArray test = new BitArray(arr);
            BitArray test2 = new BitArray((PrimeTens.GetPrimeNumbersSqrt(15, ct)));
            for (int i = 0; i < arr.Length; i++)
            {
                Assert.IsTrue(test2[i] == test[i]);
            }
        }

        [TestMethod]
        public void IsPrimeTest()
        {
            bool[] arr = new bool[15] { true, true, true, false, true, false, true, false, false, false, true, false, true, false, false };
            bool[] test = new bool[15];
            for (int i = 3; i < test.Length; i++)
            {
                test[i] = PrimeTens.IsPrime(i);
                Assert.IsTrue(test[i] == arr[i - 1]);
            }
        }

        [TestMethod]
        public void GetMinMaxTensTest()
        {
            (int, int, int, int) result;
            BitArray test = PrimeTens.GetPrimeNumbersSqrt(1000, ct);
            result = PrimeTens.GetMinMaxTens(test, ct);
            Assert.IsTrue(result.Item1 == 0);
            Assert.IsTrue(result.Item2 == 891);
            Assert.IsTrue(result.Item3 == 4);
            Assert.IsTrue(result.Item4 == 821);
            BitArray test2 = PrimeTens.GetPrimeNumbersSqrt(100000, ct);
            result = PrimeTens.GetMinMaxTens(test2, ct);
            Assert.IsTrue(result.Item1 == 0);
            Assert.IsTrue(result.Item2 == 99951);
            Assert.IsTrue(result.Item3 == 4);
            Assert.IsTrue(result.Item4 == 99131);
        }
    }
}
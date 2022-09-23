using System.Collections;

namespace ClassLibraryPrimeTens
{
    public static class PrimeTens
    {
        #region Решето Эратосфена
        /// <summary>
        /// Возвращает массив булевых значений, указывающих, является ли число простым.
        /// Использует решето Эратосфена.
        /// Пример: prime[2] = true, prime[3] = true, prime[4] = false, prime[5] = true.
        /// </summary>
        /// <param name="n"> верхняя граница массива </param>
        /// <param name="ct"> переменная, с помощью которой можно досрочно завершить выполнение метода </param>
        /// <returns> массив булевых значений, указывающих, является ли число простым </returns>
        public static BitArray GetPrimeNumbersEratosthenes(int n, CancellationToken ct)
        {
            BitArray prime = GetArray(n);

            // Просеиваем до корня, оставшиеся числа будут простыми
            for (int i = 2; i <= (int)Math.Sqrt(n); i++)
            {
                if (ct.IsCancellationRequested)
                {
                    return null;
                }
                if (prime[i])
                {
                    // Просеивать начинаем с i*i, т.к. числа кратные i и меньшие i*i мы просеяли на прошлых итерациях
                    for (int j = i * i; j <= n && j > 0; j += i)
                    {
                        prime[j] = false;
                    }
                }
            }

            return prime;
        }

        /// <summary>
        /// Возвращает массив булевых значений. До начала просеивания все числа считаются простыми.
        /// </summary>
        /// <param name="n"> верхняя граница массива </param>
        /// <returns> массив булевых значений </returns>
        public static BitArray GetArray(int n)
        {
            BitArray arr = new BitArray(n + 1);
            arr.SetAll(true);
            arr[0] = false;
            arr[1] = false;
            return arr;
        }
        #endregion

        #region Перебор до корня
        /// <summary>
        /// Возвращает массив булевых значений, указывающих, является ли число простым.
        /// Использует алгоритм поиска простых чисел с проверкой делителей до корня.
        /// Пример: prime[2] = true, prime[3] = true, prime[4] = false, prime[5] = true.
        /// </summary>
        /// <param name="n"> верхняя граница массива </param>
        /// <param name="ct"> переменная, с помощью которой можно досрочно завершить выполнение метода </param>
        /// <returns> массив булевых значений, указывающих, является ли число простым </returns>
        public static BitArray GetPrimeNumbersSqrt(int n, CancellationToken ct)
        {
            BitArray prime = new BitArray(n + 1);
            for (int i = 2; i <= n; i++)
            {
                if (ct.IsCancellationRequested)
                {
                    return null;
                }
                prime[i] = IsPrime(i);
            }
            return prime;
        }

        /// <summary>
        /// Возвращает булевое значение, является ли число простым.
        /// </summary>
        /// <param name="x"> число для проверки </param>
        /// <returns> true - если число простое, false - если составное </returns>
        public static bool IsPrime(int x)
        {
            for (int i = 2; i <= (int)Math.Sqrt(x); i++)
            {
                if (x % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region Поиск десятков
        /// <summary>
        /// Находит наибольшие десятки чисел, в которых максимальное и минимальное количество простых чисел.
        /// </summary>
        /// <param name="prime"> массив булевых значений, указывающих, является ли число простым </param>
        /// <param name="ct"> переменная, с помощью которой можно досрочно завершить выполнение метода </param>
        /// <returns> кортеж из четырёх элементов: 
        /// minCount - минимальное количество простых чисел в десятке
        /// minRangeStart - число, являющееся началом десятки с минимальным количеством простых чисел
        /// maxCount - максимальное количество простых чисел в десятке
        /// maxRangeStart - число, являющееся началом десятки с максимальным количеством простых чисел
        /// </returns>
        public static (int minCount, int minRangeStart, int maxCount, int maxRangeStart) GetMinMaxTens(BitArray prime, CancellationToken ct)
        {
            int minCount = 10, minRangeStart = -1, maxCount = -1, maxRangeStart = -1;
            const int rnange = 10;
            if (ct.IsCancellationRequested)
            {
                return (0, 0, 0, 0);
            }
            for (int i = 1; i < prime.Length; i += rnange)
            {
                if (ct.IsCancellationRequested)
                {
                    return (0, 0, 0, 0);
                }
                int count = 0;
                for (int j = i; j < i + rnange; j++)
                {
                    if (prime[j])
                    {
                        count++;
                    }
                }
                if (count <= minCount)
                {
                    minCount = count;
                    minRangeStart = i;
                }
                if (count >= maxCount)
                {
                    maxCount = count;
                    maxRangeStart = i;
                }
            }
            return (minCount, minRangeStart, maxCount, maxRangeStart);
        }
        #endregion

        #region Задачи
        /// <summary>
        /// Возвращает список делителей числа.
        /// </summary>
        /// <param name="n"> число для поиска делителей </param>
        /// <returns> список делителей, кроме базовых </returns>
        public static List<int> FindDivisors(int n)
        {
            List<int> res = new List<int>();
            int sqrt = (int)Math.Sqrt(n);
            if (sqrt * sqrt == n && n != 1 && n != 0)
            {
                res.Add(sqrt);
                sqrt--;
            }
            for (int i = 2; i <= sqrt && i > 0; i++)
            {
                if (n % i == 0)
                {
                    res.Add(i);
                    res.Add(n / i);
                }
            }
            res.Sort();
            return res;
        }

        /// <summary>
        /// Находит наибольший отрезок от 1 до n, где нет простых чисел.
        /// </summary>
        /// <param name="n"> верхняя граница поиска </param>
        /// <returns> кортеж из двух чисел, start - начало отрезка, end - конец отрезка</returns>
        public static (int start, int end) FindMaxRangeWithoutPrimeNumbers(int n)
        {
            int count = 0, maxCount = 0, start = 0, end = 0;
            BitArray prime = GetPrimeNumbersEratosthenes(n, new CancellationToken());
            for (int i = 2; i <= n; i++)
            {
                if (!prime[i])
                {
                    count++;
                }
                else
                {
                    if (count >= maxCount && count != 0)
                    {
                        maxCount = count;
                        end = i - 1;
                        start = i - count;
                    }
                    count = 0;
                }
            }
            if (count >= maxCount && count != 0)
            {
                end = n;
                start = n - count + 1;
            }
            return (start, end);
        }
        #endregion
    }
}
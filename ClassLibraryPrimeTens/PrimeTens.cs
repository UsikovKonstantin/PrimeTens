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
        /// <returns> массив булевых значений, указывающих, является ли число простым </returns>
        public static bool[] GetPrimeNumbersEratosthenes(int n)
        {
            bool[] prime = GetArray(n);

            // Просеиваем до корня, оставшиеся числа будут простыми
            for (int i = 2; i <= (int)Math.Sqrt(n); i++)
            {
                if (prime[i])
                {
                    // Просеивать начинаем с i*i, т.к. числа кратные i и меньшие i*i мы просеяли на прошлых итерациях
                    for (int j = i * i; j <= n; j += i)
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
        public static bool[] GetArray(int n)
        {
            bool[] arr = new bool[n + 1];
            for (int i = 2; i <= n; i++)
            {
                arr[i] = true;
            }
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
        /// <returns> массив булевых значений, указывающих, является ли число простым </returns>
        public static bool[] GetPrimeNumbersSqrt(int n)
        {
            bool[] prime = new bool[n + 1];
            for (int i = 2; i <= n; i++)
            {
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
        /// <param name="minRangeStart"> число, являющееся началом десятки с минимальным количеством простых чисел </param>
        /// <param name="minCount"> минимальное количество делителей в десятке </param>
        /// <param name="maxRangeStart"> число, являющееся началом десятки с максимальным количеством простых чисел </param>
        /// <param name="maxCount"> максимальное количество делителей в десятке </param>
        async public static Task<(int,int,int,int)> GetMinMaxTens(bool[] prime)
        {
            int minCount = 10;
            int minRangeStart = -1;
            int maxCount = -1;
            int maxRangeStart = -1;

            for (int i = 1; i < prime.Length; i += 10)
            {
                int count = 0;
                for (int j = i; j < i + 10; j++)
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
    }
}
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
    }
}
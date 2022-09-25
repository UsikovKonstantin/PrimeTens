using System.Collections;

namespace ClassLibraryPrimeTens
{
    /// <summary>
    /// Перечисление методов для нахождения простых чисел
    /// </summary>
    public enum Prime_Method
    {
        Erathosphenes,
        Division_Lookup
    }

    /// <summary>
    /// Класс для решения задач с простыми числами
    /// </summary>
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
        private static BitArray GetPrimeNumbersEratosthenes(int n, CancellationToken ct)
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
        private static BitArray GetArray(int n)
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
        private static BitArray GetPrimeNumbersSqrt(int n, CancellationToken ct)
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
        private static bool IsPrime(int x)
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

        #region Задачи
        /// <summary>
        /// Находит наибольшие сегменты чисел, в которых максимальное и минимальное количество простых чисел.
        /// </summary>
        /// <param name="n"> число, до которого выполняется поиск </param>
        /// <param name="segmentLength"> количество элементов в сегменте </param>
        /// <param name="method"> метод, который используется для поиска простых чисел </param>
        /// <param name="ct"> переменная, с помощью которой можно досрочно завершить выполнение метода </param>
        /// <returns> кортеж из четырёх элементов: 
        /// minCount - минимальное количество простых чисел в сегменте
        /// minRangeStart - число, являющееся началом сегмента с минимальным количеством простых чисел
        /// maxCount - максимальное количество простых чисел в сегменте
        /// maxRangeStart - число, являющееся началом сегмента с максимальным количеством простых чисел
        /// </returns>
        public static (int minCount, int minRangeStart, int maxCount, int maxRangeStart) GetMinMaxSegments(int n, int segmentLength, Prime_Method method, CancellationToken ct)
        {
            BitArray prime = new BitArray(0);
            if (method == Prime_Method.Erathosphenes)
                prime = GetPrimeNumbersEratosthenes(n, ct);
            else if (method == Prime_Method.Division_Lookup)
                prime = GetPrimeNumbersSqrt(n, ct);
            int minCount = int.MaxValue, minRangeStart = -1, maxCount = -1, maxRangeStart = -1;
            if (ct.IsCancellationRequested)
                return (0, 0, 0, 0);
            for (int i = 1; i < prime.Length; i += segmentLength)
            {
                if (ct.IsCancellationRequested)
                    return (0, 0, 0, 0);
                int count = 0;
                for (int j = i; j < i + segmentLength; j++)
                    if (prime[j])
                        count++;
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

        /// <summary>
        /// Возвращает список делителей числа.
        /// </summary>
        /// <param name="n"> число для поиска делителей </param>
        /// <returns> список всех делителей числа </returns>
        public static List<ulong> GetDivisors(ulong n)
        {
            List<ulong> res = new List<ulong>();
            res.Add(1);
            res.Add(n);
            ulong sqrt = (ulong)Math.Sqrt(n);
            if (sqrt * sqrt == n && n != 1 && n != 0)
            {
                res.Add(sqrt);
                sqrt--;
            }
            for (ulong i = 2; i <= sqrt && i > 0; i++)
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
        /// <param name="n"> число, до которого выполняется поиск </param>
        /// <param name="method"> метод, который используется для поиска простых чисел </param>
        /// <param name="ct"> переменная, с помощью которой можно досрочно завершить выполнение метода </param>
        /// <returns> кортеж из двух чисел, start - начало отрезка, end - конец отрезка </returns>
        public static (int start, int end) GetMaxRangeWithoutPrimeNumbers(int n, Prime_Method method, CancellationToken ct)
        {
            BitArray prime = new BitArray(0);
            if (method == Prime_Method.Erathosphenes)
                prime = GetPrimeNumbersEratosthenes(n, ct);
            else if (method == Prime_Method.Division_Lookup)
                prime = GetPrimeNumbersSqrt(n, ct);
            int count = 0, maxCount = 0, start = 0, end = 0;
            for (int i = 2; i <= n; i++)
            {
                if (ct.IsCancellationRequested)
                    return (0,0);
                if (!prime[i])
                    count++;
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

        /// <summary>
        /// Находит количесво и частоту простых чисел на сегментах.
        /// </summary>
        /// <param name="n"> число, до которого выполняется поиск </param>
        /// <param name="segmentsCount"> количество сегментов, на которые необходимо разбить отрезок [1, n] </param>
        /// <param name="method"></param>
        /// <param name="ct"> переменная, с помощью которой можно досрочно завершить выполнение метода </param>
        /// <returns> список длины segmentsCount, каждый элемент которого представляет собой кортеж из 4 элементов:
        /// start - число, являющееся началом сегмента
        /// end - число, являющееся концом сегмента
        /// primeCount - количество простых чисел в сегменте
        /// primePercent - частота простых чисел в сегменте
        /// </returns>
        public static List<(int start, int end, int primeCount, double primePercent)> GetPrimeDistribution(int n, int segmentsCount, Prime_Method method, CancellationToken ct)
        {
            BitArray prime = new BitArray(0);
            if (method == Prime_Method.Erathosphenes)
                prime = GetPrimeNumbersEratosthenes(n, ct);
            else if (method == Prime_Method.Division_Lookup)
                prime = GetPrimeNumbersSqrt(n, ct);
            List<(int start, int end, int primeCount, double primePercent)> result = new ();
            int amountInSegment = (prime.Count - 1) / segmentsCount;
            int start = 1;
            while (start < prime.Count)
            {
                if (ct.IsCancellationRequested)
                    return null;
                int count = 0;
                int end = start + amountInSegment;
                for (int i = start; i < end; i++)
                    if (prime[i])
                        count++;
                result.Add((start, end - 1, count, (double)count/amountInSegment));
                start += amountInSegment;
            }
            return result;
        }



        /// <summary>
        /// Находит наибольшие сегменты чисел, в которых максимальное и минимальное количество простых чисел.
        /// </summary>
        /// <param name="n"> число, до которого выполняется поиск </param>
        /// <param name="segmentLength"> количество элементов в сегменте </param>
        /// <param name="ct"> переменная, с помощью которой можно досрочно завершить выполнение метода </param>
        /// <returns> кортеж из четырёх элементов: 
        /// minCount - минимальное количество простых чисел в сегменте
        /// minRangeStart - число, являющееся началом сегмента с минимальным количеством простых чисел
        /// maxCount - максимальное количество простых чисел в сегменте
        /// maxRangeStart - число, являющееся началом сегмента с максимальным количеством простых чисел
        /// </returns>
        public static (ulong minCount, ulong minRangeStart, ulong maxCount, ulong maxRangeStart) GetMinMaxSegments(ulong n, ulong segmentLength, CancellationToken ct)
        {
            ulong minCount = ulong.MaxValue, minRangeStart = 0, maxCount = 0, maxRangeStart = 0;
            UltimatePrimesSoE.nmrtr prime = new UltimatePrimesSoE.nmrtr();
            prime.MoveNext();
            ulong end = segmentLength;
            if (ct.IsCancellationRequested)
                return (0, 0, 0, 0);
            while (end <= n)
            {
                if (ct.IsCancellationRequested)
                    return (0, 0, 0, 0);
                ulong count = 0;
                while (prime.Current <= end)
                {
                    count++;
                    prime.MoveNext();
                }
                if (count <= minCount)
                {
                    minCount = count;
                    minRangeStart = end - segmentLength + 1;
                }
                if (count >= maxCount)
                {
                    maxCount = count;
                    maxRangeStart = end - segmentLength + 1;
                }
                end += segmentLength;
            }
            return (minCount, minRangeStart, maxCount, maxRangeStart);
        }

        /// <summary>
        /// Находит наибольший отрезок от 1 до n, где нет простых чисел.
        /// </summary>
        /// <param name="n"> число, до которого выполняется поиск </param>
        /// <param name="ct"> переменная, с помощью которой можно досрочно завершить выполнение метода </param>
        /// <returns> кортеж из двух чисел, start - начало отрезка, end - конец отрезка </returns>
        public static (ulong start, ulong end) GetMaxRangeWithoutPrimeNumbers(ulong n, CancellationToken ct)
        {
            ulong count = 0, maxCount = 0, start = 0, end = 0;
            UltimatePrimesSoE.nmrtr prime = new UltimatePrimesSoE.nmrtr();
            prime.MoveNext();

            ulong i = 2;
            while (i <= n)
            {
                if (ct.IsCancellationRequested)
                    return (0, 0);
                ulong curPrime = prime.Current;
                count = Math.Min(curPrime - i, n + 1 - i);
                if (count >= maxCount && count != 0)
                {
                    maxCount = count;
                    start = i;
                    end = start + maxCount - 1;
                }
                i = curPrime + 1;
                prime.MoveNext();
            }
            return (start, end);
        }

        /// <summary>
        /// Находит количесво и частоту простых чисел на сегментах.
        /// </summary>
        /// <param name="n"> число, до которого выполняется поиск </param>
        /// <param name="segmentsCount"> количество сегментов, на которые необходимо разбить отрезок [1, n] </param>
        /// <param name="ct"> переменная, с помощью которой можно досрочно завершить выполнение метода </param>
        /// <returns> список длины segmentsCount, каждый элемент которого представляет собой кортеж из 4 элементов:
        /// start - число, являющееся началом сегмента
        /// end - число, являющееся концом сегмента
        /// primeCount - количество простых чисел в сегменте
        /// primePercent - частота простых чисел в сегменте
        /// </returns>
        public static List<(ulong start, ulong end, ulong primeCount, double primePercent)> GetPrimeDistribution(ulong n, ulong segmentsCount, CancellationToken ct)
        {
            List<(ulong start, ulong end, ulong primeCount, double primePercent)> result = new();
            UltimatePrimesSoE.nmrtr prime = new UltimatePrimesSoE.nmrtr();
            prime.MoveNext();
            ulong amountInSegment = n / segmentsCount;
            ulong end = amountInSegment;
            while (end <= n)
            {
                if (ct.IsCancellationRequested)
                    return null;
                ulong count = 0;
                while (prime.Current <= end)
                {
                    count++;
                    prime.MoveNext();
                }
                result.Add((end - amountInSegment + 1, end, count, (double)count / amountInSegment));
                end += amountInSegment;
            }
            return result;
        }
        #endregion
    }

    /// <summary>
    /// Оптимизированное решето Эратосфена (класс позаимствован из интернета)
    /// </summary>
    public class UltimatePrimesSoE : IEnumerable<ulong>
    {
        static readonly uint NUMPRCSPCS = (uint)Environment.ProcessorCount + 1; const uint CHNKSZ = 17;
        const int L1CACHEPOW = 14, L1CACHESZ = (1 << L1CACHEPOW), MXPGSZ = L1CACHESZ / 2; //for buffer ushort[]
                                                                                          //the 2,3,57 factorial wheel increment pattern, (sum) 48 elements long, starting at prime 19 position
        static readonly byte[] WHLPTRN = { 2,3,1,3,2,1,2,3,3,1,3,2,1,3,2,3,4,2,1,2,1,2,4,3,
                                                                           2,3,1,2,3,1,3,3,2,1,2,3,1,3,2,1,2,1,5,1,5,1,2,1 }; const uint FSTCP = 11;
        static readonly byte[] WHLPOS; static readonly byte[] WHLNDX; //to look up wheel indices from position index
        static readonly byte[] WHLRNDUP; //to look up wheel rounded up index positon values, allow for overfolw
        static readonly uint WCRC = WHLPTRN.Aggregate(0u, (acc, n) => acc + n);
        static readonly uint WHTS = (uint)WHLPTRN.Length; static readonly uint WPC = WHTS >> 4;
        static readonly byte[] BWHLPRMS = { 2, 3, 5, 7, 11, 13, 17 }; const uint FSTBP = 19;
        static readonly uint BWHLWRDS = BWHLPRMS.Aggregate(1u, (acc, p) => acc * p) / 2 / WCRC * WHTS / 16;
        static readonly uint PGSZ = MXPGSZ / BWHLWRDS * BWHLWRDS; static readonly uint PGRNG = PGSZ * 16 / WHTS * WCRC;
        static readonly uint BFSZ = CHNKSZ * PGSZ, BFRNG = CHNKSZ * PGRNG; //number of uints even number of caches in chunk
        static readonly ushort[] MCPY; //a Master Copy page used to hold the lower base primes preculled version of the page
        struct Wst { public ushort msk; public byte mlt; public byte xtr; public ushort nxt; }
        static readonly byte[] PRLUT; /*Wheel Index Look Up Table */ static readonly Wst[] WSLUT; //Wheel State Look Up Table
        static readonly byte[] CLUT; // a Counting Look Up Table for very fast counting of primes
        static int count(uint bitlim, ushort[] buf)
        { //very fast counting
            if (bitlim < BFRNG)
            {
                var addr = (bitlim - 1) / WCRC; var bit = WHLNDX[bitlim - addr * WCRC] - 1; addr *= WPC;
                for (var i = 0; i < 3; ++i) buf[addr++] |= (ushort)((unchecked((ulong)-2) << bit) >> (i << 4));
            }
            var acc = 0; for (uint i = 0, w = 0; i < bitlim; i += WCRC)
                acc += CLUT[buf[w++]] + CLUT[buf[w++]] + CLUT[buf[w++]]; return acc;
        }
        static void cull(ulong lwi, ushort[] b)
        {
            ulong nlwi = lwi;
            for (var i = 0u; i < b.Length; nlwi += PGRNG, i += PGSZ) MCPY.CopyTo(b, i); //copy preculled lower base primes.
            for (uint i = 0, pd = 0; ; ++i)
            {
                pd += (uint)baseprms[i] >> 6;
                var wi = baseprms[i] & 0x3Fu; var wp = (uint)WHLPOS[wi]; var p = pd * WCRC + PRLUT[wi];
                var pp = (p - FSTBP) >> 1; var k = (ulong)p * (pp + ((FSTBP - 1) >> 1)) + pp;
                if (k >= nlwi) break; if (k < lwi)
                {
                    k = (lwi - k) % (WCRC * p);
                    if (k != 0)
                    {
                        var nwp = wp + (uint)((k + p - 1) / p); k = (WHLRNDUP[nwp] - wp) * p - k;
                        if (nwp >= WCRC) wp = 0; else wp = nwp;
                    }
                }
                else k -= lwi; var kd = k / WCRC; var kn = WHLNDX[k - kd * WCRC];
                for (uint wrd = (uint)kd * WPC + (uint)(kn >> 4), ndx = wi * WHTS + kn; wrd < b.Length;)
                {
                    var st = WSLUT[ndx]; b[wrd] |= st.msk; wrd += st.mlt * pd + st.xtr; ndx = st.nxt;
                }
            }
        }
        static Task cullbf(ulong lwi, ushort[] b, Action<ushort[]> f)
        {
            return Task.Factory.StartNew(() => { cull(lwi, b); f(b); });
        }
        public class Bpa
        {   //very efficient auto-resizing thread-safe read-only indexer class to hold the base primes array
            byte[] sa = new byte[0]; uint lwi = 0, lpd = 0; object lck = new object();
            public uint this[uint i]
            {
                get
                {
                    if (i >= this.sa.Length) lock (this.lck)
                        {
                            var lngth = this.sa.Length; while (i >= lngth)
                            {
                                var bf = (ushort[])MCPY.Clone(); if (lngth == 0)
                                {
                                    for (uint bi = 0, wi = 0, w = 0, msk = 0x8000, v = 0; w < bf.Length;
                                        bi += WHLPTRN[wi++], wi = (wi >= WHTS) ? 0 : wi)
                                    {
                                        if (msk >= 0x8000) { msk = 1; v = bf[w++]; } else msk <<= 1;
                                        if ((v & msk) == 0)
                                        {
                                            var p = FSTBP + (bi + bi); var k = (p * p - FSTBP) >> 1;
                                            if (k >= PGRNG) break; var pd = p / WCRC; var kd = k / WCRC; var kn = WHLNDX[k - kd * WCRC];
                                            for (uint wrd = kd * WPC + (uint)(kn >> 4), ndx = wi * WHTS + kn; wrd < bf.Length;)
                                            {
                                                var st = WSLUT[ndx]; bf[wrd] |= st.msk; wrd += st.mlt * pd + st.xtr; ndx = st.nxt;
                                            }
                                        }
                                    }
                                }
                                else { this.lwi += PGRNG; cull(this.lwi, bf); }
                                var c = count(PGRNG, bf); var na = new byte[lngth + c]; sa.CopyTo(na, 0);
                                for (uint p = FSTBP + (this.lwi << 1), wi = 0, w = 0, msk = 0x8000, v = 0;
                                    lngth < na.Length; p += (uint)(WHLPTRN[wi++] << 1), wi = (wi >= WHTS) ? 0 : wi)
                                {
                                    if (msk >= 0x8000) { msk = 1; v = bf[w++]; } else msk <<= 1; if ((v & msk) == 0)
                                    {
                                        var pd = p / WCRC; na[lngth++] = (byte)(((pd - this.lpd) << 6) + wi); this.lpd = pd;
                                    }
                                }
                                this.sa = na;
                            }
                        }
                    return this.sa[i];
                }
            }
        }
        static readonly Bpa baseprms = new Bpa();
        static UltimatePrimesSoE()
        {
            WHLPOS = new byte[WHLPTRN.Length + 1]; //to look up wheel position index from wheel index
            for (byte i = 0, acc = 0; i < WHLPTRN.Length; ++i) { acc += WHLPTRN[i]; WHLPOS[i + 1] = acc; }
            WHLNDX = new byte[WCRC + 1]; for (byte i = 1; i < WHLPOS.Length; ++i)
            {
                for (byte j = (byte)(WHLPOS[i - 1] + 1); j <= WHLPOS[i]; ++j) WHLNDX[j] = i;
            }
            WHLRNDUP = new byte[WCRC * 2]; for (byte i = 1; i < WHLRNDUP.Length; ++i)
            {
                if (i > WCRC) WHLRNDUP[i] = (byte)(WCRC + WHLPOS[WHLNDX[i - WCRC]]); else WHLRNDUP[i] = WHLPOS[WHLNDX[i]];
            }
            Func<ushort, int> nmbts = (v) => { var acc = 0; while (v != 0) { acc += (int)v & 1; v >>= 1; } return acc; };
            CLUT = new byte[1 << 16]; for (var i = 0; i < CLUT.Length; ++i) CLUT[i] = (byte)nmbts((ushort)(i ^ -1));
            PRLUT = new byte[WHTS]; for (var i = 0; i < PRLUT.Length; ++i)
            {
                var t = (uint)(WHLPOS[i] * 2) + FSTBP; if (t >= WCRC) t -= WCRC; if (t >= WCRC) t -= WCRC; PRLUT[i] = (byte)t;
            }
            WSLUT = new Wst[WHTS * WHTS]; for (var x = 0u; x < WHTS; ++x)
            {
                var p = FSTBP + 2u * WHLPOS[x]; var pr = p % WCRC;
                for (uint y = 0, pos = (p * p - FSTBP) / 2; y < WHTS; ++y)
                {
                    var m = WHLPTRN[(x + y) % WHTS];
                    pos %= WCRC; var posn = WHLNDX[pos]; pos += m * pr; var nposd = pos / WCRC; var nposn = WHLNDX[pos - nposd * WCRC];
                    WSLUT[x * WHTS + posn] = new Wst
                    {
                        msk = (ushort)(1 << (int)(posn & 0xF)),
                        mlt = (byte)(m * WPC),
                        xtr = (byte)(WPC * nposd + (nposn >> 4) - (posn >> 4)),
                        nxt = (ushort)(WHTS * x + nposn)
                    };
                }
            }
            MCPY = new ushort[PGSZ]; foreach (var lp in BWHLPRMS.SkipWhile(p => p < FSTCP))
            {
                var p = (uint)lp;
                var k = (p * p - FSTBP) >> 1; var pd = p / WCRC; var kd = k / WCRC; var kn = WHLNDX[k - kd * WCRC];
                for (uint w = kd * WPC + (uint)(kn >> 4), ndx = WHLNDX[(2 * WCRC + p - FSTBP) / 2] * WHTS + kn; w < MCPY.Length;)
                {
                    var st = WSLUT[ndx]; MCPY[w] |= st.msk; w += st.mlt * pd + st.xtr; ndx = st.nxt;
                }
            }
        }
        struct PrcsSpc { public Task tsk; public ushort[] buf; }
        public class nmrtr : IEnumerator<ulong>, IEnumerator, IDisposable
        {
            PrcsSpc[] ps = new PrcsSpc[NUMPRCSPCS]; ushort[] buf;
            public nmrtr()
            {
                for (var s = 0u; s < NUMPRCSPCS; ++s) ps[s] = new PrcsSpc { buf = new ushort[BFSZ] };
                for (var s = 1u; s < NUMPRCSPCS; ++s)
                {
                    ps[s].tsk = cullbf((s - 1u) * BFRNG, ps[s].buf, (bfr) => { });
                }
                buf = ps[0].buf;
            }
            ulong _curr, i = (ulong)-WHLPTRN[WHTS - 1]; int b = -BWHLPRMS.Length - 1; uint wi = WHTS - 1; ushort v, msk = 0;
            public ulong Current { get { return this._curr; } }
            object IEnumerator.Current { get { return this._curr; } }
            public bool MoveNext()
            {
                if (b < 0)
                {
                    if (b == -1) b += buf.Length; //no yield!!! so automatically comes around again
                    else { this._curr = (ulong)BWHLPRMS[BWHLPRMS.Length + (++b)]; return true; }
                }
                do
                {
                    i += WHLPTRN[wi++]; if (wi >= WHTS) wi = 0; if ((this.msk <<= 1) == 0)
                    {
                        if (++b >= BFSZ)
                        {
                            b = 0; for (var prc = 0; prc < NUMPRCSPCS - 1; ++prc) ps[prc] = ps[prc + 1];
                            ps[NUMPRCSPCS - 1u].buf = buf;
                            ps[NUMPRCSPCS - 1u].tsk = cullbf(i + (NUMPRCSPCS - 1u) * BFRNG, buf, (bfr) => { });
                            ps[0].tsk.Wait(); buf = ps[0].buf;
                        }
                        v = buf[b]; this.msk = 1;
                    }
                }
                while ((v & msk) != 0u); _curr = FSTBP + i + i; return true;
            }
            public void Reset() { throw new Exception("Primes enumeration reset not implemented!!!"); }
            public void Dispose() { }
        }
        public IEnumerator<ulong> GetEnumerator() { return new nmrtr(); }
        IEnumerator IEnumerable.GetEnumerator() { return new nmrtr(); }
        static void IterateTo(ulong top_number, Action<ulong, uint, ushort[]> actn)
        {
            PrcsSpc[] ps = new PrcsSpc[NUMPRCSPCS]; for (var s = 0u; s < NUMPRCSPCS; ++s) ps[s] = new PrcsSpc
            {
                buf = new ushort[BFSZ],
                tsk = Task.Factory.StartNew(() => { })
            };
            var topndx = (top_number - FSTBP) >> 1; for (ulong ndx = 0; ndx <= topndx;)
            {
                ps[0].tsk.Wait(); var buf = ps[0].buf; for (var s = 0u; s < NUMPRCSPCS - 1; ++s) ps[s] = ps[s + 1];
                var lowi = ndx; var nxtndx = ndx + BFRNG; var lim = topndx < nxtndx ? (uint)(topndx - ndx + 1) : BFRNG;
                ps[NUMPRCSPCS - 1] = new PrcsSpc { buf = buf, tsk = cullbf(ndx, buf, (b) => actn(lowi, lim, b)) };
                ndx = nxtndx;
            }
            for (var s = 0u; s < NUMPRCSPCS; ++s) ps[s].tsk.Wait();
        }
        public static long CountTo(ulong top_number)
        {
            if (top_number < FSTBP) return BWHLPRMS.TakeWhile(p => p <= top_number).Count();
            var cnt = (long)BWHLPRMS.Length;
            IterateTo(top_number, (lowi, lim, b) => { Interlocked.Add(ref cnt, count(lim, b)); }); return cnt;
        }
        public static ulong SumTo(uint top_number)
        {
            if (top_number < FSTBP) return (ulong)BWHLPRMS.TakeWhile(p => p <= top_number).Aggregate(0u, (acc, p) => acc += p);
            var sum = (long)BWHLPRMS.Aggregate(0u, (acc, p) => acc += p);
            Func<ulong, uint, ushort[], long> sumbf = (lowi, bitlim, buf) => {
                var acc = 0L; for (uint i = 0, wi = 0, msk = 0x8000, w = 0, v = 0; i < bitlim;
                    i += WHLPTRN[wi++], wi = wi >= WHTS ? 0 : wi)
                {
                    if (msk >= 0x8000) { msk = 1; v = buf[w++]; } else msk <<= 1;
                    if ((v & msk) == 0) acc += (long)(FSTBP + ((lowi + i) << 1));
                }
                return acc;
            };
            IterateTo(top_number, (pos, lim, b) => { Interlocked.Add(ref sum, sumbf(pos, lim, b)); }); return (ulong)sum;
        }
        static void IterateUntil(Func<ulong, ushort[], bool> prdct)
        {
            PrcsSpc[] ps = new PrcsSpc[NUMPRCSPCS];
            for (var s = 0u; s < NUMPRCSPCS; ++s)
            {
                var buf = new ushort[BFSZ];
                ps[s] = new PrcsSpc { buf = buf, tsk = cullbf(s * BFRNG, buf, (bfr) => { }) };
            }
            for (var ndx = 0UL; ; ndx += BFRNG)
            {
                ps[0].tsk.Wait(); var buf = ps[0].buf; var lowi = ndx; if (prdct(lowi, buf)) break;
                for (var s = 0u; s < NUMPRCSPCS - 1; ++s) ps[s] = ps[s + 1];
                ps[NUMPRCSPCS - 1] = new PrcsSpc
                {
                    buf = buf,
                    tsk = cullbf(ndx + NUMPRCSPCS * BFRNG, buf, (bfr) => { })
                };
            }
        }
        public static ulong ElementAt(long n)
        {
            if (n < BWHLPRMS.Length) return (ulong)BWHLPRMS.ElementAt((int)n);
            long cnt = BWHLPRMS.Length; var ndx = 0UL; var cycl = 0u; var bit = 0u; IterateUntil((lwi, bfr) => {
                var c = count(BFRNG, bfr); if ((cnt += c) < n) return false; ndx = lwi; cnt -= c; c = 0;
                do { var w = cycl++ * WPC; c = CLUT[bfr[w++]] + CLUT[bfr[w++]] + CLUT[bfr[w]]; cnt += c; } while (cnt < n);
                cnt -= c; var y = (--cycl) * WPC; ulong v = ((ulong)bfr[y + 2] << 32) + ((ulong)bfr[y + 1] << 16) + bfr[y];
                do { if ((v & (1UL << ((int)bit++))) == 0) ++cnt; } while (cnt <= n); --bit; return true;
            }); return FSTBP + ((ndx + cycl * WCRC + WHLPOS[bit]) << 1);
        }
    }
}
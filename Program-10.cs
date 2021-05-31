using System;
using System.Diagnostics;
using System.Numerics;

class App
{
    static long cnt = 0;
    static long cnt1 = 0;
    static long cnt_first = 0;
    static bool Prime1(long n)//////////////// tego nie używam
    {
        if (n < 2) return false;
        else if (n < 4) return true;
        else if (n % 2 == 0) return false;
        else
        {
            long m = (n >> 1); // n/2;
            for (long i = 3; i < m; i += 2)
            {
                if (n % i == 0) return false;
            }
        }
        return true;
    }
    //--------------------

    static bool Prime2(long n)////////// przyzwoity ver.1
    {
        if (n < 2) return false;
        else if (n < 4) return true;
        else if (n % 2 == 0) return false;
        else
        {
            for (long i = 3; i * i <= n; i += 2)
            {
                if (n % i == 0) return false;
            }
        }
        return true;
    }
    //--------------------

    static bool Prime3(long n)/////////// przyzwoity ver.2
    {
        if (n < 2) return false;
        else if (n < 4) return true;
        else if (n % 2 == 0) return false;
        else
        {
            long s = (long)Math.Sqrt(n);
            for (long i = 3; i <= s; i += 2)
            {
                if (n % i == 0) return false;
            }
        }
        return true;
    }
    //--------------------
    static long Prime2_iter(long n) ////////// zliczanie ver.1
    {
        //long cnt = 0;
        if (n < 2) return cnt;
        else if (n < 4) return cnt = 1;
        else if (n % 2 == 0) return cnt;
        else
        {
            for (long i = 3; ((i * i) <= n); i += 2)
            {
                cnt++;
                if ((n % i) == 0) return cnt;
            }
        }
        return cnt;
    }
    static long Prime3_iter(long n)//////////// zliczanie ver.2
    {
        //long cnt1=0;
        if (n < 2) return cnt1;
        else if (n < 4) return cnt1 = 1;
        else if (n % 2 == 0) return cnt;
        else
        {
            long s = (long)Math.Sqrt(n);
            for (long i = 3; i <= s; i += 2)
            {
                cnt1++;
                if (n % i == 0) return cnt1;
            }
            return cnt1;
        }
    }
    static bool IsPrime_first(BigInteger n) ///////////// przykładowy z zadania 
    {
        if (n < 2) return false;
        else if (n < 4) return true;
        else if (n % 2 == 0) return false;
        else for (BigInteger u = 3; u < n / 2; u += 2)
                if (n % u == 0) return false;
        return true;
    }
    static long IsPrime_first_iter(BigInteger n) //////////// zliczanie przykładowy 
    {
        if (n < 2) return cnt_first = 0;
        else if (n < 4) return cnt_first = 1;
        else if (n % 2 == 0) return cnt_first = 0;
        else for (BigInteger u = 3; u < n / 2; u += 2)
            {
                cnt_first++;
                if (n % u == 0) return cnt_first;
            }
        return cnt_first;
    }
    static void Main()
    {
        Stopwatch st = new Stopwatch();
        long[] tab = new long[] { 100913, 1009139, 10091401, 100914061, 1009140611, 10091406133, 100914061337, 1009140613399 };

        for (int p = 0; tab[p] <= tab[7]; p++)
        {
            int NT = 100;

            bool b1 = false;
            st.Start();
            for (int i = 0; i < NT; i++)//// czas przykładowy 
            {
                b1 = IsPrime_first(tab[p]);
            }
            st.Stop();
            double t1 = st.ElapsedMilliseconds;

            st.Reset();
            bool b2 = false;
            st.Start();
            for (int i = 0; i < NT; i++)/// czas ver.1 
            {
                b2 = Prime2(tab[p]);
            }
            st.Stop();
            double t2 = st.ElapsedMilliseconds;
            //--------------
            st.Reset();
            bool b3 = false;
            st.Start();
            for (int i = 0; i < NT; i++)//// czas ver.2
            {
                b3 = Prime3(tab[p]);
            }
            st.Stop();
            double t3 = st.ElapsedMilliseconds;
            //Prime2_iter(tab[p]);               
            //Prime3_iter(tab[p]);
            //cnt1 = 0;100913
            Console.WriteLine("n = {0}, b1_first = {1}, b2 = {2}, b3 = {3}, t1_first = {4}, t2 = {5}, t3 = {6} iter_first= {7}, iter2= {8}, iter3= {9}", tab[p], b1, b2, b3, t1, t2, t3, IsPrime_first_iter(tab[p]), Prime2_iter(tab[p]) + 1, Prime3_iter(tab[p]) + 1);
        }

        Console.ReadKey();
    }
}



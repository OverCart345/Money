namespace Money
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("D:\\C#\\Money\\Money\\inp.txt");
            int[] kurs1; int[] kurs2; int[] lucky1; int[] lucky2; int[] money2;

            try
            {
                string[] kurs01 = reader.ReadLine().Split(" ", 2)[1].Split(" "); kurs1 = new int[kurs01.Length];
                for (int i = 0; i < kurs01.Length; i++)
                {
                    kurs1[i] = Convert.ToInt32(kurs01[i]);
                }
            }
            catch { kurs1 = new int[1]; }
            try
            {
                string[] lucky01 = reader.ReadLine().Split(" ", 2)[1].Split(" "); lucky1 = new int[lucky01.Length];
                for (int i = 0; i < lucky01.Length; i++)
                {
                    lucky1[i] = Convert.ToInt32(lucky01[i]);
                }
            }
            catch { lucky1 = new int[1]; }
            try
            {
                string[] kurs02 = reader.ReadLine().Split(" ", 2)[1].Split(" "); kurs2 = new int[kurs02.Length];
                for (int i = 0; i < kurs02.Length; i++)
                {
                    kurs2[i] = Convert.ToInt32(kurs02[i]);
                }
            }
            catch { kurs2 = new int[1]; }
            try
            {
                string[] lucky02 = reader.ReadLine().Split(" ", 2)[1].Split(" "); lucky2 = new int[lucky02.Length];
                for (int i = 0; i < lucky02.Length; i++)
                {
                    lucky2[i] = Convert.ToInt32(lucky02[i]);
                }
            }
            catch { lucky2 = new int[1]; }
            string[] money01 = reader.ReadLine().Split(" "); int[] money1 = new int[money01.Length];
            for (int i = 0; i < money1.Length; i++)
            {
                money1[i] = Convert.ToInt32(money01[i]);
            }
            if (kurs2[0] != 0) { money2 = new int[kurs2.Length + 1]; } else { money2 = new int[1]; }


            Array.Sort(lucky1); Array.Sort(lucky2); Array.Reverse(lucky1);

            for (int i = 0; i < money1.Length; i++)
            {
                for (int t = 0; t < lucky1.Length; t++)
                {
                    if (lucky1[t] <= money1[i])
                    {
                        money1[i]--;
                    }
                }
            }
            for (int i = 0; i < money1.Length - 1; i++)
            {
                money1[i + 1] += money1[i] * kurs1[i];
            }
            money2[money2.Length - 1] = money1[money1.Length - 1];

            for (int i = money2.Length - 1; i > 0; i--)
            {

                money2[i - 1] = money2[i] / kurs2[i - 1];
                money2[i] = money2[i] % kurs2[i - 1];
            }

            for (int i = 0; i < money2.Length; i++)
            {
                for (int t = 0; t < lucky2.Length; t++)
                {
                    if (lucky2[t] <= money2[i])
                    {
                        money2[i]++;
                    }
                }
            }
            for (int i = 0; i < money2.Length; i++)
            {
                Console.Write("{0} ", money2[i]);
            }

            Console.ReadKey();
        }
    }
}
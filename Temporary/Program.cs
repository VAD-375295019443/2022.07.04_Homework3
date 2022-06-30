using System;

namespace Temporary
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            

            int x = 2;
            int y = 3;


            int z;
            
            z = summ(x, y);
            Console.WriteLine(z);
            

        }



        public static int summ(int x, int y)
        {
            int a = 0;
            a = x + y;
            return a;
        }


    }
}
using System;

namespace Temporary
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string strPath = @"d:\Plain.txt";



            //Свойство Exists: указывает, существует ли файл

            //Свойство Length: получает размер файла
            if(File.Exists(strPath) == true) //Если файл существует.
            {
                if (args.Length > 0) //Если файл не пустой.
                {







                }
            }
            
            




            File.AppendAllText(strPath, "\n" + "Hello");
            File.AppendAllText(strPath, "\n" + "aaaaa");
            File.AppendAllText(strPath, "\n" + "bbbbbb");


            string y = File.ReadAllText(strPath);
            Console.WriteLine(y);
            Console.WriteLine("---------------------");


            string[] x;
            x = new string[0];

            x = File.ReadAllLines(strPath);


            for(int Int1=0; Int1<=x.Length-1; Int1++)
            {
                Console.WriteLine(x[Int1]);


            }


            
            List<string> DatabaseAirplane = new List<string>(); //Создаем коллекцию базы данных воздушных судов.





        }
    }
}
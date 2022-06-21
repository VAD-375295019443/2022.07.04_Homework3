using System;

namespace Airline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (1 == 1)
            {
                Console.Clear();
                Console.WriteLine("Для создания нового аэропорта введите 1.");
                Console.WriteLine("Для редактирования существующего аэропорта введите 2.");
                Console.WriteLine("Для анализа показателей аэропорта введите 3.");
                Console.WriteLine("Для выхода введите Exit.");
                Console.WriteLine();

                string strMenuNumber = Console.ReadLine();

                if (strMenuNumber == "1")
                {

                }
                else if (strMenuNumber == "2")
                {

                }
                else if (strMenuNumber == "3")
                {

                }
                else if (strMenuNumber == "Exit" || strMenuNumber == "exit")
                {
                    Console.Clear();
                    Console.WriteLine("Goodbye.");
                    break;
                }
                else
                {
                    Console.Clear(); 
                    Console.WriteLine("Вы ввели не корректные данные.");
                    Console.WriteLine("Для продолжения нажмите Enter.");
                    Console.WriteLine(); 
                    strMenuNumber = Console.ReadLine();
                    continue;
                }







            }
        }
    }






    public class claAirLine
    {
        public int      intId; //Код.
        public string   strName; //Название авиакомпании.
    }


    public class claAirPlane
    {
        public int      intLinkCode; //Код связи.
        public string   strName; //Название самолета (тип).
        public int      intPassengerCapacity; //Вместимость пассажиров (количество посадочных мест).
        public double   dblCargoCapacity; //Вместимость груза (кг).
        public double   dblFlightRange; //Дальность полета (км).
        public int      intFuelConsumption; //Количество потребляемого топлива (л).
    }
}
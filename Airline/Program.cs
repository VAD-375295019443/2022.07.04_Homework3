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
                Console.WriteLine("РЕЕСТР МЕЖДУНАРОДНЫХ АВИАКОМПАНИЙ.");
                Console.WriteLine();
                Console.WriteLine("Введите номер пункта меню:");
                Console.WriteLine("1 - Создание авиакомпании.");
                Console.WriteLine("2 - Редактирование авиакомпании.");
                Console.WriteLine("3 - Анализ показателей авиакомпании.");
                Console.WriteLine("Для выхода наберите Exit.");
                Console.WriteLine();

                string strMenuNumber = Console.ReadLine();

                if (strMenuNumber == "1")
                {

                    //Вы вошли в раздел создания авиакомпаний.
                    //Метод создания авиакомпании.


                    


                }
                else if (strMenuNumber == "2")
                {



                    //Вы вошли в раздел редактирования авиакомпаний.
                    //Метод редактирования авиакомпани.

                }
                else if (strMenuNumber == "3")
                {
                    //Вы вошли в раздел анализа показателей авиакомпаний.
                    //Метод анализа показателей авиакомпании.


                    //Вся информация о авиакомпаниях, находящихся в составе реестра.
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
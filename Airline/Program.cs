using System;

namespace Airline
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                List<claAirLine> AirLine = new List<claAirLine>(); //Создаем коллекцию авиакомпаний.
                //Сюда засунуть данные из файла.

                Console.Clear();
                Console.WriteLine("РЕЕСТР МЕЖДУНАРОДНЫХ АВИАКОМПАНИЙ.");
                Console.WriteLine();
                Console.WriteLine("Введите номер пункта меню:");
                Console.WriteLine("1 - Создание авиакомпании.");
                Console.WriteLine("2 - Редактирование авиакомпании.");
                Console.WriteLine("3 - Анализ показателей авиакомпании.");
                Console.WriteLine("4 - Удаление авиакомпании.");
                Console.WriteLine("Для выхода наберите Exit.");
                Console.WriteLine();

                string? strMenuNumber = Console.ReadLine();

                if (strMenuNumber == "1")
                {
                    F_voiCreateAirline(ref AirLine); //Метод создания авиакомпании.





                }
                else if (strMenuNumber == "2")
                {
                    //Метод редактирования авиакомпани.
                }
                else if (strMenuNumber == "3")
                {
                    //Метод анализа показателей авиакомпании.
                }
                else if (strMenuNumber == "4")
                {
                    //Метод удаления авиакомпании.
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




        //Метод создания авиакомпании.
        public static void F_voiCreateAirline(ref List<claAirLine> AirLine)
        {
                AirLine.Add(new claAirLine("jjhj"));
                AirLine[AirLine.Count - 1].AirPlane.Add(new claAirPlane("hjkh", 14, 12.5, 45.3, 56));




            while (true)
            {

                Console.Clear();
                Console.WriteLine("Вы находитесь в разделе создания авиакомпаний.");
                Console.WriteLine("Для выхода наберите Exit.");
                Console.WriteLine();
                Console.WriteLine("Введите название создаваемой авиакомпании:");
                Console.WriteLine();


                string? strNameAirline = Console.ReadLine();
                if (strNameAirline == "Exit" || strNameAirline == "exit")
                {
                    break;
                }
                else if (strNameAirline == "" || strNameAirline == null)
                {
                    continue;
                }
                else
                {




                }

            }






        }


        //Класс самолетов.
        public class claAirPlane
        {
            public string strName; //Название самолета (тип).
            public int intPassengerCapacity; //Вместимость пассажиров (количество посадочных мест).
            public double dblCargoCapacity; //Вместимость груза (кг).
            public double dblFlightRange; //Дальность полета (км).
            public int intFuelConsumption; //Количество потребляемого топлива (л).

            public claAirPlane(string strName, int intPassengerCapacity, double dblCargoCapacity, double dblFlightRange, int intFuelConsumption)
            {
                this.strName = strName;
                this.intPassengerCapacity = intPassengerCapacity;
                this.dblCargoCapacity = dblCargoCapacity;
                this.dblFlightRange = dblFlightRange;
                this.intFuelConsumption = intFuelConsumption;
            }
        }


        //Класс авиакомпаний.
        public class claAirLine
        {
            public string strName; //Название авиакомпании.
            public List<claAirPlane> AirPlane = new List<claAirPlane>(); //Создаем коллекцию самолетов.
            
            public claAirLine(string strName)
            {
                this.strName = strName;
            }
        }














        //Метод редактирования авиакомпании.
        public static void F_voiEditAirline()
        {
            Console.Clear();
            Console.WriteLine("Вы находитесь в разделе редактирования авиакомпаний.");
            Console.WriteLine();

        }


        //Метод анализа авиакомпании.
        public static void F_voiAnalysisAirline()
        {
            Console.Clear();
            Console.WriteLine("Вы находитесь в разделе анализа показателей авиакомпаний.");
            Console.WriteLine();
            
            
            
            //Вся информация о авиакомпаниях, зарегистрированных в реестре.
        }


        //Метод удаления авиакомпании.
        public static void F_voiDeleteAirline()
        {
            Console.Clear();
            Console.WriteLine("Вы находитесь в разделе удаления авиакомпаний.");
            Console.WriteLine();

        }








    }
}
using System;

namespace Temporary
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<claAirline> Airline = new List<claAirline>(); //Создаем коллекцию авиакомпаний.

            Airline.Add(new claAirline("cccccccc"));
            Airline.Add(new claAirline("aaaaaaaa"));
            Airline.Add(new claAirline("bbbbbbbb"));


            Airline[0].Airplane.Add(new claAirplane("yyyyyyyyyy", 99, 88, 22, 33));
            Airline[0].Airplane.Add(new claAirplane("wwwww", 333, 111, 44, 11));
            Airline[0].Airplane.Add(new claAirplane("qqqqqqqqqqqqqq", 55, 33, 22, 7));


            Airline[1].Airplane.Add(new claAirplane("ssssssssssss", 45, 56, 78, 12));
            Airline[1].Airplane.Add(new claAirplane("kkkkkkkkkkkkk", 13, 76, 8, 1));
            Airline[1].Airplane.Add(new claAirplane("llllllllllll", 48, 8, 65, 3));


            Airline[2].Airplane.Add(new claAirplane("yytytyt", 15, 6, 7, 2));
            Airline[2].Airplane.Add(new claAirplane("sdds", 138, 776, 14, 1));
            Airline[2].Airplane.Add(new claAirplane("yythkhkkytyt", 458, 478, 25, 13));

            for (int int1=0; int1<=Airline.Count-1; int1++)
            {
                Console.WriteLine(Airline[int1].strName);

                for (int int2=0; int2 <= Airline[int1].Airplane.Count-1; int2++)
                {
                    Console.WriteLine(Airline[int1].Airplane[int2].strName);
                    Console.WriteLine(Airline[int1].Airplane[int2].intPassengerCapacity);
                    Console.WriteLine(Airline[int1].Airplane[int2].dblCargoCapacity);
                    Console.WriteLine(Airline[int1].Airplane[int2].dblFlightRange);
                    Console.WriteLine(Airline[int1].Airplane[int2].dblFuelConsumption);
                }
            }

            Console.WriteLine();
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine();




            /*
            var sortedPeople1 = Airline.OrderByDescending(x => x.strName)
                .ThenBy(x => x.strName)
                .ToList();
            */

            var sortedPeople1 = Airline.Where(x => x.strName == "cccccccc" || x.strName == "bbbbbbbb")
                .ToList();






            for (int int1 = 0; int1 <= sortedPeople1.Count-1; int1++)
            {
                Console.WriteLine(sortedPeople1[int1].strName);

                for (int int2 = 0; int2 <= Airline[int1].Airplane.Count - 1; int2++)
                {
                    Console.WriteLine(sortedPeople1[int1].Airplane[int2].strName);
                    Console.WriteLine(sortedPeople1[int1].Airplane[int2].intPassengerCapacity);
                    Console.WriteLine(sortedPeople1[int1].Airplane[int2].dblCargoCapacity);
                    Console.WriteLine(sortedPeople1[int1].Airplane[int2].dblFlightRange);
                    Console.WriteLine(sortedPeople1[int1].Airplane[int2].dblFuelConsumption);
                }
            }





        }



        //Класс воздушных судов.
        public class claAirplane
        {
            public string strName; //Название самолета (тип).
            public int intPassengerCapacity; //Вместимость пассажиров (количество посадочных мест).
            public double dblCargoCapacity; //Вместимость груза (кг).
            public double dblFlightRange; //Дальность полета (км).
            public double dblFuelConsumption; //Количество потребляемого топлива (л).

            public claAirplane(string strName, int intPassengerCapacity, double dblCargoCapacity, double dblFlightRange, double dblFuelConsumption)
            {
                this.strName = strName;
                this.intPassengerCapacity = intPassengerCapacity;
                this.dblCargoCapacity = dblCargoCapacity;
                this.dblFlightRange = dblFlightRange;
                this.dblFuelConsumption = dblFuelConsumption;
            }
        }


        //Класс авиакомпаний.
        public class claAirline
        {
            public string strName; //Название авиакомпаний.
            public List<claAirplane> Airplane = new List<claAirplane>(); //Создаем коллекцию самолетов.

            public claAirline(string strName)
            {
                this.strName = strName;
            }
        }


    }
}
using System;

namespace Airline
{
    internal class Program
    {
        static void Main(string[] args)
        {


            
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
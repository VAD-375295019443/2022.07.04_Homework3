using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline
{
    internal class claAirplane
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
}

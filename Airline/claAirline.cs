using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline
{
    internal class claAirline
    {
        public string strName; //Название авиакомпаний.
        public List<claAirplane> Airplane = new List<claAirplane>(); //Создаем коллекцию самолетов.

        public claAirline(string strName)
        {
            this.strName = strName;
        }
    }
}

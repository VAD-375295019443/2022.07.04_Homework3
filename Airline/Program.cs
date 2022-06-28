using System;

namespace Airline
{
    internal class Program
    {
        
        public static void Main(string[] args)
        {
            List<claAirplane> DatabaseAirplane = new List<claAirplane>(); //Создаем коллекцию базы данных воздушных судов.
            F_ReadDatabaseAirplane(ref DatabaseAirplane); //Считываем базу данных воздушных судов из файла в коллекцию.

            List<claAirline> Airline = new List<claAirline>(); //Создаем коллекцию авиакомпаний.






            while (true)
            {
                //Сюда засунуть данные из файла.

                Console.Clear();
                Console.WriteLine("РЕЕСТР МЕЖДУНАРОДНЫХ АВИАКОМПАНИЙ.");
                Console.WriteLine();
                Console.WriteLine("Введите номер пункта меню:");
                Console.WriteLine("1 - Создание авиакомпаний.");
                Console.WriteLine("2 - Редактирование авиакомпаний.");
                Console.WriteLine("3 - Анализ показателей авиакомпаний.");
                Console.WriteLine("4 - Удаление авиакомпаний.");
                Console.WriteLine("5 - Редактирование базы данных воздушных судов.");
                Console.WriteLine("Exit - Выход.");
                Console.WriteLine();

                string? strMenuNumber = Console.ReadLine();

                if (strMenuNumber == "1")
                {
                    F_voiCreateAirline(ref Airline); //Метод создания авиакомпаний.





                }
                else if (strMenuNumber == "2")
                {
                    //Метод редактирования авиакомпанй.
                }
                else if (strMenuNumber == "3")
                {
                    //Метод анализа показателей авиакомпаний.
                }
                else if (strMenuNumber == "4")
                {
                    //Метод удаления авиакомпаний.
                }
                else if (strMenuNumber == "5")
                {
                    F_DatabaseAirplane(ref DatabaseAirplane); //Метод редактирования базы данных воздушных судов.
                }
                else if (strMenuNumber == "Exit" || strMenuNumber == "exit")
                {
                    Console.Clear();
                    Console.WriteLine("Goodbye.");
                    break;
                }
                else
                {
                    continue;
                }


            }
        }




        //Метод редактирования базы данных воздушных судов.
        public static void F_DatabaseAirplane(ref List<claAirplane> DatabaseAirplane)
        {
            int intAirplaneNumber; //Номер воздушного судна.

            string strName; //Название самолета (тип).
            int intPassengerCapacity; //Вместимость пассажиров (количество посадочных мест).
            double dblCargoCapacity; //Вместимость груза (кг).
            double dblFlightRange; //Дальность полета (км).
            double dblFuelConsumption; //Количество потребляемого топлива (л).

            string? strMenuNumber; //Номер меню.

            while (true)
            {
                Console.Clear();
                Console.WriteLine("РЕЕСТР МЕЖДУНАРОДНЫХ АВИАКОМПАНИЙ.");
                Console.WriteLine();
                Console.WriteLine("Вы находитесь в разделе редактирования базы данных воздушных судов.");
                Console.WriteLine();

                if (DatabaseAirplane.Count == 0)
                {
                    Console.WriteLine("В базе данных нет воздушных судов.");
                }
                else
                {
                    for (int int1 = 0; int1 <= DatabaseAirplane.Count - 1; int1++)
                    {
                        Console.WriteLine("Воздушное судно:");
                        Console.WriteLine($"{int1} - {DatabaseAirplane[int1].strName}");
                        Console.WriteLine($"     Параметры:"); ;
                        Console.WriteLine($"     Вместимость пассажиров (количество посадочных мест): {DatabaseAirplane[int1].intPassengerCapacity}");
                        Console.WriteLine($"     Вместимость груза (кг): {DatabaseAirplane[int1].dblCargoCapacity}");
                        Console.WriteLine($"     Дальность полета (км): {DatabaseAirplane[int1].dblFlightRange}");
                        Console.WriteLine($"     Количество потребляемого топлива (л): {DatabaseAirplane[int1].dblFuelConsumption}");
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Введите номер пункта меню:");
                Console.WriteLine("1 - Добавление воздушного судна.");
                Console.WriteLine("2 - Удаление воздушного судна.");
                Console.WriteLine("Exit - Возврат в предыдущее меню.");
                Console.WriteLine();

                strMenuNumber = Console.ReadLine();
                Console.WriteLine();

                if (strMenuNumber == "1")
                {
                    Console.WriteLine("Введите наименование воздушного судна:");
                    strName = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("Введите вместимость пассажиров (количество посадочных мест):");
                    intPassengerCapacity = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    Console.WriteLine("Введите вместимость груза (кг):");
                    dblCargoCapacity = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine();
                    Console.WriteLine("Введите дальность полета (км):");
                    dblFlightRange = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine();
                    Console.WriteLine("Введите количество потребляемого топлива (л):");
                    dblFuelConsumption = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine();

                    DatabaseAirplane.Add(new claAirplane(strName, intPassengerCapacity, dblCargoCapacity, dblFlightRange, dblFuelConsumption));

                    F_WriteDatabaseAirplane(DatabaseAirplane);
                }
                else if (strMenuNumber == "2")
                {
                    Console.WriteLine("Введите номер воздушного судна:");
                    intAirplaneNumber = Convert.ToInt32(Console.ReadLine());

                    if(intAirplaneNumber >= 0 && intAirplaneNumber <= DatabaseAirplane.Count) //Если такой номер воздушного судна есть.
                    {
                        DatabaseAirplane.RemoveRange(intAirplaneNumber, 1); //Удаляем воздушное судно под этим номером.

                        F_WriteDatabaseAirplane(DatabaseAirplane); //Перезаписываем коллекцию в файл.
                    }
                }
                else if (strMenuNumber == "Exit" || strMenuNumber == "exit")
                {
                    break;
                }
                else
                {
                    continue;
                }
            }
        }












        //Метод создания авиакомпаний.
        public static void F_voiCreateAirline(ref List<claAirline> Airline)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("РЕЕСТР МЕЖДУНАРОДНЫХ АВИАКОМПАНИЙ.");
                Console.WriteLine();
                Console.WriteLine("Вы находитесь в разделе создания авиакомпаний.");
                Console.WriteLine("Для выхода в главное меню наберите Exit.");
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
                    Airline.Add(new claAirline(strNameAirline));

                    int intNumberAirline = Airline.Count - 1;
                    F_voiEditAirline(ref Airline, intNumberAirline);
                    
                    break;
                }
            }
        }


        //Класс самолетов.
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












        //Метод редактирования авиакомпаний.
        public static void F_voiEditAirline(ref List<claAirline> Airline, int intNumberAirline)
        {
            Console.Clear();
            Console.WriteLine("РЕЕСТР МЕЖДУНАРОДНЫХ АВИАКОМПАНИЙ.");
            Console.WriteLine();
            Console.WriteLine("Вы находитесь в разделе редактирования авиакомпаний.");
            Console.WriteLine();
            Console.WriteLine("Введите номер пункта меню:");
            Console.WriteLine("1 - Добавление воздушного судна.");
            Console.WriteLine("2 - Удаление воздушного судна.");
            Console.WriteLine("3 - Переход в базу данных воздушных судов.");
            Console.WriteLine("Exit - Выход в главное меню.");
            Console.WriteLine();
            Console.WriteLine("Авиакомпания:");
            Console.WriteLine(Airline[intNumberAirline].strName);
            Console.WriteLine("     Воздушные суда:");
            Console.WriteLine();








            Console.ReadLine();







        }


        //Метод анализа авиакомпаний.
        public static void F_voiAnalysisAirline()
        {
            Console.Clear();
            Console.WriteLine("Вы находитесь в разделе анализа показателей авиакомпаний.");
            Console.WriteLine();
            
            
            
            //Вся информация о авиакомпаниях, зарегистрированных в реестре.
        }


        //Метод удаления авиакомпаний.
        public static void F_voiDeleteAirline()
        {
            Console.Clear();
            Console.WriteLine("Вы находитесь в разделе удаления авиакомпаний.");
            Console.WriteLine();

        }






        //Метод выбора авиакомпаний.
        public static int F_intSelectAirline(ref List<claAirline> Airline)
        {




            return (1);
        }








        //Считываем базу данных воздушных судов из файла в коллекцию.
        public static void F_ReadDatabaseAirplane(ref List<claAirplane> DatabaseAirplane)
        {
            string strPath = @"d:\Registry\DatabaseAirplane";

            if (Directory.Exists(strPath) == false) //Если директории не существует.
            {
                Directory.CreateDirectory(strPath); //Создаем.
            }
            else
            {
                strPath = @"d:\Registry\DatabaseAirplane\DatabaseAirplane.txt";

                string[] arrstrDatabaseAirplane = new string[0]; ;

                string strName; //Название самолета (тип).
                int intPassengerCapacity; //Вместимость пассажиров (количество посадочных мест).
                double dblCargoCapacity; //Вместимость груза (кг).
                double dblFlightRange; //Дальность полета (км).
                double dblFuelConsumption; //Количество потребляемого топлива (л).

                if (File.Exists(strPath) == true) //Если файл существует.
                {
                    Array.Resize(ref arrstrDatabaseAirplane, 0);
                    arrstrDatabaseAirplane = File.ReadAllLines(strPath);

                    for (int int1 = 0; int1 <= arrstrDatabaseAirplane.Length - 1; int1++)
                    {
                        strName = arrstrDatabaseAirplane[int1]; //Название самолета (тип).
                        int1++;
                        intPassengerCapacity = Convert.ToInt32(arrstrDatabaseAirplane[int1]); //Вместимость пассажиров (количество посадочных мест).
                        int1++;
                        dblCargoCapacity = Convert.ToDouble(arrstrDatabaseAirplane[int1]); //Вместимость груза (кг).
                        int1++;
                        dblFlightRange = Convert.ToDouble(arrstrDatabaseAirplane[int1]); //Дальность полета (км).
                        int1++;
                        dblFuelConsumption = Convert.ToDouble(arrstrDatabaseAirplane[int1]); //Количество потребляемого топлива (л).

                        DatabaseAirplane.Add(new claAirplane(strName, intPassengerCapacity, dblCargoCapacity, dblFlightRange, dblFuelConsumption));
                    }
                }
            }
        }


        //Считываем авиакомпании из файла в коллекцию.
        public static void F_ReadAirline(ref List<claAirline> Airline)
        {
            string strPath;

            string[] arrstrAirplane = new string[0]; ;
            
            string strName; //Название самолета (тип).
            int intPassengerCapacity; //Вместимость пассажиров (количество посадочных мест).
            double dblCargoCapacity; //Вместимость груза (кг).
            double dblFlightRange; //Дальность полета (км).
            double dblFuelConsumption; //Количество потребляемого топлива (л).
            
            for (int int1 = 0; ; int1++)
            {
                //Считывание авиакомпании.
                strPath = @"d:\Registry\Airline\" + Convert.ToString(int1) + @"\Airline.txt";
                if (File.Exists(strPath) == true) //Если файл существует.
                {
                    strName = File.ReadAllText(strPath);
                    Airline.Add(new claAirline(strName));

                    //Считывание воздушных судов.
                    strPath = @"d:\Registry\Airline\" + Convert.ToString(int1) + @"\Airplane.txt";
                    if (File.Exists(strPath) == true) //Если файл существует.
                    {
                        Array.Resize(ref arrstrAirplane, 0);
                        arrstrAirplane = File.ReadAllLines(strPath);

                        for (int int2 = 0; int2 <= arrstrAirplane.Length - 1; int2++)
                        {
                            strName = arrstrAirplane[int2]; //Название самолета (тип).
                            intPassengerCapacity = Convert.ToInt32(arrstrAirplane[int2++]); //Вместимость пассажиров (количество посадочных мест).
                            dblCargoCapacity = Convert.ToDouble(arrstrAirplane[int2++]); //Вместимость груза (кг).
                            dblFlightRange = Convert.ToDouble(arrstrAirplane[int2++]); //Дальность полета (км).
                            dblFuelConsumption = Convert.ToDouble(arrstrAirplane[int2++]); //Количество потребляемого топлива (л).

                            Airline[Airline.Count - 1].Airplane.Add(new claAirplane(strName, intPassengerCapacity, dblCargoCapacity, dblFlightRange, dblFuelConsumption));
                        }
                    }
                }
                else
                {
                    break;
                }
            }
        }


        //Сохраняем базу данных воздушных судов из коллекции в файл.
        public static void F_WriteDatabaseAirplane(List<claAirplane> DatabaseAirplane)
        {
            string strPath = @"d:\Registry\DatabaseAirplane";

            if (Directory.Exists(strPath) == true) //Если директория существует.
            {
                Directory.Delete(strPath, true); //Удаляем.
            }

            Directory.CreateDirectory(strPath);

            strPath = @"d:\Registry\DatabaseAirplane\DatabaseAirplane.txt";
            
            if (DatabaseAirplane.Count > 0)
            {
                for (int int1 = 0; int1 <= DatabaseAirplane.Count - 1; int1++)
                {
                    if(File.Exists(strPath) == true) //Если файл существует.
                    {
                        File.AppendAllText(strPath, "\n" + DatabaseAirplane[int1].strName); //Название самолета (тип).
                        File.AppendAllText(strPath, "\n" + Convert.ToString(DatabaseAirplane[int1].intPassengerCapacity)); //Вместимость пассажиров (количество посадочных мест).
                        File.AppendAllText(strPath, "\n" + Convert.ToString(DatabaseAirplane[int1].dblCargoCapacity)); //Вместимость груза (кг).
                        File.AppendAllText(strPath, "\n" + Convert.ToString(DatabaseAirplane[int1].dblFlightRange)); //Дальность полета (км).
                        File.AppendAllText(strPath, "\n" + Convert.ToString(DatabaseAirplane[int1].dblFuelConsumption)); //Количество потребляемого топлива (л).
                    }
                    else
                    {
                        File.AppendAllText(strPath, DatabaseAirplane[int1].strName); //Название самолета (тип).
                        File.AppendAllText(strPath, "\n" + Convert.ToString(DatabaseAirplane[int1].intPassengerCapacity)); //Вместимость пассажиров (количество посадочных мест).
                        File.AppendAllText(strPath, "\n" + Convert.ToString(DatabaseAirplane[int1].dblCargoCapacity)); //Вместимость груза (кг).
                        File.AppendAllText(strPath, "\n" + Convert.ToString(DatabaseAirplane[int1].dblFlightRange)); //Дальность полета (км).
                        File.AppendAllText(strPath, "\n" + Convert.ToString(DatabaseAirplane[int1].dblFuelConsumption)); //Количество потребляемого топлива (л).
                    }
                }
            }
        }











    }
}
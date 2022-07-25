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
            F_ReadAirline(ref Airline); //Считываем авиакомпании из файла в коллекцию.

            while (true)
            {
                Console.Clear();
                Console.WriteLine("РЕЕСТР МЕЖДУНАРОДНЫХ АВИАКОМПАНИЙ.");
                Console.WriteLine();
                Console.WriteLine("Авиакомпания:");

                if(Airline.Count == 0)
                {
                    Console.WriteLine("В реестре нет авиакомпаний.");
                }
                else
                {
                    for (int int1 = 0; int1 <= Airline.Count - 1; int1++)
                    {
                        Console.WriteLine($"{int1} - {Airline[int1].strName}");
                        Console.WriteLine($"          Воздушное судно:");

                        if (Airline[int1].Airplane.Count == 0)
                        {
                            Console.WriteLine($"          В авиакомпании нет воздушных судов.");
                        }
                        else
                        {
                            for (int int2 = 0; int2 <= Airline[int1].Airplane.Count - 1; int2++)
                            {
                                Console.WriteLine($"          {Airline[int1].Airplane[int2].strName}");
                            }
                        }

                    }
                }

                Console.WriteLine();
                Console.WriteLine("Введите номер пункта меню:");
                Console.WriteLine("1 - Создание авиакомпаний.");
                Console.WriteLine("2 - Редактирование авиакомпаний.");
                Console.WriteLine("3 - Анализ показателей авиакомпаний.");
                Console.WriteLine("4 - Удаление авиакомпаний.");
                Console.WriteLine("5 - Редактирование базы данных воздушных судов.");
                Console.WriteLine("Exit - Выход.");

                string? strMenuNumber = Console.ReadLine();
                int intAirlineNumber;
                bool booErrorControl; //Контроль ошибок.

                //Создание авиакомпаний.
                if (strMenuNumber == "1") 
                { 
                    F_voiCreateAirline(ref Airline, ref DatabaseAirplane); //Метод создания авиакомпаний.
                }
                //Редактирование авиакомпаний.
                else if (strMenuNumber == "2") 
                {
                    while (true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Введите номер редактируемой авиакомпании:");
                        booErrorControl = Int32.TryParse(Console.ReadLine(), out intAirlineNumber);
                        if (booErrorControl == true)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Вы ввели не корректные данные! Повторите попытку.");
                            continue;
                        }
                    }

                    if (intAirlineNumber >= 0 && intAirlineNumber <= Airline.Count - 1) //Если такой номер авиакомпании есть.
                    {
                        F_voiEditAirline(intAirlineNumber, ref Airline, ref DatabaseAirplane); //Метод редактирования авиакомпанй.
                    }
                }
                //Анализ показателей авиакомпаний.
                else if (strMenuNumber == "3")
                {
                    while (true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Введите номер анализируемой авиакомпании:");
                        booErrorControl = Int32.TryParse(Console.ReadLine(), out intAirlineNumber);
                        if (booErrorControl == true)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Вы ввели не корректные данные! Повторите попытку.");
                            continue;
                        }
                    }

                    if (intAirlineNumber >= 0 && intAirlineNumber <= Airline.Count - 1) //Если такой номер авиакомпании есть.
                    {
                        F_voiAnalysisAirline(intAirlineNumber, ref Airline); //Метод анализа параметров авиакомпанй.
                    }
                }
                //Удаление авиакомпаний.
                else if (strMenuNumber == "4")
                {
                    while (true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Введите номер удаляемой авиакомпании:");
                        booErrorControl = Int32.TryParse(Console.ReadLine(), out intAirlineNumber);
                        if (booErrorControl == true)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Вы ввели не корректные данные! Повторите попытку.");
                            continue;
                        }
                    }

                    if (intAirlineNumber >= 0 && intAirlineNumber <= Airline.Count - 1) //Если такой номер авиакомпании есть.
                    {
                        Airline.RemoveRange(intAirlineNumber, 1);
                        F_WriteAirline(Airline);
                    }
                }
                //Редактирование базы данных воздушных судов.
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


        //Метод создания авиакомпаний.
        public static void F_voiCreateAirline(ref List<claAirline> Airline, ref List<claAirplane> DatabaseAirplane)
        {
            Console.WriteLine();
            Console.WriteLine("Введите название создаваемой авиакомпании:");
            
            string? strNameAirline = Console.ReadLine();
            
            if (strNameAirline != "" || strNameAirline != null)
            {
                Airline.Add(new claAirline(strNameAirline));
                F_WriteDatabaseAirplane(DatabaseAirplane); //Перезаписываем коллекцию в файл.

                int intAirlineNumber = Airline.Count - 1;
                F_voiEditAirline(intAirlineNumber, ref Airline, ref DatabaseAirplane); //Переходим в метод редактирования авиакомпаний.
            }
        }


        //Метод редактирования авиакомпаний.
        public static void F_voiEditAirline(int intAirlineNumber, ref List<claAirline> Airline, ref List<claAirplane> DatabaseAirplane)
        {
            int intAirplaneNumber; //Номер воздушного судна.
            string? strMenuNumber; //Номер меню.
            bool booErrorControl; //Контроль ошибок.

            while (true)
            {
                Console.Clear();
                Console.WriteLine("РЕЕСТР МЕЖДУНАРОДНЫХ АВИАКОМПАНИЙ.");
                Console.WriteLine();
                Console.WriteLine("Вы находитесь в разделе редактирования авиакомпаний.");
                Console.WriteLine();
                Console.WriteLine("Авиакомпания:");
                Console.WriteLine(Airline[intAirlineNumber].strName);
                Console.WriteLine($"          Воздушное судно:"); ;

                if(Airline[intAirlineNumber].Airplane.Count == 0) 
                {
                    Console.WriteLine("          В авиакомпании нет воздушных судов.");
                }
                else
                {
                    for (int int1 = 0; int1 <= Airline[intAirlineNumber].Airplane.Count - 1; int1++)
                    {
                        Console.WriteLine($"          {int1} - {Airline[intAirlineNumber].Airplane[int1].strName}");
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Введите номер пункта меню:");
                Console.WriteLine("1 - Добавление воздушного судна.");
                Console.WriteLine("2 - Удаление воздушного судна.");
                Console.WriteLine("3 - Редактирование базы данных воздушных судов.");
                Console.WriteLine("Exit - Возврат в предыдущее меню.");

                strMenuNumber = Console.ReadLine();

                if (strMenuNumber == "1")
                {
                    if (DatabaseAirplane.Count > 0)
                    {
                        Console.WriteLine();
                        for (int int1 = 0; int1 <= DatabaseAirplane.Count - 1; int1++)
                        {
                            Console.WriteLine($"{int1} - {DatabaseAirplane[int1].strName}");
                        }
                    }
                    else
                    {
                        continue;
                    }

                    while (true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Введите номер добавляемого воздушного судна:");
                        booErrorControl = Int32.TryParse(Console.ReadLine(), out intAirplaneNumber);
                        if (booErrorControl == true)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Вы ввели не корректные данные! Повторите попытку.");
                            continue;
                        }
                    }

                    if (intAirplaneNumber >= 0 && intAirplaneNumber <= DatabaseAirplane.Count - 1) //Если такой номер воздушного судна есть в базе данных.
                    {
                        Airline[intAirlineNumber].Airplane.Add(new claAirplane(DatabaseAirplane[intAirplaneNumber].strName, DatabaseAirplane[intAirplaneNumber].intPassengerCapacity, DatabaseAirplane[intAirplaneNumber].dblCargoCapacity, DatabaseAirplane[intAirplaneNumber].dblFlightRange, DatabaseAirplane[intAirplaneNumber].dblFuelConsumption));
                        F_WriteAirline(Airline);
                    }
                }
                else if (strMenuNumber == "2")
                {
                    while (true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Введите номер удаляемого воздушного судна:");
                        booErrorControl = Int32.TryParse(Console.ReadLine(), out intAirplaneNumber);
                        if (booErrorControl == true)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Вы ввели не корректные данные! Повторите попытку.");
                            continue;
                        }
                    }

                    if (intAirplaneNumber >= 0 && intAirplaneNumber <= Airline[intAirlineNumber].Airplane.Count - 1) //Если такой номер воздушного судна есть.
                    {
                        Airline[intAirlineNumber].Airplane.RemoveRange(intAirplaneNumber, 1);
                        F_WriteAirline(Airline);
                    }
                }
                else if (strMenuNumber == "3")
                {
                    F_DatabaseAirplane(ref DatabaseAirplane); //Метод редактирования базы данных воздушных судов.
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


        //Метод анализа показателей авиакомпаний.
        public static void F_voiAnalysisAirline(int intAirlineNumber, ref List<claAirline> Airline)
        {
            string? strMenuNumber; //Номер меню.

            while(true)
            {
                Console.Clear();
                Console.WriteLine("РЕЕСТР МЕЖДУНАРОДНЫХ АВИАКОМПАНИЙ.");
                Console.WriteLine();
                Console.WriteLine("Вы находитесь в разделе анализа показателей авиакомпаний.");
                Console.WriteLine();
                Console.WriteLine("Авиакомпания:");
                Console.WriteLine(Airline[intAirlineNumber].strName);
                Console.WriteLine($"          Воздушное судно:");

                if (Airline[intAirlineNumber].Airplane.Count == 0)
                {
                    Console.WriteLine("          В авиакомпании нет воздушных судов.");
                }
                else
                {
                    for (int int1 = 0; int1 <= Airline[intAirlineNumber].Airplane.Count - 1; int1++)
                    {
                        Console.WriteLine($"          {Airline[intAirlineNumber].Airplane[int1].strName}");
                        Console.WriteLine($"                    Параметры:");
                        Console.WriteLine($"                    Вместимость пассажиров: {Airline[intAirlineNumber].Airplane[int1].intPassengerCapacity}");
                        Console.WriteLine($"                    Вместимость груза (кг): {Airline[intAirlineNumber].Airplane[int1].dblCargoCapacity}");
                        Console.WriteLine($"                    Дальность полета (км): {Airline[intAirlineNumber].Airplane[int1].dblFlightRange}");
                        Console.WriteLine($"                    Количество потребляемого топлива (л): {Airline[intAirlineNumber].Airplane[int1].dblFuelConsumption}");
                    }

                    Console.WriteLine();
                    Console.WriteLine("Введите номер пункта меню:");
                    Console.WriteLine("1 - Расчет общей вместимости пассажиров.");
                    Console.WriteLine("2 - Расчет общей грузоподъемности.");
                    Console.WriteLine("3 - Расчет общей дальности полета.");
                    Console.WriteLine("4 - Расчет общего количества потребляемого топлива.");
                    Console.WriteLine("5 - Расчет средней вместимости пассажиров.");
                    Console.WriteLine("6 - Расчет средней грузоподъемности.");
                    Console.WriteLine("7 - Расчет средней дальности полета.");
                    Console.WriteLine("8 - Расчет среднего количества потребляемого топлива.");
                    Console.WriteLine("9 - Сортировка воздушных судов по вместимости пассажиров.");
                    Console.WriteLine("10 - Сортировка воздушных судов по грузоподъемности.");
                    Console.WriteLine("11 - Сортировка воздушных судов по дальности полета.");
                    Console.WriteLine("12 - Сортировка воздушных судов по количеству потребляемого топлива.");
                    Console.WriteLine("13 - Запрос на диапазон вместимости пассажиров.");
                    Console.WriteLine("14 - Запрос на диапазон грузоподъемности.");
                    Console.WriteLine("15 - Запрос на диапазон дальности полета.");
                    Console.WriteLine("16 - Запрос на диапазон количества потребляемого топлива.");
                    Console.WriteLine("Exit - Возврат в предыдущее меню.");

                    strMenuNumber = Console.ReadLine();

                    if (strMenuNumber == "1")
                    {
                        F_voiParameterAnalysisTotal(intAirlineNumber, Airline, 1);
                    }
                    else if (strMenuNumber == "2")
                    {
                        F_voiParameterAnalysisTotal(intAirlineNumber, Airline, 2);
                    }
                    else if (strMenuNumber == "3")
                    {
                        F_voiParameterAnalysisTotal(intAirlineNumber, Airline, 3);
                    }
                    else if (strMenuNumber == "4")
                    {
                        F_voiParameterAnalysisTotal(intAirlineNumber, Airline, 4);
                    }
                    else if (strMenuNumber == "5")
                    {
                        F_voiParameterAnalysisAverage(intAirlineNumber, Airline, 1);
                    }
                    else if (strMenuNumber == "6")
                    {
                        F_voiParameterAnalysisAverage(intAirlineNumber, Airline, 2);
                    }
                    else if (strMenuNumber == "7")
                    {
                        F_voiParameterAnalysisAverage(intAirlineNumber, Airline, 3);
                    }
                    else if (strMenuNumber == "8")
                    {
                        F_voiParameterAnalysisAverage(intAirlineNumber, Airline, 4);
                    }
                    else if (strMenuNumber == "9")
                    {
                        F_dblParameterAnalysisSorting(intAirlineNumber, Airline, 1);
                    }
                    else if (strMenuNumber == "10")
                    {
                        F_dblParameterAnalysisSorting(intAirlineNumber, Airline, 2);
                    }
                    else if (strMenuNumber == "11")
                    {
                        F_dblParameterAnalysisSorting(intAirlineNumber, Airline, 3);
                    }
                    else if (strMenuNumber == "12")
                    {
                        F_dblParameterAnalysisSorting(intAirlineNumber, Airline, 4);
                    }
                    else if (strMenuNumber == "13")
                    {
                        F_dblParameterAnalysisRequest(intAirlineNumber, Airline, 1);
                    }
                    else if (strMenuNumber == "14")
                    {
                        F_dblParameterAnalysisRequest(intAirlineNumber, Airline, 2);
                    }
                    else if (strMenuNumber == "15")
                    {
                        F_dblParameterAnalysisRequest(intAirlineNumber, Airline, 3);
                    }
                    else if (strMenuNumber == "16")
                    {
                        F_dblParameterAnalysisRequest(intAirlineNumber, Airline, 4);
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
        }


        //Метод редактирования базы данных воздушных судов.
        public static void F_DatabaseAirplane(ref List<claAirplane> DatabaseAirplane)
        {
            int intAirplaneNumber; //Номер воздушного судна.
            string? strMenuNumber; //Номер меню.
            bool booErrorControl; //Контроль ошибок.

            string? strName; //Название самолета (тип).
            int intPassengerCapacity; //Вместимость пассажиров (количество посадочных мест).
            double dblCargoCapacity; //Вместимость груза (кг).
            double dblFlightRange; //Дальность полета (км).
            double dblFuelConsumption; //Количество потребляемого топлива (л).

            while (true)
            {
                Console.Clear();
                Console.WriteLine("РЕЕСТР МЕЖДУНАРОДНЫХ АВИАКОМПАНИЙ.");
                Console.WriteLine();
                Console.WriteLine("Вы находитесь в разделе редактирования базы данных воздушных судов.");
    
                if (DatabaseAirplane.Count == 0)
                {
                    Console.WriteLine("В базе данных нет воздушных судов.");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Воздушное судно:");

                    for (int int1 = 0; int1 <= DatabaseAirplane.Count - 1; int1++)
                    {
                        Console.WriteLine($"{int1} - {DatabaseAirplane[int1].strName}");
                        Console.WriteLine($"          Параметры:");
                        Console.WriteLine($"          Вместимость пассажиров (количество посадочных мест): {DatabaseAirplane[int1].intPassengerCapacity}");
                        Console.WriteLine($"          Вместимость груза (кг): {DatabaseAirplane[int1].dblCargoCapacity}");
                        Console.WriteLine($"          Дальность полета (км): {DatabaseAirplane[int1].dblFlightRange}");
                        Console.WriteLine($"          Количество потребляемого топлива (л): {DatabaseAirplane[int1].dblFuelConsumption}");
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Введите номер пункта меню:");
                Console.WriteLine("1 - Добавление воздушного судна.");
                Console.WriteLine("2 - Удаление воздушного судна.");
                Console.WriteLine("Exit - Возврат в предыдущее меню.");

                strMenuNumber = Console.ReadLine();

                if (strMenuNumber == "1")
                {
                    Console.WriteLine();
                    Console.WriteLine("Введите наименование воздушного судна:");
                    strName = Console.ReadLine();

                    while (true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Введите вместимость пассажиров (количество посадочных мест):");
                        booErrorControl = Int32.TryParse(Console.ReadLine(), out intPassengerCapacity);
                        if (booErrorControl == true)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Вы ввели не корректные данные! Повторите попытку.");
                            continue;
                        }
                    }

                    while (true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Введите вместимость груза (кг):");
                        booErrorControl = double.TryParse(Console.ReadLine(), out dblCargoCapacity);
                        if (booErrorControl == true)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Вы ввели не корректные данные! Повторите попытку.");
                            continue;
                        }
                    }

                    while (true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Введите дальность полета (км):");
                        booErrorControl = double.TryParse(Console.ReadLine(), out dblFlightRange);
                        if (booErrorControl == true)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Вы ввели не корректные данные! Повторите попытку.");
                            continue;
                        }
                    }

                    while (true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Введите количество потребляемого топлива (л):");
                        booErrorControl = double.TryParse(Console.ReadLine(), out dblFuelConsumption);
                        if (booErrorControl == true)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Вы ввели не корректные данные! Повторите попытку.");
                            continue;
                        }
                    }

                    DatabaseAirplane.Add(new claAirplane(strName, intPassengerCapacity, dblCargoCapacity, dblFlightRange, dblFuelConsumption));
                    F_WriteDatabaseAirplane(DatabaseAirplane); //Перезаписываем коллекцию в файл.
                }
                else if (strMenuNumber == "2")
                {
                    while (true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Введите номер удаляемого воздушного судна:");
                        booErrorControl = Int32.TryParse(Console.ReadLine(), out intAirplaneNumber);
                        if (booErrorControl == true)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Вы ввели не корректные данные! Повторите попытку.");
                            continue;
                        }
                    }

                    if(intAirplaneNumber >= 0 && intAirplaneNumber <= DatabaseAirplane.Count-1) //Если такой номер воздушного судна есть.
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
            string strPath = @"d:\Registry\Airline";

            if (Directory.Exists(strPath) == false) //Если директория не существует.
            {
                Directory.CreateDirectory(strPath); //Создаем.
            }
            else
            {
                string[] arrstrAirplane = new string[0]; ;
            
                string strName; //Название самолета (тип).
                int intPassengerCapacity; //Вместимость пассажиров (количество посадочных мест).
                double dblCargoCapacity; //Вместимость груза (кг).
                double dblFlightRange; //Дальность полета (км).
                double dblFuelConsumption; //Количество потребляемого топлива (л).
            
                for (int int1 = 0; ; int1++)
                {
                    strPath = $@"d:\Registry\Airline\{Convert.ToString(int1)}-Airline.txt";
                    if (File.Exists(strPath) == true) //Если файл существует.
                    {
                        strName = File.ReadAllText(strPath);
                        Airline.Add(new claAirline(strName));

                        //Считывание воздушных судов.
                        strPath = $@"d:\Registry\Airline\{Convert.ToString(int1)}-Airplane.txt";
                        if (File.Exists(strPath) == true) //Если файл существует.
                        {
                            Array.Resize(ref arrstrAirplane, 0);
                            arrstrAirplane = File.ReadAllLines(strPath);

                            for (int int2 = 0; int2 <= arrstrAirplane.Length - 1; int2++)
                            {
                                strName = arrstrAirplane[int2]; //Название самолета (тип).
                                int2++;
                                intPassengerCapacity = Convert.ToInt32(arrstrAirplane[int2]); //Вместимость пассажиров (количество посадочных мест).
                                int2++;
                                dblCargoCapacity = Convert.ToDouble(arrstrAirplane[int2]); //Вместимость груза (кг).
                                int2++;
                                dblFlightRange = Convert.ToDouble(arrstrAirplane[int2]); //Дальность полета (км).
                                int2++; 
                                dblFuelConsumption = Convert.ToDouble(arrstrAirplane[int2]); //Количество потребляемого топлива (л).

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
        }


        //Сохраняем базу данных воздушных судов из коллекции в файл.
        public static void F_WriteDatabaseAirplane(List<claAirplane> DatabaseAirplane)
        {
            string strPath = @"d:\Registry\DatabaseAirplane";

            if (Directory.Exists(strPath) == true) //Если директория существует.
            {
                Directory.Delete(strPath, true); //Удаляем.
            }

            Directory.CreateDirectory(strPath); //Создаем заново чистую.

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


        //Сохраняем авиакомпании из коллекции в файл.
        public static void F_WriteAirline(List<claAirline> Airline)
        {
            string strPath = @"d:\Registry\Airline";

            if (Directory.Exists(strPath) == true) //Если директория существует.
            {
                Directory.Delete(strPath, true); //Удаляем.
            }

            Directory.CreateDirectory(strPath); //Создаем заново чистую.

            if (Airline.Count > 0)
            {
                for (int int1 = 0; int1 <= Airline.Count - 1; int1++)
                {
                    strPath = $@"d:\Registry\Airline\{Convert.ToString(int1)}-Airline.txt";

                    File.WriteAllText(strPath, Airline[int1].strName); //Название авиакомпании.

                    if (Airline[int1].Airplane.Count > 0)
                    {
                        strPath = $@"d:\Registry\Airline\{Convert.ToString(int1)}-Airplane.txt";

                        for (int int2 = 0; int2 <= Airline[int1].Airplane.Count - 1; int2++)
                        {
                            if (File.Exists(strPath) == true) //Если файл существует.
                            {
                                File.AppendAllText(strPath, "\n" + Airline[int1].Airplane[int2].strName); //Название самолета (тип).
                                File.AppendAllText(strPath, "\n" + Convert.ToString(Airline[int1].Airplane[int2].intPassengerCapacity)); //Вместимость пассажиров (количество посадочных мест).
                                File.AppendAllText(strPath, "\n" + Convert.ToString(Airline[int1].Airplane[int2].dblCargoCapacity)); //Вместимость груза (кг).
                                File.AppendAllText(strPath, "\n" + Convert.ToString(Airline[int1].Airplane[int2].dblFlightRange)); //Дальность полета (км).
                                File.AppendAllText(strPath, "\n" + Convert.ToString(Airline[int1].Airplane[int2].dblFuelConsumption)); //Количество потребляемого топлива (л).
                            }
                            else
                            {
                                File.AppendAllText(strPath, Airline[int1].Airplane[int2].strName); //Название самолета (тип).
                                File.AppendAllText(strPath, "\n" + Convert.ToString(Airline[int1].Airplane[int2].intPassengerCapacity)); //Вместимость пассажиров (количество посадочных мест).
                                File.AppendAllText(strPath, "\n" + Convert.ToString(Airline[int1].Airplane[int2].dblCargoCapacity)); //Вместимость груза (кг).
                                File.AppendAllText(strPath, "\n" + Convert.ToString(Airline[int1].Airplane[int2].dblFlightRange)); //Дальность полета (км).
                                File.AppendAllText(strPath, "\n" + Convert.ToString(Airline[int1].Airplane[int2].dblFuelConsumption)); //Количество потребляемого топлива (л).
                            }
                        }
                    }
                }
            }
        }


        //Метод расчета общих значений параметров.
        public static void F_voiParameterAnalysisTotal(int intAirlineNumber, List<claAirline> Airline, int intParameterNumber)
        {
            double dblResult = 0;

            for(int int1=0; int1 <= Airline[intAirlineNumber].Airplane.Count-1; int1++)
            {
                if(intParameterNumber == 1)
                {
                    dblResult = dblResult + Airline[intAirlineNumber].Airplane[int1].intPassengerCapacity;
                }
                else if (intParameterNumber == 2)
                {
                    dblResult = dblResult + Airline[intAirlineNumber].Airplane[int1].dblCargoCapacity;
                }
                else if (intParameterNumber == 3)
                {
                    dblResult = dblResult + Airline[intAirlineNumber].Airplane[int1].dblFlightRange;
                }
                else if (intParameterNumber == 4)
                {
                    dblResult = dblResult + Airline[intAirlineNumber].Airplane[int1].dblFuelConsumption;
                }
            }

            if (intParameterNumber == 1)
            {
                Console.WriteLine();
                Console.WriteLine($"Общая вместимость пассажиров: {dblResult}");
            }
            else if (intParameterNumber == 2)
            {
                Console.WriteLine();
                Console.WriteLine($"Общая грузоподъемность: {dblResult}");
            }
            else if (intParameterNumber == 3)
            {
                Console.WriteLine();
                Console.WriteLine($"Общая дальность полета: {dblResult}");
            }
            else if (intParameterNumber == 4)
            {
                Console.WriteLine();
                Console.WriteLine($"Общее количество потребляемого топлива: {dblResult}");
            }

            Console.WriteLine();
            Console.WriteLine("Для продолжения нажмите Enter.");
            string? strPause = Console.ReadLine();
        }


        //Метод расчета средних значений параметров.
        public static void F_voiParameterAnalysisAverage(int intAirlineNumber, List<claAirline> Airline, int intParameterNumber)
        {
            double dblResult = 0;

            for (int int1 = 0; int1 <= Airline[intAirlineNumber].Airplane.Count - 1; int1++)
            {
                if (intParameterNumber == 1)
                {
                    dblResult = dblResult + Airline[intAirlineNumber].Airplane[int1].intPassengerCapacity;
                }
                else if (intParameterNumber == 2)
                {
                    dblResult = dblResult + Airline[intAirlineNumber].Airplane[int1].dblCargoCapacity;
                }
                else if (intParameterNumber == 3)
                {
                    dblResult = dblResult + Airline[intAirlineNumber].Airplane[int1].dblFlightRange;
                }
                else if (intParameterNumber == 4)
                {
                    dblResult = dblResult + Airline[intAirlineNumber].Airplane[int1].dblFuelConsumption;
                }
            }

            if (intParameterNumber == 1)
            {
                Console.WriteLine();
                Console.WriteLine($"Средняя вместимость пассажиров: {dblResult / Airline[intAirlineNumber].Airplane.Count}");
            }
            else if (intParameterNumber == 2)
            {
                Console.WriteLine();
                Console.WriteLine($"Средняя грузоподъемность: {dblResult / Airline[intAirlineNumber].Airplane.Count}");
            }
            else if (intParameterNumber == 3)
            {
                Console.WriteLine();
                Console.WriteLine($"Средняя дальность полета: {dblResult / Airline[intAirlineNumber].Airplane.Count}");
            }
            else if (intParameterNumber == 4)
            {
                Console.WriteLine();
                Console.WriteLine($"Среднее количество потребляемого топлива: {dblResult / Airline[intAirlineNumber].Airplane.Count}");
            }

            Console.WriteLine();
            Console.WriteLine("Для продолжения нажмите Enter.");
            string? strPause = Console.ReadLine();
        }


        //Метод сортировки.
        public static void F_dblParameterAnalysisSorting(int intAirlineNumber, List<claAirline> Airline, int intParameterNumber)
        {
            if (intParameterNumber == 1)
            {
                var varSorting = Airline[intAirlineNumber].Airplane.OrderBy(x => x.intPassengerCapacity).ToList();

                Console.WriteLine();
                Console.WriteLine("Результат сортировки по вместимости пассажиров.");
                Console.WriteLine();
                Console.WriteLine("Авиакомпания:");
                Console.WriteLine(Airline[intAirlineNumber].strName);
                Console.WriteLine($"          Воздушное судно:");

                for (int int2 = 0; int2 <= varSorting.Count - 1; int2++)
                {
                    Console.WriteLine($"          {varSorting[int2].strName}");
                    Console.WriteLine($"                    Параметры:");
                    Console.WriteLine($"                    Вместимость пассажиров: {varSorting[int2].intPassengerCapacity}");
                    Console.WriteLine($"                    Вместимость груза (кг): {varSorting[int2].dblCargoCapacity}");
                    Console.WriteLine($"                    Дальность полета (км): {varSorting[int2].dblFlightRange}");
                    Console.WriteLine($"                    Количество потребляемого топлива (л): {varSorting[int2].dblFuelConsumption}");
                }
            }
            else if (intParameterNumber == 2)
            {
                var varSorting = Airline[intAirlineNumber].Airplane.OrderBy(x => x.dblCargoCapacity).ToList();

                Console.WriteLine();
                Console.WriteLine("Результат сортировки по грузоподъемности.");
                Console.WriteLine();
                Console.WriteLine("Авиакомпания:");
                Console.WriteLine(Airline[intAirlineNumber].strName);
                Console.WriteLine($"          Воздушное судно:");

                for (int int2 = 0; int2 <= varSorting.Count - 1; int2++)
                {
                    Console.WriteLine($"          {varSorting[int2].strName}");
                    Console.WriteLine($"                    Параметры:");
                    Console.WriteLine($"                    Вместимость пассажиров: {varSorting[int2].intPassengerCapacity}");
                    Console.WriteLine($"                    Вместимость груза (кг): {varSorting[int2].dblCargoCapacity}");
                    Console.WriteLine($"                    Дальность полета (км): {varSorting[int2].dblFlightRange}");
                    Console.WriteLine($"                    Количество потребляемого топлива (л): {varSorting[int2].dblFuelConsumption}");
                }
            }
            else if (intParameterNumber == 3)
            {
                var varSorting = Airline[intAirlineNumber].Airplane.OrderBy(x => x.dblFlightRange).ToList();

                Console.WriteLine();
                Console.WriteLine("Результат сортировки по дальности полета.");
                Console.WriteLine();
                Console.WriteLine("Авиакомпания:");
                Console.WriteLine(Airline[intAirlineNumber].strName);
                Console.WriteLine($"          Воздушное судно:");

                for (int int2 = 0; int2 <= varSorting.Count - 1; int2++)
                {
                    Console.WriteLine($"          {varSorting[int2].strName}");
                    Console.WriteLine($"                    Параметры:");
                    Console.WriteLine($"                    Вместимость пассажиров: {varSorting[int2].intPassengerCapacity}");
                    Console.WriteLine($"                    Вместимость груза (кг): {varSorting[int2].dblCargoCapacity}");
                    Console.WriteLine($"                    Дальность полета (км): {varSorting[int2].dblFlightRange}");
                    Console.WriteLine($"                    Количество потребляемого топлива (л): {varSorting[int2].dblFuelConsumption}");
                }
            }
            else if (intParameterNumber == 4)
            {
                var varSorting = Airline[intAirlineNumber].Airplane.OrderBy(x => x.dblFuelConsumption).ToList();

                Console.WriteLine();
                Console.WriteLine("Результат сортировки по количеству потребляемого топлива.");
                Console.WriteLine();
                Console.WriteLine("Авиакомпания:");
                Console.WriteLine(Airline[intAirlineNumber].strName);
                Console.WriteLine($"          Воздушное судно:");

                for (int int2 = 0; int2 <= varSorting.Count - 1; int2++)
                {
                    Console.WriteLine($"          {varSorting[int2].strName}");
                    Console.WriteLine($"                    Параметры:");
                    Console.WriteLine($"                    Вместимость пассажиров: {varSorting[int2].intPassengerCapacity}");
                    Console.WriteLine($"                    Вместимость груза (кг): {varSorting[int2].dblCargoCapacity}");
                    Console.WriteLine($"                    Дальность полета (км): {varSorting[int2].dblFlightRange}");
                    Console.WriteLine($"                    Количество потребляемого топлива (л): {varSorting[int2].dblFuelConsumption}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Для продолжения нажмите Enter.");
            string? strPause = Console.ReadLine();
        }


        //Метод запроса.
        public static void F_dblParameterAnalysisRequest(int intAirlineNumber, List<claAirline> Airline, int intParameterNumber)
        {
            int intMin;
            int intMax;
            
            double dblMin;
            double dblMax;

            bool booErrorControl; //Контроль ошибок.

            if (intParameterNumber == 1)
            {
                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Введите минимальное значение вместимости пассажиров:");
                    booErrorControl = Int32.TryParse(Console.ReadLine(), out intMin);
                    if (booErrorControl == true)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Вы ввели не корректные данные! Повторите попытку.");
                        continue;
                    }
                }

                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Введите максимальное значение вместимости пассажиров:");
                    booErrorControl = Int32.TryParse(Console.ReadLine(), out intMax);
                    if (booErrorControl == true)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Вы ввели не корректные данные! Повторите попытку.");
                        continue;
                    }
                }

                var varRequest = Airline[intAirlineNumber].Airplane.Where(x => x.intPassengerCapacity >= intMin && x.intPassengerCapacity <= intMax).ToList();

                Console.WriteLine();
                Console.WriteLine("Результат запроса на диапазон вместимости пассажиров.");
                Console.WriteLine();
                Console.WriteLine("Авиакомпания:");
                Console.WriteLine(Airline[intAirlineNumber].strName);
                Console.WriteLine($"          Воздушное судно:");

                for (int int2 = 0; int2 <= varRequest.Count - 1; int2++)
                {
                    Console.WriteLine($"          {varRequest[int2].strName}");
                    Console.WriteLine($"                    Параметры:");
                    Console.WriteLine($"                    Вместимость пассажиров: {varRequest[int2].intPassengerCapacity}");
                    Console.WriteLine($"                    Вместимость груза (кг): {varRequest[int2].dblCargoCapacity}");
                    Console.WriteLine($"                    Дальность полета (км): {varRequest[int2].dblFlightRange}");
                    Console.WriteLine($"                    Количество потребляемого топлива (л): {varRequest[int2].dblFuelConsumption}");
                }
            }
            else if (intParameterNumber == 2)
            {
                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Введите минимальное значение грузоподъемности (кг):");
                    booErrorControl = double.TryParse(Console.ReadLine(), out dblMin);
                    if (booErrorControl == true)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Вы ввели не корректные данные! Повторите попытку.");
                        continue;
                    }
                }

                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Введите максимальное значение грузоподъемности (кг):");
                    booErrorControl = double.TryParse(Console.ReadLine(), out dblMax);
                    if (booErrorControl == true)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Вы ввели не корректные данные! Повторите попытку.");
                        continue;
                    }
                }

                var varRequest = Airline[intAirlineNumber].Airplane.Where(x => x.dblCargoCapacity >= dblMin && x.dblCargoCapacity <= dblMax).ToList();

                Console.WriteLine();
                Console.WriteLine("Результат запроса на диапазон грузоподъемности.");
                Console.WriteLine();
                Console.WriteLine("Авиакомпания:");
                Console.WriteLine(Airline[intAirlineNumber].strName);
                Console.WriteLine($"          Воздушное судно:");

                for (int int2 = 0; int2 <= varRequest.Count - 1; int2++)
                {
                    Console.WriteLine($"          {varRequest[int2].strName}");
                    Console.WriteLine($"                    Параметры:");
                    Console.WriteLine($"                    Вместимость пассажиров: {varRequest[int2].intPassengerCapacity}");
                    Console.WriteLine($"                    Вместимость груза (кг): {varRequest[int2].dblCargoCapacity}");
                    Console.WriteLine($"                    Дальность полета (км): {varRequest[int2].dblFlightRange}");
                    Console.WriteLine($"                    Количество потребляемого топлива (л): {varRequest[int2].dblFuelConsumption}");
                }
            }
            else if (intParameterNumber == 3)
            {
                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Введите минимальное значение дальности полета (км):");
                    booErrorControl = double.TryParse(Console.ReadLine(), out dblMin);
                    if (booErrorControl == true)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Вы ввели не корректные данные! Повторите попытку.");
                        continue;
                    }
                }

                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Введите максимальное значение дальности полета (км):");
                    booErrorControl = double.TryParse(Console.ReadLine(), out dblMax);
                    if (booErrorControl == true)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Вы ввели не корректные данные! Повторите попытку.");
                        continue;
                    }
                }

                var varRequest = Airline[intAirlineNumber].Airplane.Where(x => x.dblFlightRange >= dblMin && x.dblFlightRange <= dblMax).ToList();

                Console.WriteLine();
                Console.WriteLine("Результат запроса на диапазон дальности полета.");
                Console.WriteLine();
                Console.WriteLine("Авиакомпания:");
                Console.WriteLine(Airline[intAirlineNumber].strName);
                Console.WriteLine($"          Воздушное судно:");

                for (int int2 = 0; int2 <= varRequest.Count - 1; int2++)
                {
                    Console.WriteLine($"          {varRequest[int2].strName}");
                    Console.WriteLine($"                    Параметры:");
                    Console.WriteLine($"                    Вместимость пассажиров: {varRequest[int2].intPassengerCapacity}");
                    Console.WriteLine($"                    Вместимость груза (кг): {varRequest[int2].dblCargoCapacity}");
                    Console.WriteLine($"                    Дальность полета (км): {varRequest[int2].dblFlightRange}");
                    Console.WriteLine($"                    Количество потребляемого топлива (л): {varRequest[int2].dblFuelConsumption}");
                }
            }
            else if (intParameterNumber == 4)
            {
                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Введите минимальное значение количества потребляемого топлива (л):");
                    booErrorControl = double.TryParse(Console.ReadLine(), out dblMin);
                    if (booErrorControl == true)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Вы ввели не корректные данные! Повторите попытку.");
                        continue;
                    }
                }

                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Введите максимальное значение количества потребляемого топлива(л):");
                    booErrorControl = double.TryParse(Console.ReadLine(), out dblMax);
                    if (booErrorControl == true)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Вы ввели не корректные данные! Повторите попытку.");
                        continue;
                    }
                }

                var varRequest = Airline[intAirlineNumber].Airplane.Where(x => x.dblFuelConsumption >= dblMin && x.dblFuelConsumption <= dblMax).ToList();

                Console.WriteLine();
                Console.WriteLine("Результат запроса на диапазон количества потребляемого топлива.");
                Console.WriteLine();
                Console.WriteLine("Авиакомпания:");
                Console.WriteLine(Airline[intAirlineNumber].strName);
                Console.WriteLine($"          Воздушное судно:");

                for (int int2 = 0; int2 <= varRequest.Count - 1; int2++)
                {
                    Console.WriteLine($"          {varRequest[int2].strName}");
                    Console.WriteLine($"                    Параметры:");
                    Console.WriteLine($"                    Вместимость пассажиров: {varRequest[int2].intPassengerCapacity}");
                    Console.WriteLine($"                    Вместимость груза (кг): {varRequest[int2].dblCargoCapacity}");
                    Console.WriteLine($"                    Дальность полета (км): {varRequest[int2].dblFlightRange}");
                    Console.WriteLine($"                    Количество потребляемого топлива (л): {varRequest[int2].dblFuelConsumption}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Для продолжения нажмите Enter.");
            string? strPause = Console.ReadLine();
        }
    }
}
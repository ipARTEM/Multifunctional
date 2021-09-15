using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Сalculator5
{
    class Program
    {


        static async Task Main(string[] args)
        {
            Features f = new Features();

          
            if(!File.Exists("appsettings.json"))
            {
                using (FileStream fs = new FileStream("appsettings.json", FileMode.OpenOrCreate))
                {
                    //Features fSave = new Features();


                    await JsonSerializer.SerializeAsync<Features>(fs, f);
                    Console.WriteLine("Создан файл appsettings.json");
                }
            }



            //// чтение данных
            using (FileStream fs = new FileStream("appsettings.json", FileMode.OpenOrCreate))
            {
                try
                {

                    Features fRead = await JsonSerializer.DeserializeAsync<Features>(fs);
                    Console.WriteLine("  Последняя запись:");
                    Console.WriteLine($"  {fRead.LeftArg}{fRead.Action}{fRead.RightArg} = {fRead.Output}");
                }
                catch (Exception)
                {
                    await JsonSerializer.SerializeAsync<Features>(fs, f);
                    throw;
                }
            }





            //double a;   f.LeftArg
            //double b;   f.RightArg

            //double output = 0; f.Output

            do
            {
                Console.WriteLine("Выберите действие:\n1.Сложение\n2.Вычитание\n3.Умножение\n4.Деление\n5.Возведение в степень" +
                    "\n6.Корень из \n7.Выход");


                int action;
                try
                {
                    action = Convert.ToInt32(Console.ReadLine());

                }
                catch (Exception)
                {
                    continue;
                }

                if (action == 7)
                    break;
                if (action != 1 && action != 2 && action != 3 && action != 4 && action != 5 && action != 6)
                    continue;

                do
                {
                    try
                    {
                        if (action == 5)
                        {
                            Console.WriteLine("Введите основание степени: ");
                            f.LeftArg = Convert.ToInt32(Console.ReadLine());
                            break;

                        }
                        else if (action == 6)
                        {
                            Console.WriteLine("Введите подкоренное выражение: ");
                            f.RightArg = Convert.ToInt32(Console.ReadLine());
                            break;

                        }

                        else
                        {
                            Console.WriteLine("Введите первое число: ");
                            f.LeftArg = Convert.ToInt32(Console.ReadLine());
                            break;
                        }


                    }
                    catch (Exception)
                    {
                        continue;
                    }


                } while (true);

                do
                {
                    try
                    {
                        if (action == 5)
                        {
                            Console.WriteLine("Введите показатель степени: ");
                            f.RightArg = Convert.ToInt32(Console.ReadLine());
                            break;

                        }
                        else if (action == 6)
                        {
                            Console.WriteLine("Введите показатель корня: ");
                            f.LeftArg = Convert.ToInt32(Console.ReadLine());
                            break;

                        }

                        else
                        {
                            Console.WriteLine("Введите второе число: ");
                            f.RightArg = Convert.ToInt32(Console.ReadLine());
                            break;
                        }
                    }
                    catch (Exception)
                    {

                        continue;
                    }


                } while (true);

                switch (action)
                {
                    case 1:
                        f.Output = Add(f.LeftArg, f.RightArg);
                        f.Action = "+";
                        break;
                    case 2:
                        f.Output = Sub(f.LeftArg, f.RightArg);
                        f.Action = "-";
                        break;
                    case 3:
                        f.Output = Mult(f.LeftArg, f.RightArg);
                        f.Action = "*";
                        break;
                    case 4:
                        f.Output = Divide(f.LeftArg, f.RightArg);
                        f.Action = "/";
                        break;
                    case 5:
                        f.Output = Exponentiation(f.LeftArg, f.RightArg);
                        f.Action = "^";
                        break;
                    case 6:
                        f.Output = RootOf(f.RightArg, f.LeftArg);
                        f.Action = "√";
                        break;
                }
                Console.WriteLine("\n"+" "+ f.LeftArg + f.Action + f.RightArg + " = " + f.Output);
                Console.WriteLine();


            } while (true);

            double Add(double a, double b)
            {
                return a + b;
            }

            double Sub(double a, double b)
            {
                return a - b;
            }

            double Mult(double a, double b)
            {
                return a * b;
            }

            double Divide(double a, double b)
            {
                return a / b;
            }

            double Exponentiation(double a, double b)
            {
                return Math.Pow(a, b);
            }

            double RootOf(double a, double b)
            {
                return Math.Pow(a, 1 / b);
            }

            // сохранение данных
            using (FileStream fs = new FileStream("appsettings.json", FileMode.OpenOrCreate))
            {
                //Features fSave = new Features();


                await JsonSerializer.SerializeAsync<Features>(fs, f);
                Console.WriteLine("Данные сохранены в файл");
            }
        }


    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using System;

namespace Сalculator4
{
    class Program
    {
        static void Main(string[] args)
        {
            SettingsJson();




            double a;
            double b;

            double output = 0;

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
                            a = Convert.ToInt32(Console.ReadLine());
                            break;

                        }
                        else if (action == 6)
                        {
                            Console.WriteLine("Введите подкоренное выражение: ");
                            a = Convert.ToInt32(Console.ReadLine());
                            break;

                        }

                        else
                        {
                            Console.WriteLine("Введите первое число: ");
                            a = Convert.ToInt32(Console.ReadLine());
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
                            b = Convert.ToInt32(Console.ReadLine());
                            break;

                        }
                        else if (action == 6)
                        {
                            Console.WriteLine("Введите показатель корня: ");
                            b = Convert.ToInt32(Console.ReadLine());
                            break;

                        }

                        else
                        {
                            Console.WriteLine("Введите второе число: ");
                            b = Convert.ToInt32(Console.ReadLine());
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
                        output = Add(a, b);
                        break;
                    case 2:
                        output = Sub(a, b);
                        break;
                    case 3:
                        output = Mult(a, b);
                        break;
                    case 4:
                        output = Divide(a, b);
                        break;
                    case 5:
                        output = Exponentiation(a, b);
                        break;
                    case 6:
                        output = RootOf(a, b);
                        break;
                }
                Console.WriteLine("\nРезультат: " + output);
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

        }

        static void SettingsJson()
        {
            var configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", false, true)
               .Build();

            var settings = configuration.Get<Settings>();

            var services = new ServiceCollection() as IServiceCollection;

            services.AddLogging(configure =>
            {
                configure.AddConfiguration(configuration.GetSection("Logging"));
                configure.AddConsole();
            });

            var serviceProvider = services.BuildServiceProvider();

            var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
            logger.LogDebug("Settings:{Settings}", settings);


            serviceProvider.Dispose();
        }
    }
}

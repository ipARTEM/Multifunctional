using System;

namespace Multifunctional
{
    class Program
    {
        static void Main(string[] args)
        {  
            double a;
            double b;

            double output = 0;

            do
            {
                Console.WriteLine("Выберите действие:\n1.Сложение\n2.Вычитание\n3.Умножение\n4.Деление\n5.Выход");


                int action;
                try
                {
                 action = Convert.ToInt32(Console.ReadLine());

                }
                catch (Exception)
                {
                    continue;
                }

                if (action == 5)
                    break;
                if (action != 1 && action != 2 && action != 3 && action != 4)
                    continue;

                do
                {
                    try
                    {
                        Console.WriteLine("Введите первое число: ");
                        a = Convert.ToInt32(Console.ReadLine());
                        break;
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
                        Console.WriteLine("Введите второе число: ");
                        b = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch (Exception)
                    {

                        continue;
                    }


                } while (true);

                switch (action)
                {
                    case 1:
                        output = a + b;
                        break;
                    case 2:
                        output = a - b;
                        break;
                    case 3:
                        output = a * b;
                        break;
                    case 4:
                        output = a / b;
                        break;
                }
                Console.WriteLine("\nРезультат: "+output);
                Console.WriteLine();


            } while (true);
                
             
        }

        
    }

    
}

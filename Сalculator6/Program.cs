using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Сalculator6
{
    public enum DegreesMode
    {
        Degrees,
        Radians
    }

    public delegate double FunctionDelegate(IEvaluationContext context, params double[] args);

    class Program
    {
        static async Task Main(string[] args)
        {
            Features f = new Features();

            if (!File.Exists("appsettings.json"))
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
                    Console.WriteLine($"  {fRead.Action}");
                }
                catch (Exception)
                {
                    await JsonSerializer.SerializeAsync<Features>(fs, f);

                }
            }

            var context = new EvaluationContext();
            var calculator = new RPNCalculator(context);
            var tokenizer = new Tokenizer();
            var parser = new Parser(calculator);

            Console.WriteLine("Доступные символы: ");
            Console.WriteLine("+ - * / ^ % ** | & << >> ~ ( )  pi e");
            Console.WriteLine("Для выхода нажмите 'Q' и 'Enter'");

            do
            {
                Console.Write("►►");
                var input = Console.ReadLine();
                if (input.ToLowerInvariant() == "q")
                    break;

                if (string.IsNullOrWhiteSpace(input))
                    continue;
                                                     
                
                try
                {
                    var result = parser.Parse(tokenizer.Tokenize(input).ToArray());
                    Console.WriteLine(result);
                    context.SetVariableValue("ans", result);
                    f.Action = $" {input} = {result}";
                    using (FileStream fs = new FileStream("appsettings.json", FileMode.OpenOrCreate))
                    {
                        await JsonSerializer.SerializeAsync<Features>(fs, f);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine();

            } while (true);


            
        }

        
    }
}

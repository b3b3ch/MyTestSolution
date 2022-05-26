/*  
    Create Console app in .net framework or.net core.
    • The app should support two arguments.
    • The app should have extension method that adds one argument to another
    • The app should display the result.
    • The app should have a few unit tests for this extension method.
    • The app should save result in a database of your choice. 
*/
using MySolution.Common.Extensions;
using MySolution.DAL;
using MySolution.Model;

namespace MySolution.ConsoleApp
{
    internal class Program
    {

        static void Main(string[] args)
        {
#if DEBUG
            args = new string[] { "2", "2" }; // should write 4
            //args = new string[] { "x", "2" }; // should write the first argument is invalid 
            //args = new string[] { "2", "x" }; // should write the second argument is invalid 
#endif

            if (!ValidateArguments(args, out string validationResult))
            {
                Console.WriteLine(validationResult);
                return;
            }
            
            var argumentsAsIntegers = new int[] { int.Parse(args[0]), int.Parse(args[1]) };
            var sumOfArguments = argumentsAsIntegers.SumArguments();

            Console.WriteLine($"The sum of arguments equals {sumOfArguments}");
            
            SimpleDAL simpleDal = new SimpleDAL();
            simpleDal.SaveArgumentsSumResult(new ArgumentsSumResult { ArgumentFirst = argumentsAsIntegers[0], ArgumentSecond = argumentsAsIntegers[1], Sum = sumOfArguments });
            Console.WriteLine($"The result was saved to database.");

            Console.ReadKey();
        }

        private static bool ValidateArguments(string[] args, out string validationResult)
        {
            validationResult = string.Empty;

            if(args.Length != 2)
            {
                validationResult = "Please provide two integer arguments!";
                return false;
            }

            if (args.Length == 2)
            {
                if (!int.TryParse(args[0], out _))
                {
                    validationResult = "The first argument is not an integer argument!";
                    return false;
                }

                if (!int.TryParse(args[1], out _))
                {
                    validationResult = "The second argument is not an integer argument!";
                    return false;
                }
            }
                
            return true;
        }
    }
}
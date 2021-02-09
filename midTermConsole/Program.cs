using System;

namespace midTermConsole
{
    class Program
    {

        private static string _outputType;
        private static string _query;

        static void Main()
        {
            string[] args = Environment.GetCommandLineArgs();
            AreArgumentsValid(args);

            var allBooks = MidTerm.BookStoreFunctions.GetAllBooks();
            var byTitle = MidTerm.BookStoreFunctions.GetBookBytitle(args[3]);
            var byAuthorLast = MidTerm.BookStoreFunctions.GetAllBooksByAuthorLast(args[3]);

            var oh = new OutputHelper();
            
            switch (_outputType)
            {
                case "console":
                    if (_query == "allbooks") { oh.WriteToConsole(allBooks); }
                    if (_query == "bytitle") { oh.WriteToConsole(byTitle); }
                    if (_query == "byauthor") { oh.WriteToConsole(byAuthorLast); }
                    break;

                case "csv":
                    if (_query == "allbooks") { oh.WriteToCSV(allBooks); }
                    if (_query == "bytitle") { oh.WriteToCSV(byTitle); }
                    if (_query == "byauthor") { oh.WriteToCSV(byAuthorLast); }
                    break;

                default:
                    Console.WriteLine($"{_outputType} is not a valid output type. Only con or csv.");
                    break;
            }
        }

        private static void AreArgumentsValid(string[] args)
        {
            _outputType = args[1].ToLower();
            _query = args[2].ToLower();
            

            var oType = "console csv";
            var queries = "allbooks bytitle byauthor";

            if (oType.Contains(_outputType) && queries.Contains(_query))
            {
              
                Console.WriteLine("All arguments are valid");
            }

            else
            {
                Console.WriteLine("Not all arguments are valid");
            }
        }
    }
    
}

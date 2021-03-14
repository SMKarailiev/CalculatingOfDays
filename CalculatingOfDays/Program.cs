using System;
using System.IO;

namespace CalculatingOfDays
{
    class Program
    {
        // This is the main method, which is the entry point of the application.
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Write an absolute path to a text file such as: 'E:\\Programs\\file.txt'           \n=> ");
                string testFileName = Console.ReadLine();
                if (testFileName == null || !File.Exists(testFileName))
                {
                    Console.WriteLine("File Not Found.");
                    Console.ReadLine();
                }
                var variable = new CalculateDays(Path.Combine(Environment.CurrentDirectory, testFileName));
                variable.CalculateTimeSpan();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
                Console.ReadLine();
            }
        }
    }
}

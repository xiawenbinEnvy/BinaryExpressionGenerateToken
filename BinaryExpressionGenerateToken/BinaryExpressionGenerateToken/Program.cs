using System;
using Core;

namespace BinaryExpressionGenerateToken
{
    class Program
    {
        static void Main(string[] args)
        {
            var puzzle = FactoryPuzzle.CreatePuzzle("Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.101 Safari/537.36");
            Console.WriteLine(puzzle.StringSendToFrantEnd);
            Console.WriteLine(puzzle.GetResult());

            Console.ReadLine();
        }
    }
}

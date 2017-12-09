using InteractiveSort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleUi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("left: arg1 first, down: both equal, right: arg2 first");
            var session = SortingSession<object>.CreateSession(Algorithm.BuiltinListSort, (object arg1, object arg2) =>
            {
                Console.Write(arg1 + " <==> " + arg2 + ": ");
                var task = new Task<int>(() =>
                {
                    int result = -2;
                    while(result < -1)
                    {
                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.LeftArrow:
                                result = -1;
                                break;
                            case ConsoleKey.DownArrow:
                                result = 0;
                                break;
                            case ConsoleKey.RightArrow:
                                result = 1;
                                break;
                        }
                    }
                    Console.WriteLine();
                    return result;
                });
                task.Start();
                return task;
            }, new string[] { "c#", "c++", "c", ".net", "html", "js", "css", "php", "java", "vb", "python", "haskell", "minizinc", "reactivex", "ruby on rails", "angular", "react" });
            session.Sort().Wait();

            Console.WriteLine(string.Join(",", session.Items));
            Console.WriteLine("Press any button to exit...");
            Console.ReadKey();
        }
    }
}

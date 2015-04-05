using System;
using System.Collections.Generic;
using System.Linq;

namespace Aliencube.AppUtilities.ConsoleApp
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Run(args.ToList());
        }

        private static void Run(IList<string> args)
        {
            if (args == null || !args.Any())
            {
                throw new ArgumentNullException("args");
            }

            if (args.Count() > 1)
            {
                throw new ArgumentException("Too many arguments");
            }

            using (var appUtil = new AppUtility())
            {
                try
                {
                    var fullpath = appUtil.MapPath(args.First());
                    Console.WriteLine("{0} => {1}", args.First(), fullpath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0} => FAIL!!: {1}", args.First(), ex.Message);
                }
            }
        }
    }
}
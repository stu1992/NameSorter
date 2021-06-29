using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            // I want to make sure there is an arguement
            if (args.Length >= 1)
            {
                // read list of names
                ListPersonInput factory = new ListPersonInput();
                factory.populateFromFile(args[0]);
                // print out sorted list to console and file
                ListFileOutput filePrinter = new ListFileOutput(factory.GetList(), "sorted-names-list.txt");
                ListConsoleOutput consolePrinter = new ListConsoleOutput(factory.GetList());
                consolePrinter.print();
                filePrinter.print();
            }
            else
            {
                Console.WriteLine("please give a file to load as an arguement");
            }
        }
    }

}

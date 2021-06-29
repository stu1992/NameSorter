using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class ListConsoleOutput : Print
    {
        private string outputFile;
        private List<ConsoleApp2.Person> list;
        public ListConsoleOutput(List<ConsoleApp2.Person> list)
        {
            this.list = list;
        }

        public void print()
        {
            foreach (Person person in list)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }

}

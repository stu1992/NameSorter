using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    interface Print
    {
        public void print();
    }
    public class ListFileOutput : Print
    {
        private string outputFile;
        private List<ConsoleApp2.Person> list;
        public ListFileOutput(List<ConsoleApp2.Person> list, string outputFile)
        {
            this.list = list;
            this.outputFile = outputFile;
        }

        public void print()
        {
            System.IO.StreamWriter writer;
            writer = new System.IO.StreamWriter(this.outputFile);
            foreach (Person person in list)
            {
                writer.WriteLine(person.ToString());
            }
            writer.Close();
        }
    }

}

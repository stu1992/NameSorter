using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp2;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsoleApp2.Tests
{
    [TestClass()]
    public class FileIOTests
    {
        // creating some commonly used values for unit tests
        const string goodOrder = "Marin Alvarez\nAdonis Julius Archer\nBeau Tristan Bentley\nHunter Uriah Mathew Clarke\nLeo Gardner\nVaughn Lewis\nLondon Lindsey\nMikayla Lopez\nJanet Parsons\nFrankie Conner Ritter\nShelby Nathan Yoder";
        const string badOrder = "Marin Alvarez\nAdonis Julius Archer\nBeau Tristan Bentley\nHunter Uriah Mathew Clarke\nLeo Gardner\nVaughn Lewis\nLondon Lindsey\nMikayla Lopez\nJanet Parsons\nFrankie Conner Ritter\nShelby Nathan Yoder";
        const string fileName = "input.txt";
        const string fileOutput = "sorted-names-list.txt";

        // this is a helper function to clean up testing. It checks the output file for result
        private string readFile()
        {
            string result = "";
            System.IO.StreamReader reader;
            try
            {
                reader = new System.IO.StreamReader(fileOutput);

                while (!reader.EndOfStream)
                {
                    if (result.Length > 0)
                    {
                        result = string.Concat(result, "\n");
                    }
                    result = string.Concat(result, reader.ReadLine());
                }
            }
            catch (Exception exception)
            {
                result = exception.Message;
            }
            return result;
        }
        // helper function to create list to test file reading
        private void createFile() 
        {
            System.IO.StreamWriter writer;
            writer = new System.IO.StreamWriter(fileName);
            writer.Write(badOrder);
            writer.Close();
        }

        // this is a helper function to clean up testing
        private void deleteOutputFile()
        {
            try
            {
                File.Delete(fileOutput);
            }
            catch (System.IO.FileNotFoundException)
            {
                // I don't care about this exception being thrown but I have the catch so future devs can see it coming
            }
        }

        [TestMethod()]
        public void testFileInput()
        {
            createFile();
            // testing that the file gets read, soring is automatic
            ConsoleApp2.ListPersonInput factory = new ConsoleApp2.ListPersonInput();
            factory.populateFromFile(fileName);
            Assert.IsTrue(Object.Equals(factory.GetAsString(), goodOrder));

        }
        [TestMethod()]
        public void testFileOutput()
        {
            // testing that the corrected order file gets writen

            // to test the file writing, I need to start from a blank directory so I'm deleting an old output file
            deleteOutputFile();

            // populate list and print to filesystem
            ConsoleApp2.ListPersonInput factory = new ConsoleApp2.ListPersonInput();
            factory.populateFromFile(fileName);
            ConsoleApp2.ListFileOutput printer = new ConsoleApp2.ListFileOutput(factory.GetList(), fileOutput);
            printer.print();
            // read back and confirm correct content
            Assert.IsTrue(Object.Equals(readFile(), goodOrder));
        }
    }
    [TestClass()]
    public class PersonSortingTests
    {
        [TestMethod()]
        public void testCustomListbasic()
        {
            // testing 2 basic names
            List<Person> people = new List<Person>();
            Person p1 = new Person("Stu", "Smith");
            Person p2 = new Person("Aaron", "Anderson");
            people.Add(p1);
            people.Add(p2);
            Assert.IsTrue(people.IndexOf(p2) == 1);
            people.Sort();
            Assert.IsTrue(people.IndexOf(p2) == 0);
        }
        [TestMethod()]
        public void testCustomListSameSecond()
        {

            // testing 2 names with same second name
            List<Person> people = new List<Person>();
            Person p1 = new Person("Stu", "Smith");
            Person p2 = new Person("Aaron", "Smith");
            people.Add(p1);
            people.Add(p2);
            Assert.IsTrue(people.IndexOf(p1) == 0);
            people.Sort();
            Assert.IsTrue(people.IndexOf(p1) == 1);
        }
        [TestMethod()]
        public void testCustomListThird()
        {
            // testing 2 names with a middle name
            List<Person> people = new List<Person>();
            Person p1 = new Person("Aaron", "Steve", "Smith");
            Person p2 = new Person("Aaron", "James", "Smith");
            people.Add(p1);
            people.Add(p2);
            Assert.IsTrue(people.IndexOf(p1) == 0);
            people.Sort();
            Assert.IsTrue(people.IndexOf(p1) == 1);
            people.Clear();
        }
    }
}
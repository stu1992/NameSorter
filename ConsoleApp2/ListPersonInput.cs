using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    interface PopulateList
    {
        public void populateFromFile(string filePath);
        public string GetAsString();
    }
    public class ListPersonInput: PopulateList
    {
        // This break the might dependency inversion principal but I don't think it's valuable with this solution to abstract the Person class and make this a more generic factory
        private List<Person> People;

        public ListPersonInput()
        {
            People = new List<Person>();
        }

        // populate list from external file
        public void populateFromFile(string filePath)
        {
            System.IO.StreamReader reader = new System.IO.StreamReader(filePath);
            while (!reader.EndOfStream)
            {
                // splitting line into seperate names using space as delemination
                string names = reader.ReadLine();
                string[] parts = names.Split(" ");
                // I have seperate constructors based on the length of the name. I'm not sure if finding a way to use fewer brackets would make this easier for another dev to work on it
                if (parts.Length == 2)
                {
                    this.People.Add(new Person(parts[0], parts[1]));
                }
                else if (parts.Length == 3)
                {
                    this.People.Add(new Person(parts[0], parts[1], parts[2]));
                }
                else if (parts.Length == 4)
                {
                    // there can be up to 2 minddle names. This could be done in a cleaner way but I don't think the problem justifies it
                    this.People.Add(new Person(parts[0], parts[1] + " " + parts[2], parts[3]));
                }
            }
            // sort this list before returning control to outside application
            this.People.Sort();
        }
        // This isn't a required method but it makes life easier. I don't think it violates the single responcibility pricipal
        public string GetAsString()
        {
            this.People.Sort();
            string allNames = "";
            foreach (Person person in this.People)
            {
                if (allNames.Length > 0)
                {
                    allNames = string.Concat(allNames, "\n");
                }
                allNames = string.Concat(allNames, person.ToString());
            }
            return allNames;
        }

        public List<Person> GetList()
        {
            return this.People;
        }
    }
}
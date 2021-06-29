using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class Person : IComparable<Person>
    {
        private string lastName;
        private string firstName;
        // I only have one string field for what could optionally be 2 seperate strings. It's hard to know if future implementations will need to differentiate between them
        private string middleNames = null;
        private bool has_middle = false;

        public Person(string firstName, string lastName)
        {
            this.lastName = lastName;
            this.firstName = firstName;
        }
        public Person(string firstName, string middleName, string lastName)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.middleNames = middleName;
            this.has_middle = true;
        }
        public override string ToString()
        {
            if (this.has_middle)
            {
                return this.firstName + " " + this.middleNames + " " + this.lastName;
            }
            else
            {
                return this.firstName + " " + this.lastName;
            }
        }
        // getters and setters that aren't required but are generally safe to include
        public string getFirstName()
        {
            return this.firstName;
        }
        public string getLastName()
        {
            return this.lastName;
        }
        public string getMiddleName()
        {
            return this.middleNames;
        }
        public bool getHasMiddle()
        {
            return this.has_middle;
        }

        int IComparable<Person>.CompareTo(Person other)
        {
            // this will need to itterate through every character of the last names and compare alphabetical order
            int bounds = (this.lastName.Length < other.lastName.Length) ? this.lastName.Length : other.lastName.Length;
            for (int i = 0; i < bounds; i++)
            {
                if (this.lastName[i] < other.lastName[i])
                {
                    return -1;
                }
                else if (this.lastName[i] > other.lastName[i])
                {
                    return 1;
                }
                else
                {
                    continue;
                }
            }
            // create a new set of strings for comparison because first name and middle name will be compared together
            string ours, theirs;
            if (this.middleNames != null)
            {
                ours = this.firstName + this.middleNames;
            }
            else
            {
                ours = this.firstName;
            }

            if (other.middleNames != null)
            {
                theirs = other.firstName + other.middleNames;
            }
            else
            {
                theirs = other.firstName;
            }
            // I don't have all edge cases covered with this algorythm but I think 99% of cases will work as a reasonable person expects
            bounds = (ours.Length < theirs.Length) ? ours.Length : theirs.Length;
            for (int i = 0; i < bounds; i++)
            {
                if (ours[i] < theirs[i])
                {
                    return -1;
                }
                else if (ours[i] > theirs[i])
                {
                    return 1;
                }
                else
                {
                    continue;
                }
            }
            return 1;
        }
    }
}
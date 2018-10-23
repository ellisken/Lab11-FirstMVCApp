using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PersonOfTheYear.Models
{
    public class Person
    {
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Birth_Year { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }

        //Static method that returns a List of PersonOfTheYear objects.Takes two
        //parameters: startYear and endYear used for filtering the list of all people
        //to just those whose years fall within the desired range
        public static List<Person> GetPersons(int startYear, int endYear)
        {
            List<Person> people = new List<Person>(); //Create new List to store PersonOfTheYear objects
            string path = Environment.CurrentDirectory;//Sets path variable to current directory
            string newPath = Path.GetFullPath(Path.Combine(path, @"wwwroot\personOfTheYear.csv"));//Finds location of datafile and combines with initial path
            string[] myFile = File.ReadAllLines(newPath);//Reads in all lines of the data file and stores as a string array

            for (int i = 1; i < myFile.Length; i++)//For each string in the myFile array, skipping the top row (column names)
            {
                string[] fields = myFile[i].Split(',');//Separate the "fields" in the string by commas (since the file is CSV), stores in string array called "fields"
                people.Add(new Person //Instantiate a new PersonOfTheYear object
                {
                    Year = Convert.ToInt32(fields[0]), //Sets the year, converts string to int
                    Honor = fields[1], //Sets the person's honor
                    Name = fields[2], //Set Name equal to second field in "fields"
                    Country = fields[3], //Set Country equal to third field in "fields"
                    Birth_Year = (fields[4] == "") ? 0 : Convert.ToInt32(fields[4]),//Set birth year if it exists (converted to int), otherwise sets to 0
                    DeathYear = (fields[5] == "") ? 0 : Convert.ToInt32(fields[5]),//Set death year if it exists (converted to int), otherwise sets to 0
                    Title = fields[6], //Set Title to 6th field in "fields"
                    Category = fields[7], //Set category to 7th field in "fields"
                    Context = fields[8], //Set Context to 8th field in "fields"
                });
            }

            //Lambda function filters the listofPeople to be only people whose years fall between startYear and endYear, inclusive
            List<Person> listofPeople = people.Where(p => (p.Year >= startYear) && (p.Year <= endYear)).ToList();
            return listofPeople; //Return filtered list of people
        }
    }
}

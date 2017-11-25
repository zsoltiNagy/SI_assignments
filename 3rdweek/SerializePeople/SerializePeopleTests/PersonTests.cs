using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SerializePeople.Tests
{
    [TestClass()]
    public class PersonTests
    {
        private Person alfonz = new Person();
        private void Alfonz()
        {
            alfonz = new Person();
        }
        private List<Person> team;

        private void CreateTeam(int numberOFMembers)
        {
            team = new List<Person>();
            Person.PersonFactory(team, numberOFMembers);
        }

        [TestMethod()]
        public void PersonFactoryTest()
        {
            CreateTeam(10);
            Assert.IsTrue(team.Count() == 10);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PersonNeverHasBirthDaySoonerThan2000january1()
        {
            var norm = new DateTime(2000, 1, 1);
            CreateTeam(100);
            Boolean keepingTheNorm = true;
            foreach (Person person in team)
            {
                if (!((person.birthDate - norm).TotalDays >= 0))
                {
                    keepingTheNorm = false;
                    break;
                }
            }
            Assert.IsTrue(keepingTheNorm);
        }

        [TestMethod()]
        public void PersonNeverHasBirthDayLaterThanCurrentDate()
        {
            CreateTeam(100);
            Boolean keepingTheNorm = true;
            foreach (Person person in team)
            {
                if (!((DateTime.Now - person.birthDate).TotalDays < 0))
                {
                    keepingTheNorm = false;
                    break;
                };
            }
            Assert.IsTrue(keepingTheNorm);
        }


        [TestMethod()]
        public void AgeNeverBiggerThan2000ExtractedFromTheCurrentYear()
        {
            Assert.IsTrue(DateTime.Now.Year - 2000 >= alfonz.age);
        }

        [TestMethod()]
        public void AgeIsNeverLessThanZero()
        {
            CreateTeam(100);
            Boolean lessThanZero = false;
            foreach (Person person in team)
            {
                if (person.age < 0)
                {
                    lessThanZero = true;
                    break;
                };
            }
            Assert.IsFalse(lessThanZero);
        }

        [TestMethod()]
        public void RandomNameNeverShouldBeAnEmptyString()
        {
            Assert.IsTrue(alfonz.name.Length > 0);
        }

        [TestMethod()]
        public void GivenNameNeverShouldBeAnEmptyString() {
            var birthDay = new DateTime(2001, 9, 11);
            Person fanny = new Person("", birthDay, Person.Genders.Male);
            Assert.IsTrue(alfonz.name.Length > 0);
        }

        [TestMethod()]
        public void NameCanContainOnlyAlphabeticalCharacters(){
             Assert.IsTrue(Regex.IsMatch(alfonz.name, @"^[a-zA-Z]+$"));
        }

        [TestMethod()]
        public void NameIsAlwaysAString(){
             Assert.IsTrue(alfonz.name is string);
        }

        [TestMethod()]
        public void Serialize_CreatesFile()
        {
            alfonz.Serialize();
            string fileName = alfonz.name + ".bin";
            Assert.IsTrue(File.Exists(fileName));
        }
        
        [TestMethod()]
        public void Serialize_DeletesFile()
        {
            alfonz.Serialize();
            string fileName = alfonz.name + ".bin";
            File.Delete(fileName);
            Assert.IsFalse(File.Exists(fileName));
        }

        [TestMethod()]
        public void Deserialize_CreatesObject()
        {
            Person fanny;
            alfonz.name = "NagyPatikabooo";
            alfonz.Serialize();
            fanny = Person.Deserialize(alfonz.name);
            Assert.IsNotNull(fanny);
        }

        [TestMethod()]
        public void Deserialize_ObjectHasAName()
        {
            Person fanny;
            alfonz.name = "NagyPatikabooo";
            alfonz.Serialize();
            fanny = Person.Deserialize(alfonz.name);
            Assert.Equals(fanny.name, alfonz.name);
        }
    }
}
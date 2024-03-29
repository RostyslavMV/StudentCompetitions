﻿using System;
using System.Collections.ObjectModel;

namespace StudentCompetitions
{
    public class CompetitionCollection : Collection<Competition>
    {
        private StudentCollection Students { get; set; }

        private Collection<Student> FirstHalf()
        {
            Collection<Student> firstHalf = new Collection<Student>();
            for(int i = 0; i < Students.Count / 2; i++)
            {
                firstHalf.Add(Students[i]);
            }
            return firstHalf;
        }

        private Collection<Student> SecondHalf()
        {
            Collection<Student> secondHalf = new Collection<Student>();
            for (int i = Students.Count / 2; i < Students.Count; i++)
            {
                secondHalf.Add(Students[i]);
            }
            return secondHalf;
        }

        public void GenerateCompetitionCollection()
        {
            Collection<string> Math = new Collection<string> { "Algebra", "Geometry" };
            Collection<string> ProgrammingAlgebra = new Collection<string> { "Programming", "Algebra" };
            Collection<string> English = new Collection<string> { "English" };
            Collection<String> EnglishAlgebra = new Collection<string> { "English", "Algebra" };
            Collection<string> Programming = new Collection<string> { "Programming" };
            Collection<Student> firstHalf = FirstHalf();
            Collection<Student> secondHalf = SecondHalf();

            Add(new Competition("Kyiv Math Contest", "National", new DateTime(2019, 5, 30), Math, Students));
            Add(new Competition("Code Olypmiad 2019", "University", new DateTime(2019, 9, 28), ProgrammingAlgebra, firstHalf));
            Add(new Competition("English Quiz", "University", new DateTime(2019, 2, 10), EnglishAlgebra, firstHalf));
            Add(new Competition("Math Code Expo", "National", new DateTime(2019, 5, 11), ProgrammingAlgebra, Students));
            Add(new Competition("Dubai code 2019", "National", new DateTime(2019, 3, 12), Programming, Students));
            Add(new Competition("World Math Contest 2019", "International", new DateTime(2019, 4, 4), Math, secondHalf));
            Add(new Competition("Lviv Programming Contest", "International", new DateTime(2019, 5, 24), Programming, secondHalf));
            Add(new Competition("English Olympiad 2019", "University", new DateTime(2019, 7, 18), English, firstHalf));
        }

        public void GenerateCompetitionResults()
        {
            foreach (Competition competition in this)
            {
                competition.MakeResults();
            }
            foreach (Student student in Students)
            {
                student.CalculateAverageResult("All");
            }
        }

        public CompetitionCollection(StudentCollection students)
        {
            Students = students;
            GenerateCompetitionCollection();
            GenerateCompetitionResults();
        }
    }
}

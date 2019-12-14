using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StudentCompetitions
{
    public class StudentCollection : Collection<Student>
    {
        public Random random = new Random();
        private Dictionary<string, double> SkillDictionaryRandomValues()
        {
            Dictionary<string, double> SkillDictionary = new Dictionary<string, double>();
            SkillDictionary.Add("Algebra", random.NextDouble() * 10.0);
            SkillDictionary.Add("Geometry", random.NextDouble() * 10.0);
            SkillDictionary.Add("Programming", random.NextDouble() * 10.0);
            SkillDictionary.Add("English", random.NextDouble() * 10.0);
            return SkillDictionary;
        }

        private Collection<Student> RivalsRandom(Collection<Student> Students)
        {
            Collection<Student> rivals = new Collection<Student>();
            Random random = new Random();
            foreach (Student student in Students)
            {
                if (random.NextDouble() > 0.5)
                    rivals.Add(student);
            }
            return rivals;
        }

        private void GenerateStudentCollection()
        {
            string[] Names = { "Ivan", "Peter", "John", "Andrew", "Mike", "Alice", "Rose", "Bob", "Jason", "Marry",
        "Elizabeth","Emma","Sophia", "Garry"};
            int count = 0;
            foreach (string name in Names)
            {
                count++;
                switch (count % 4)
                {
                    case 0:
                        Add(new StudentWithRandom(name, SkillDictionaryRandomValues()));
                        break;
                    case 1:
                        Add(new StudentDependsOnPast(name, SkillDictionaryRandomValues()));
                        break;
                    case 2:
                        Add(new StudentWithRivals(name, SkillDictionaryRandomValues(), RivalsRandom(this)));
                        break;
                    default:
                        Add(new Student(name, SkillDictionaryRandomValues()));
                        break;
                }
            }
        }
        public StudentCollection()
        {
            GenerateStudentCollection();
        }
    }
}

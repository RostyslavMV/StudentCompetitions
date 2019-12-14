using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StudentCompetitions
{
    class Student
    {
        public string Name { get; private set; }

        public Dictionary<string, double> Skills { get; private set; }

        public ObservableCollection<CompetitionResult> PreviousResults { get; private set; }

        public virtual double GenerateResult(Competition competition)
        {
            double result = 0;
            double addition;
            foreach (string subject in competition.Subjects)
            {
                if (Skills.TryGetValue(subject, out addition))
                    result += addition;
            }
            return result;
        }

        public Student(string Name, Dictionary<string, double> Skills)
        {
            this.Name = Name;
            this.Skills = Skills;
        }
    }
    class StudentWithRandom : Student
    {
        public override double GenerateResult(Competition competition)
        {
            double result = base.GenerateResult(competition);
            Random random = new Random();
            result += random.NextDouble() * result;
            return result;
        }

        public StudentWithRandom(string Name, Dictionary<string, double> Skills) : base(Name, Skills)
        {
        }
    }

    class StudentDependsOnPast : Student
    {
        public override double GenerateResult(Competition competition)
        {
            double result = base.GenerateResult(competition);
            foreach (CompetitionResult prevResult in PreviousResults)
            {
                if (competition.Type == prevResult.Competition_.Type)
                    result += 5.0 / prevResult.Place;
            }
            return result;
        }
        public StudentDependsOnPast(string Name, Dictionary<string, double> Skills) : base(Name, Skills)
        {
        }
    }

    class StudentWithRivals : Student
    {
        public Collection<Student> Rivals { get; private set; }

        public override double GenerateResult(Competition competition)
        {
            double result = base.GenerateResult(competition);
            foreach (CompetitionResult prevResult in PreviousResults)
            {
                foreach (Student participant in competition.Participants)
                {
                    if (Rivals.Contains(participant))
                        result += 2;
                }
            }
            return result;
        }

        public StudentWithRivals(string Name, Dictionary<string, double> Skills, Collection<Student> Rivals) : base(Name, Skills)
        {
            this.Rivals = Rivals;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace StudentCompetitions
{
    public class Competition
    {
        public string Name { get; private set; }

        public string Type { get; private set; }

        public DateTime Date { get; private set; }

        public Collection<string> Subjects { get; private set; }

        public List<Student> Participants { get; private set; }

        public bool IsHappened { get; private set; } = false;

        public Competition(string Name, string Type, DateTime Date, Collection<string> Subjects, Collection<Student> Participants)
        {
            this.Name = Name;
            this.Type = Type;
            this.Date = Date;
            this.Subjects = Subjects;
            this.Participants = Participants.ToList();
        }

        public void MakeResults()
        {
            Participants = Participants.OrderByDescending(o => o.GenerateResult(this)).ToList();
            int place = 1;
            foreach (Student student in Participants)
            {
                student.PreviousResults.Add(new CompetitionResult(this, student.LastResult, place));
                place++;
            }
            IsHappened = true;
        }
    }

    public class CompetitionResult
    {
        public Competition Competition_ { get; private set; }

        public int Place { get; set; }

        public double Mark { get; private set; }

        public CompetitionResult(Competition Competition_, double Mark,int Place)
        {
            this.Competition_ = Competition_;
            this.Place = Place;
            this.Mark = Mark;
        }
    }
}

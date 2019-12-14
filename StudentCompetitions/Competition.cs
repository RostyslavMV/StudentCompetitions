using System;
using System.Collections.ObjectModel;

namespace StudentCompetitions
{
    class Competition
    {
        public string Name { get; private set; }

        public string Type { get; private set; }

        public DateTime Date { get; private set; }

        public Collection<string> Subjects { get; private set; }

        public Collection<Student> Participants { get; private set; }

        public Competition(string Name, string Type, DateTime Date, Collection<string> Subjects, Collection<Student> Participants)
        {
            this.Name = Name;
            this.Type = Type;
            this.Date = Date;
            this.Subjects = Subjects;
            this.Participants = Participants;
        }
    }

    class CompetitionResult
    {
        public Competition Competition_ { get; private set; }

        public int Place { get; private set; }

        public CompetitionResult(Competition Competition_, int Place)
        {
            this.Competition_ = Competition_;
            this.Place = Place;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCompetitions
{
    class Student
    {
        public string Name { get; private set; }

        public Dictionary<string,double> Skills { get; private set; }

        public ObservableCollection<Result> PreviousRsults { get; private set; }

    }
}

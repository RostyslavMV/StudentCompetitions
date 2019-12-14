using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCompetitions
{
    static class Data
    {
        public static StudentCollection Students = new StudentCollection();
        public static CompetitionCollection Competitions = new CompetitionCollection(Students);

    }
}

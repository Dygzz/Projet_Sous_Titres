using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecteurVideo
{
    class Subtitle
    {
        public string subt;
        public int timeStart;
        public int timeEnd;

        public Subtitle(string SUBTITLE, int TIME, int End)
        {
            subt = SUBTITLE;
            timeStart = TIME;
            timeEnd = End;
        }
    }
}

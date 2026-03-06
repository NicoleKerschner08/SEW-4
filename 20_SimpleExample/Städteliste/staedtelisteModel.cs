using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Städteliste
{
    internal class staedtelisteModel
    {
        public List<staedte> StaedteListe = new List<staedte>()
        {
            new staedte("Berlin", "Deutschland", 3644826, true),
            new staedte("Hamburg", "Deutschland", 1841179, false),
            new staedte("München", "Deutschland", 1471508, false),
            new staedte("Köln", "Deutschland", 1085664, false),
            new staedte("Wien", "Österreich", 1000000, true)
        };




    }
}

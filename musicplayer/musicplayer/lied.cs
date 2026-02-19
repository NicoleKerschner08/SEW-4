using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musicplayer
{
    internal class lied
    {
        public string title;
        public string interpret;
        public int releaseYear;
        public string additionalText;

        public lied(string title, string interpret, int releaseYear, string additionalText)
        {
            this.title = title;
            this.interpret = interpret;
            this.releaseYear = releaseYear;
            this.additionalText = additionalText;
        }

        public override string ToString()
        {
            string formattedString = $"{title} - {interpret} ({releaseYear})";
            return formattedString;
        }
    }
}

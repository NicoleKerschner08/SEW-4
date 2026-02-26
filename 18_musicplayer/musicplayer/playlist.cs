using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musicplayer
{
    internal class playlist
    {
        public string name;
        public List<lied> songs;
        public playlist(string name)
        {
            this.name = name;
            this.songs = new List<lied>();
        }
        public void addSong(lied song)
        {
            songs.Add(song);
        }

        public override string ToString()
            {
                return name;
        }
    }
}

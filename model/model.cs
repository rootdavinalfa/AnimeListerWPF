using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListerWPF.model
{
    public class AnimeList
    {
        public bool error { get; set; }
        public string message { get; set; }

        public IList<Anime> anim { get; set; }
    }

    public class Anime
    {
        public string package_anim { get; set; }
        public string name_anim { get; set; }
        public float rating { get; set; }
        public string cover { get; set; }
    }

    public class Details
    {
        public bool error { get; set; }
        public string message { get; set; }

        public IList<AnimeDetail> anim { get; set; }
    }

    public class AnimeDetail
    {
        public string package_anim { get; set; }
        public string name_catalogue { get; set; }
        public float rating { get; set; }
        public string cover { get; set; }
        public string synopsis { get; set; }
        public string mal_id { get; set; }
        public List<string> genre { get; set; }
    }
}

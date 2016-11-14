using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Project
{
    class Movie1 //changed From 'Movie' since 'Movie' is already defined in the PullMovieAPI -Jeremy
    {
        public String Title { get; set; }
        public String Year { get; set; }
        public String Genre { get; set; }
        public String Plot { get; set; }
        public String imdbRating { get; set; }
        public String Runtime { get; set; }
        public String Response { get; set; }
        public String Path { get; set; }
        public String Actors { get; set; }
        public String Poster { get; set; }
        public String Res { get; set; }
    }
}

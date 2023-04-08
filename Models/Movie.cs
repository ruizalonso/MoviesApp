using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class Movie
    {
        [DisplayName("Título")]
        public string Title { get; set; }

        [DisplayName("Year")]
        public string Year { get; set; }

        [DisplayName("ID")]
        public string imdbID { get; set; }

        [DisplayName("Tipo")]
        public string Type { get; set; }

        [DisplayName("Released")]
        public string Released { get; set; }

        [DisplayName("Genero")]
        public string Genre { get; set; }

        [DisplayName("Director")]
        public string Director { get; set; }

        [DisplayName("Actores")]
        public string Actors { get; set; }

        [DisplayName("Trama")]
        public string Plot { get; set; }

        [DisplayName("Rating")]
        public string imdbRating { get; set; }

        public string Poster { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public int Rating { get; set; }

        public Movie(string title, string director, string genre, int year, int rating){
            Title = title;
            Director = director;
            Genre = genre;
            Year = year;
            Rating = rating;
        }
    }
}
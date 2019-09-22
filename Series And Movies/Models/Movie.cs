using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Series_And_Movies.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string Title { get; set; }
        public int NumOfSeason { get; set; }
        public int Views { get; set; }
        
        public string Details { get; set; }

      public Movie(string imageUrl, string title, int numOfSeason, int views, string details)
      {
            this.ImagePath = imageUrl;
            this.Title = title;
            this.NumOfSeason = numOfSeason;
            this.Views = views;
            this.Details = details;
      }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BeKindRewind
{
    public class Film
    {
        #region Attributs 
        public int FilmId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? ReleaseYear { get; set; }
        public int? LanguageId { get; set; }
        public int? OriginalLanguageId { get; set; }
        public string RentalDuration { get; set; }
        public string RantalRate { get; set; }
        public string Length { get; set; }
        public string ReplacementCost { get; set; } 
        public string Rating { get; set; }
        public string SpecialFeatures { get; set; } 
        public DateTime LastUpdate { get; set; }
        public int ActorNum { get; set; }
        #endregion

        public Film()
        {

        }
        //public Film(int filmid , string title,  string description, int releaseYear , int languageId, int originalLanguageId, int realDuration, decimal rantalRate, int length , decimal 
        //    replacementCost, string  rating , string  specialFeatures , DateTime lastUpdate )
        //{
        //    FilmId = filmid;
        //    Title = title;
        //    Description = description;
        //    ReleaseYear = releaseYear;
        //    LanguageId = languageId;
        //    OriginalLanguageId = originalLanguageId;
        //    RentalDuration = realDuration;
        //    RantalRate = rantalRate;
        //    Length = length;
        //    ReplacementCost = replacementCost;
        //    Rating = rating;
        //    SpecialFeatures = specialFeatures;
        //    LastUpdate = lastUpdate;
        //}


    }
}

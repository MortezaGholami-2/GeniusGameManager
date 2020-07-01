using System;
using System.Collections.Generic;
using System.Text;

using GGM_ClassLibraryStandard.Models;

namespace GGM_ClassLibraryStandard.Interfaces
{
    public interface IPlatform
    {
        int Id { get; set; }
        string Name { get; set; }
        DateTime ReleaseDate { get; set; }
        string Developer { get; set; }
        string Manufacturer { get; set; }
        int MaxControllers { get; set; }
        string Cpu { get; set; }
        string Memory { get; set; }
        string Graphics { get; set; }
        string Sound { get; set; }
        string Display { get; set; }
        string Media { get; set; }
        string Notes { get; set; }

        //List<MovieId> MovieId { get; set; }
        //string Title { get; set; }
        //List<Cast> Stars { get; set; }
        //List<Cast> Cast { get; set; }
        //List<Crew> Crew { get; set; }
        //string Plot { get; set; }
        //List<string> Genres { get; set; }
        //int Runtime { get; set; }




        ////public string OriginalTitle { get; set; }


        ////public List<RatingModel> Ratings { get; set; }
        //public int UserRating { get; set; }
        //public bool Favorite { get; set; }
        ////public List<CountryModel> Countries { get; set; }
        //public List<string> Languages { get; set; }
        ////public List<CountryModel> FilmingLocation { get; set; }
        ////public List<CompanyModel> ProductionCompanies { get; set; }
        //public List<string> Categories { get; set; }
        ////public List<TagModel> Tags { get; set; }
        //public string Studio { get; set; }
        //public string Label { get; set; }
        //public List<string> Channel { get; set; }
        //public string ContentID { get; set; }
        //public string DVDID { get; set; }
        //movieset

        //public List<Trailer> Trailers { get; set; }
        // *************************************************
        //string PageUrl { get; set; }
        //string PosterUrl { get; set; }
        //string CoverUrl { get; set; }
        //List<string> Trailers { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

using GGM_ClassLibraryStandard.Models;

namespace GGM_ClassLibraryStandard.Interfaces
{
    public interface IGame
    {
        int Id { get; set; }
        string Title { get; set; }
        //string SortTitle { get; set; }
        //int LaunchBoxId { get; set; }
        //List<AlternateTitle> AlternateTitles { get; set; }
        //DateTime ReleaseDate { get; set; }
        //string ESRB { get; set; }
        //List<Genre> Genres { get; set; }
        string Platform { get; set; }
        //string Developers { get; set; }
        //string Publishers { get; set; }
        //string Series { get; set; }
        //Region Region { get; set; }
        //string PlayMode { get; set; }
        //string Version { get; set; }
        //string Status { get; set; }
        //string Source { get; set;}
        //DateTime GameAdded { get; set; }
        //DateTime LastPlayed { get; set; }
        //string Rating { get; set; }
        //int PlayCount { get; set; }
        //bool IsFavorite { get; set; }
        //bool IsPortable { get; set; }
        //bool IsComplete { get; set; }
        //bool IsHidden { get; set; }
        //bool IsBroken { get; set; }
        //bool IsInstalled { get; set; }
        string Notes { get; set; }

        //string GamePath { get; set; }
        //string ManualPath { get; set; }

        //string GameType { get; set; }
        //int MaxPlayers { get; set; }
        //string Cooperative { get; set; }
        //string GameUrl { get; set; }
        

        //List<MovieId> MovieId { get; set; }
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

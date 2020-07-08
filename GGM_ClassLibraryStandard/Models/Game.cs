using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using GGM_ClassLibraryStandard.Interfaces;

namespace GGM_ClassLibraryStandard.Models
{
    public class Game : IGame, INotifyPropertyChanged
    {
        // *********** For Database ************************
        public int Id { get; set; }

        private string name;
        public string Name
        {
            get { return name; }

            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private DateTime releaseDate;
        public DateTime ReleaseDate
        {
            get { return releaseDate; }

            set
            {
                releaseDate = value;
                OnPropertyChanged(nameof(ReleaseDate));
            }
        }

        private string developer;
        public string Developer
        {
            get { return developer; }

            set
            {
                developer = value;
                OnPropertyChanged(nameof(Developer));
            }
        }
        
        private string manufacturer;
        public string Manufacturer
        {
            get { return manufacturer; }

            set
            {
                manufacturer = value;
                OnPropertyChanged(nameof(Manufacturer));
            }
        }

        private int maxControllers;
        public int MaxControllers
        {
            get { return maxControllers; }

            set
            {
                maxControllers = value;
                OnPropertyChanged(nameof(MaxControllers));
            }
        }

        private string cpu;
        public string Cpu
        {
            get { return cpu; }

            set
            {
                cpu = value;
                OnPropertyChanged(nameof(Cpu));
            }
        }

        private string memory;
        public string Memory
        {
            get { return memory; }

            set
            {
                memory = value;
                OnPropertyChanged(nameof(Memory));
            }
        }

        private string graphics;
        public string Graphics
        {
            get { return graphics; }

            set
            {
                graphics = value;
                OnPropertyChanged(nameof(Graphics));
            }
        }

        private string sound;
        public string Sound
        {
            get { return sound; }

            set
            {
                sound = value;
                OnPropertyChanged(nameof(Sound));
            }
        }

        private string display;
        public string Display
        {
            get { return display; }

            set
            {
                display = value;
                OnPropertyChanged(nameof(Display));
            }
        }

        private string media;
        public string Media
        {
            get { return media; }

            set
            {
                media = value;
                OnPropertyChanged(nameof(Media));
            }
        }

        private string notes;
        public string Notes
        {
            get { return notes; }

            set
            {
                notes = value;
                OnPropertyChanged(nameof(Notes));
            }
        }





        private string platformUrl;
        public string PlatformUrl
        {
            get { return platformUrl; }

            set
            {
                platformUrl = value;
                OnPropertyChanged(nameof(PlatformUrl));
            }
        }

        private string pictureUrl;
        public string PictureUrl
        {
            get { return pictureUrl; }

            set
            {
                pictureUrl = value;
                OnPropertyChanged(nameof(PictureUrl));
            }
        }





        //private List<MovieId> movieId;
        //public List<MovieId> MovieId
        //{
        //    get { return movieId; }

        //    set
        //    {
        //        movieId = value;
        //        OnPropertyChanged(nameof(MovieId));
        //    }
        //}


        //private string tagLine;
        //public string TagLine
        //{
        //    get { return tagLine; }

        //    set
        //    {
        //        tagLine = value;
        //        OnPropertyChanged(nameof(TagLine));
        //    }
        //}

        //private List<Cast> stars;
        //public List<Cast> Stars
        //{
        //    get { return stars; }

        //    set
        //    {
        //        stars = value;
        //        OnPropertyChanged(nameof(Stars));
        //    }
        //}

        //private List<Cast> cast;
        //public List<Cast> Cast
        //{
        //    get { return cast; }

        //    set
        //    {
        //        cast = value;
        //        OnPropertyChanged(nameof(Cast));
        //    }
        //}

        //private List<Crew> crew;
        //public List<Crew> Crew
        //{
        //    get { return crew; }

        //    set
        //    {
        //        crew = value;
        //        OnPropertyChanged(nameof(Crew));
        //    }
        //}

        //private string plot;
        //public string Plot
        //{
        //    get { return plot; }

        //    set
        //    {
        //        plot = value;
        //        OnPropertyChanged(nameof(Plot));
        //    }
        //}

        //private List<string> genres;
        //public List<string> Genres
        //{
        //    get { return genres; }

        //    set
        //    {
        //        genres = value;
        //        OnPropertyChanged(nameof(Genres));
        //    }
        //}


        //private int runtime;
        //public int Runtime
        //{
        //    get { return runtime; }

        //    set
        //    {
        //        runtime = value;
        //        OnPropertyChanged(nameof(Runtime));
        //    }
        //}

        //////public string OriginalTitle { get; set; }



        //private List<string> productionCompanies;
        //public List<string> ProductionCompanies
        //{
        //    get { return productionCompanies; }

        //    set
        //    {
        //        productionCompanies = value;
        //        OnPropertyChanged(nameof(ProductionCompanies));
        //    }
        //}
        ////private string title;
        ////public string Title
        ////{
        ////    get { return title; }

        ////    set
        ////    {
        ////        title = value;
        ////        OnPropertyChanged(nameof(Title));
        ////    }
        ////}

        ////private string title;
        ////public string Title
        ////{
        ////    get { return title; }

        ////    set
        ////    {
        ////        title = value;
        ////        OnPropertyChanged(nameof(Title));
        ////    }
        ////}



        //////public List<CompanyModel> ProductionCompanies { get; set; }


        //////public List<RatingModel> Ratings { get; set; }
        ////public int UserRating { get; set; }
        ////public bool Favorite { get; set; }
        //////public List<CountryModel> Countries { get; set; }
        ////public List<string> Languages { get; set; }
        //////public List<CountryModel> FilmingLocation { get; set; }
        ////public List<string> Categories { get; set; }
        //////public List<TagModel> Tags { get; set; }
        ////public string Series { get; set; }
        ////public string Studio { get; set; }
        ////public string Label { get; set; }
        ////public List<string> Channel { get; set; }
        ////public string ContentID { get; set; }
        ////public string DVDID { get; set; }
        ////movieset

        ////public List<Trailer> Trailers { get; set; }
        //// *************************************************

        //// ************ Not For Database *******************
        //public string PageUrl { get; set; }
        //public string PosterUrl { get; set; }
        //public string CoverUrl { get; set; }
        //public List<string> Trailers { get; set; }

        //// *************************************************

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

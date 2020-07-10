using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using GGM_ClassLibraryStandard.Interfaces;

namespace GGM_ClassLibraryStandard.Models
{
    public class Platform : IPlatform, INotifyPropertyChanged
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

        private string fileType;
        public string FileType
        {
            get { return fileType; }

            set
            {
                fileType = value;
                OnPropertyChanged(nameof(FileType));
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

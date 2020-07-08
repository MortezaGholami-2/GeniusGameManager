using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using GGM_ClassLibraryStandard.Interfaces;

namespace GGM_ClassLibraryStandard.Models
{
    public class AlternateTitle : IAlternateTitle, INotifyPropertyChanged
    {
        // *********** For Database ************************
        public int Id { get; set; }

        private string title;
        public string Title
        {
            get { return title; }

            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private Region region;
        public Region Region
        {
            get { return region; }

            set
            {
                region = value;
                OnPropertyChanged(nameof(Region));
            }
        }
        // *************************************************

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

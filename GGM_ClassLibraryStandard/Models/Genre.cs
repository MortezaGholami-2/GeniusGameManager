using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using GGM_ClassLibraryStandard.Interfaces;

namespace GGM_ClassLibraryStandard.Models
{
    public class Genre : IGenre, INotifyPropertyChanged
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
        // *************************************************

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

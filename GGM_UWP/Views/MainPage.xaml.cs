using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using GGM_ClassLibraryStandard.Models;
using GGM_UWP.Services;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GGM_UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {

        private ObservableCollection<Platform> platformsList;
        public ObservableCollection<Platform> PlatformsList
        {
            get { return platformsList; }

            set
            {
                platformsList = value;
                OnPropertyChanged(nameof(PlatformsList));
            }
        }

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // ******** Getting platforms from database and put them in a public *************
            // ******** observable collection property that binds to a list view control *****
            PlatformsList = await DatabaseService.GetPlatforms();
            // ********************************************************************************

        }

        private void AddPlatformButton_Click(object sender, RoutedEventArgs e)
        {

        }











        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

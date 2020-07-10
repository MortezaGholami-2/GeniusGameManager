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
using GGM_ClassLibraryStandard.Scrapers;
using GGM_UWP.Services;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GGM_UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AllPlatformsPage : Page, INotifyPropertyChanged
    {

        private ObservableCollection<Platform> allPlatformsList;
        public ObservableCollection<Platform> AllPlatformsList
        {
            get { return allPlatformsList; }

            set
            {
                if(allPlatformsList != value)
                {
                    allPlatformsList = value;
                    OnPropertyChanged(nameof(AllPlatformsList));
                }
            }
        }

        private Platform selectedPlatform;
        public Platform SelectedPlatform
        {
            get { return selectedPlatform; }

            set
            {
                if (selectedPlatform != value)
                {
                    selectedPlatform = value;
                    OnPropertyChanged(nameof(SelectedPlatform));
                }
            }
        }

        public AllPlatformsPage()
        {
            this.InitializeComponent();
            AllPlatformsList = new ObservableCollection<Platform>();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // ******** Getting platforms from LaunchBox and put them in a public ************
            // ******** observable collection property that binds to a list view control *****
            AllPlatformsList = await LaunchBoxScraper.GetAllPlatforms();
            SelectedPlatform = new Platform();
            // *******************************************************************************

        }

        private async void SavePlatformButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPlatform != null)
            {
                await DatabaseService.AddPlatform(await LaunchBoxScraper.GetPlatformDetails(SelectedPlatform));
            }
            Frame frame = this.Frame;
            frame.Navigate(typeof(MainPage));
        }





        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

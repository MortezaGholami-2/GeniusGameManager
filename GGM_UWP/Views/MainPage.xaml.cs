using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.AccessCache;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GGM_UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {

        // ========== must delete later ==========================
        private ObservableCollection<AccessListEntry> futureAccessListEntries;
        public ObservableCollection<AccessListEntry> FutureAccessListEntries
        {
            get { return futureAccessListEntries; }

            set
            {
                futureAccessListEntries = value;
                OnPropertyChanged(nameof(FutureAccessListEntries));
            }
        }
        // =======================================================

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

        private ObservableCollection<Game> gamesList;
        public ObservableCollection<Game> GamesList
        {
            get { return gamesList; }

            set
            {
                gamesList = value;
                OnPropertyChanged(nameof(GamesList));
            }
        }

        public MainPage()
        {
            this.InitializeComponent();

            // ********** must delete later **************************
            // ********** shows the folders in future access list of operating system ************
            IEnumerable<AccessListEntry> accessListEntries = StorageService.GetFutureAccessListEntries();
            FutureAccessListEntries = new ObservableCollection<AccessListEntry>(accessListEntries);
            if (!accessListEntries.Any())
            {
                FutureAccessListTextBlock.Text = "There is no address in future access list.";
            }
            else
                FutureAccessListTextBlock.Text = "";
            // ========================================================

        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // ******** Getting tables from database and put them in a public *****************
            // ******** observable collection property that binds to list view controls *******
            PlatformsList = await DatabaseService.GetPlatforms();
            GamesList = await DatabaseService.GetGames();
            // ********************************************************************************

        }

        private void AddPlatformButton_Click(object sender, RoutedEventArgs e)
        {
            Frame a = this.Frame;
            a.Navigate(typeof(AllPlatformsPage));
        }

        private void AddGameButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void ImportGameButton_Click(object sender, RoutedEventArgs e)
        {
            // open file picker
            // select the file
            // get display name and extension of file
            // find platform by file type
            // search in launch box by displayname (name, platform, notes, picture)
            // for each search result check if item.platform is equal to platform by file type
            // if true return the item
            try
            {
                var picker = new Windows.Storage.Pickers.FileOpenPicker();
                picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.List;
                picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
                picker.FileTypeFilter.Add(".nes");

                Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();

                if (file != null)
                {
                    string extension = StorageService.GetFileExtension(file);
                    Game game = new Game() { Title = file.DisplayName, Platform = "", Notes = file.Path };
                    ObservableCollection<Game> a = await LaunchBoxScraper.SearchGame(file.DisplayName);
                    foreach (var item in a)
                    {
                        if(item.Platform=="Nintendo Entertainment System")
                            await NotificationService.DisplaySimpleMessageDialog(item.Title, item.Platform);
                    }
                    await DatabaseService.AddGame(game);
                    GamesList.Add(game);
                }
                else
                {
                    await NotificationService.DisplaySimpleMessageDialog("", "Operation cancelled.");
                }
            }
            catch (Exception error)
            {
                await NotificationService.DisplaySimpleMessageDialog("", error.Message);
                throw;
            }



            // *************** delete ************************
            FutureAccessListTextBlock.Text = "";
            IEnumerable<AccessListEntry> accessListEntries = StorageService.GetFutureAccessListEntries();
            FutureAccessListEntries = new ObservableCollection<AccessListEntry>(accessListEntries);
            // ***********************************************
        }








        // ********** must delete later **************************
        private async void EmptyFutureAccessList_Click(object sender, RoutedEventArgs e)
        {
            StorageService.EmptyFutureAccessList();
            FutureAccessListEntries.Clear();
            FutureAccessListTextBlock.Text = "There is no entry in the list.";
            await NotificationService.DisplaySimpleMessageDialog("", "Future Access List is empty now!");
        }
        // *******************************************************


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

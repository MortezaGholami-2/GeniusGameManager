using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Pickers;
using Windows.Storage.AccessCache;
using Windows.Storage;
using Windows.Storage.Search;

//using GMM_UWP.Models;
//using GMM_UWP.Settings;
using GGM_UWP.Services;
using GGM_ClassLibraryStandard.Models;

namespace GGM_UWP.Services
{
    public static class StorageService
    {

        // ********************** Future Access List *************************************
        #region Future Access List

        public static AccessListEntryView GetFutureAccessListEntries()
        {
            return StorageApplicationPermissions.FutureAccessList.Entries;
        }

        public static AccessListEntry GetFutureAccessListFolderByFolderPath(string folderPath)
        {
            return GetFutureAccessListEntries().Single(item => item.Metadata == folderPath);
        }

        /// <summary>
        /// Adds a folder to Future Access List of operating system (Morteza).
        /// </summary>
        /// <param name="folder">The folder to be added to Future Access List.</param>
        /// <param name="metadata">A string that will be used to get the folder's address.</param>
        public static void AddFolderToFutureAccessList(StorageFolder folder, string metadata)
        {
            StorageApplicationPermissions.FutureAccessList.Add(folder, metadata);
        }

        /// <summary>
        /// This method will remove a folder from future access list (Morteza).
        /// </summary>
        /// <param name="folder">A folder for deletion from future access list (Morteza).</param>
        public static void DeleteFolderFromFutureAccessList(string folderPath)
        {
            AccessListEntry deletedVideoFolderInFutureAccessList = GetFutureAccessListFolderByFolderPath(folderPath);
            StorageApplicationPermissions.FutureAccessList.Remove(deletedVideoFolderInFutureAccessList.Token);
        }

        /// <summary>
        /// This method will empty future access list (Morteza).
        /// </summary>
        public static void EmptyFutureAccessList()
        {
            foreach (AccessListEntry item in GetFutureAccessListEntries())
            {
                StorageApplicationPermissions.FutureAccessList.Remove(item.Token);
            }
        }

        #endregion
        // *******************************************************************************

        // ********************** Files Commands *****************************************
        #region Files Commands

        public static async Task<StorageFile> GetFileAsync(string filePath)
        {
            try
            {
                StorageFile file = await StorageFile.GetFileFromPathAsync(filePath);
                return file;
            }
            catch (Exception error)
            {
                await NotificationService.DisplaySimpleMessageDialog("Error", error.Message);
                throw;
            }
        }

        public static string GetFileExtension(StorageFile file)
        {
            return file.DisplayType;
        }

        private static async Task<ObservableCollection<StorageFile>> GetFilesInFolder(string folderPath)
        {
            try
            {
                StorageFolder folder = await StorageFolder.GetFolderFromPathAsync(folderPath);
                ObservableCollection<StorageFile> files = new ObservableCollection<StorageFile>(await folder.GetFilesAsync());
                return files;
            }
            catch (Exception ex)
            {
                await NotificationService.DisplaySimpleMessageDialog("Error", ex.Message);
                return default;
            }
        }

        #endregion

        // *******************************************************************************

        // ********************** Folder Commands ****************************************
        // *******************************************************************************

        // ********************** Movie Files Commands ***********************************
        #region Movie Files Commands


        #endregion
        // *******************************************************************************
        // *******************************************************************************






        
        //public static async Task<List<VideoFile>> GetFiles()
        //{
        //    FileOpenPicker picker = new FileOpenPicker();

        //    picker.ViewMode = PickerViewMode.Thumbnail;
        //    picker.SuggestedStartLocation = PickerLocationId.Desktop;

        //    picker.FileTypeFilter.Add(".mp4");
        //    picker.FileTypeFilter.Add(".jpeg");
        //    picker.FileTypeFilter.Add(".png");
        //    var files = await picker.PickMultipleFilesAsync();
        //    if (files.Count > 0)
        //    {
        //        List<VideoFile> videoFiles = new List<VideoFile>();
        //        foreach (Windows.Storage.StorageFile file in files)
        //        {

        //            //videoFiles.Add(new VideoFile() { Name = file.Name, Path=file.Path });
        //        }
        //        return videoFiles;
        //    }
        //    else
        //    {
        //    }
        //    return default;
        //}



        public static async Task<bool> FileExist(string folderPath, string path)
        {
            StorageFolder folder = await StorageFolder.GetFolderFromPathAsync(folderPath);
            StorageFile file = await folder.GetFileAsync(path);
            if (file != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}

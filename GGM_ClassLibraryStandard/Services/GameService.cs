using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using GMM_UWP.Models;
//using GMM_UWP.Settings;
using GGM_ClassLibraryStandard.Models;

namespace GGM_ClassLibraryStandard.Services
{
    public static class GameService
    {

        // ********************** Future Access List *************************************
        #region Platform

        public static string GetPlatformFileType(string platformName)
        {
            switch (platformName)
            {
                case "Nintendo Entertainment System":
                    return "NES";
                    
                default:
                    return "*";
            }
        }



        #endregion
        // *******************************************************************************

        // ********************** Files Commands *****************************************
        #region Files Commands


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



        

    }
}

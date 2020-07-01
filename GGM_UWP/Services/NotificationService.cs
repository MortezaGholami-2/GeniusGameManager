using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Notifications;
//using Microsoft.Toolkit.Uwp.Notifications;
//using Microsoft.QueryStringDotNET;

namespace GGM_UWP.Services
{
    public static class NotificationService
    {
        //************** Message Dialogs *************************************
        public static async Task DisplaySimpleMessageDialog(string title, string message)
        {
            ContentDialog contentDialog = new ContentDialog { Title = title, Content = message, CloseButtonText = "OK" };
            ContentDialogResult contentDialogResult = await contentDialog.ShowAsync();
        }

        //************** Toast Notifications *********************************
        //public void SendBasicToastNotification(string title, string content, double expirationDay, string tag, string group)
        //{
        //    //var toastContent = new ToastContent()
        //    //{
        //    //    Visual = toastNotificationVisual(title, content)
        //    //};

        //    //ToastNotification toastNotification = new ToastNotification(toastContent.GetXml());
        //    //toastNotification.ExpirationTime = DateTime.Now.AddDays(expirationDay);
        //    //toastNotification.Tag = tag;
        //    //toastNotification.Group = group;
        //    //ToastNotificationManager.CreateToastNotifier().Show(toastNotification);
        //}

        ////private ToastVisual toastNotificationVisual(string title, string content)
        ////{
        ////    ToastVisual toastVisual = new ToastVisual()
        ////    {
        ////        BindingGeneric = new ToastBindingGeneric()
        ////        {
        ////            Children =
        ////                {
        ////                    new AdaptiveText()
        ////                    {
        ////                        Text = title
        ////                    },
        ////                    new AdaptiveText()
        ////                    {
        ////                        Text = content
        ////                    }
        ////                }
        ////        }
        ////    };
            
        //    return toastVisual;
        //}

        //private ToastVisual toastNotificationVisual(string title, string content, string logoPath)
        //{
        //    ToastVisual a = new ToastVisual();
        //    return a;
        //}

        //private ToastVisual toastNotificationVisual(string title, string content, string logoPath, string imagePath)
        //{
        //    ToastVisual a = new ToastVisual();
        //    return a;
        //}
    }
}

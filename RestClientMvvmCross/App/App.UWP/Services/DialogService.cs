using App.Core.Services;
using System;
using Windows.UI.Popups;

namespace App.UWP.Services
{
    class DialogService : IDialogService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="title">string </param>
        /// <param name="message">string </param>
        public async void ShowDialog(string title, string message)
        {
            MessageDialog dialog = new MessageDialog(message, title);
            await dialog.ShowAsync();
        }
    }
}

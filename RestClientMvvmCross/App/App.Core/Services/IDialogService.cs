using Acr.UserDialogs;

namespace App.Core.Services
{
    public interface IDialogService
    {
        void ShowDialog(string title, string message);
    }
}

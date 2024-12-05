using System.Windows.Input;
using GalaSoft.MvvmLight;
using MauiApp1112.view;
using Microsoft.Maui.Controls;

namespace MauiApp1112.ViewModel
{
    public class ViewModelPage1 :ObservableObject
    {
        public ICommand NavigateToNewPage2Command { get; }

        public ViewModelPage1()
        {
            NavigateToNewPage2Command = new Command(async () => await Shell.Current.GoToAsync("//NewPage2"));
        }

        
    }
}

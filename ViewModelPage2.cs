using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using MauiApp1112.view;
using Microsoft.Maui.Controls;

namespace MauiApp1112.ViewModel
{
    public class ViewModelPage2 : ObservableObject
    {
        public ICommand NavigateToNewPage3Command { get; }

        public ViewModelPage2()
        {
            NavigateToNewPage3Command = new Command(async () => await Shell.Current.GoToAsync("//NewPage3"));
        }

    }
}

﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace MauiApp1112.ViewModel
{
    public class ViewModelPage3 : INotifyPropertyChanged
    {
        public ObservableCollection<Forage> PredefinedForages { get; set; }

        private string _alertMessage;
        public string AlertMessage
        {
            get => _alertMessage;
            set
            {
                if (_alertMessage != value)
                {
                    _alertMessage = value;
                    OnPropertyChanged(nameof(AlertMessage));
                }
            }
        }

        public ICommand EvaluateRationCommand { get; }

        public ViewModelPage3()
        {

            PredefinedForages = new ObservableCollection<Forage>
            {
                new Forage { Name = "Paille d'Avoine", PercentMS = 88, KgMB = 0 },
                new Forage { Name = "Betterave Fourragère", PercentMS = 13, KgMB = 0 }
            };


            EvaluateRationCommand = new Command(EvaluateRation);
        }

        private void EvaluateRation()
        {

            double totalKgMS = PredefinedForages.Sum(f => f.KgMS);


            double CI = 10;


            if (totalKgMS < CI)
            {
                AlertMessage = "La capacité d’ingestion de votre vache n’est pas saturée. Augmentez la quantité des fourrages distribués.";
            }
            else if (totalKgMS > CI)
            {
                AlertMessage = "La capacité d’ingestion de votre vache est sursaturée. Diminuez la quantité des fourrages distribués.";
            }
            else
            {
                AlertMessage = "La ration est équilibrée.";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Forage : INotifyPropertyChanged
    {
        private double _percentMS;
        public double PercentMS
        {
            get => _percentMS;
            set
            {
                if (_percentMS != value)
                {
                    _percentMS = value;
                    OnPropertyChanged(nameof(PercentMS));
                    OnPropertyChanged(nameof(KgMS)); 
                }
            }
        }

        private double _kgMB;
        public double KgMB
        {
            get => _kgMB;
            set
            {
                if (_kgMB != value)
                {
                    _kgMB = value;
                    OnPropertyChanged(nameof(KgMB));
                    OnPropertyChanged(nameof(KgMS)); 
                }
            }
        }

        public string Name { get; set; }

        public double KgMS => KgMB * PercentMS / 100;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
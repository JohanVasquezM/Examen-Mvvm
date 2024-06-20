using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;

namespace ExamenMvvm.ViewModels
{
    public partial class QuadraticViewModel : ObservableObject
    {
        [ObservableProperty]
        private double a;

        [ObservableProperty]
        private double b;

        [ObservableProperty]
        private double c;

        [ObservableProperty]
        private double x1;

        [ObservableProperty]
        private double x2;

        [ObservableProperty]
        private string message;

        public QuadraticViewModel()
        {
            CalculateCommand = new RelayCommand(Calculate);
            ClearCommand = new RelayCommand(Clear);
        }

        public RelayCommand CalculateCommand { get; }
        public RelayCommand ClearCommand { get; }

        private void Calculate()
        {
            Message = string.Empty;

            if (A == 0)
            {
                Message = "El valor de 'a' no puede ser 0.";
                return;
            }

            double discriminant = B * B - 4 * A * C;

            if (discriminant < 0)
            {
                Message = "El discriminante es negativo. No hay soluciones reales.";
                return;
            }

            X1 = (-B + Math.Sqrt(discriminant)) / (2 * A);
            X2 = (-B - Math.Sqrt(discriminant)) / (2 * A);
        }

        private void Clear()
        {
            A = B = C = X1 = X2 = 0;
            Message = string.Empty;
        }
    }
}

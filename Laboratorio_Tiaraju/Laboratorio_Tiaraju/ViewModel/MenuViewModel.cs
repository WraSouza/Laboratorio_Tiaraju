using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Laboratorio_Tiaraju.ViewModel
{
    public class MenuViewModel : BaseViewModel
    {
        public Command ExitCommand { get; set; }

        public MenuViewModel()
        {
            ExitCommand = new Command(() => OpenMainView());
        }

        private void OpenMainView()
        {
            App.Current.MainPage = new View.AppShell();
        }
    }
}

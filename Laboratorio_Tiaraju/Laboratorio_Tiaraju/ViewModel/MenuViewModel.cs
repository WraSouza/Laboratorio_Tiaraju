using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Laboratorio_Tiaraju.ViewModel
{
    public class MenuViewModel : BaseViewModel
    {
        public Command ExitCommand { get; set; }
        public Command OpenSchedulesView { get; set; }
        public Command OpenBookView { get; set; }
        public INavigation Navigation { get; set; }

        public MenuViewModel()
        {
            
        }

        public MenuViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            ExitCommand = new Command(() => OpenMainView());            
        }        

        private void OpenMainView()
        {
            App.Current.MainPage = new View.AppShell();
        }


    }
}

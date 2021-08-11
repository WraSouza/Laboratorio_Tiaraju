using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Laboratorio_Tiaraju.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public Command OpenRHView { get; set; }
        public Command OpenTIView { get; set; }
        public Command OpenCardapioView { get; set; }
        public Command OpenMeetingRoomView { get; set; }
        public INavigation Navigation { get; set; }

        public MainViewModel()
        {
        }

        public MainViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            OpenCardapioView = new Command(async () => await AbrirCardapioView());
            OpenMeetingRoomView = new Command(async () => await AbrirSalaReunioesView());
            //OpenRHView = new Command(async () => await AbrirRHView());
            //OpenTIView = new Command(() => AbrirTIView());
        }

        private async Task AbrirCardapioView()
        {
            await Navigation.PushAsync(new View.CardapioView());
        }


        private async Task AbrirSalaReunioesView()
        {
            await Navigation.PushAsync(new View.LoginView());
        }
    }
}

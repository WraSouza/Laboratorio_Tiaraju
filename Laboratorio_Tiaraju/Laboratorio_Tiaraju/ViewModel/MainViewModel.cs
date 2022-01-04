using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Laboratorio_Tiaraju.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public Command OpenChamado { get; set; }
        public Command OpenRHView { get; set; }
        public Command OpenTIView { get; set; }
        public Command OpenCardapioView { get; set; }
        public Command OpenMeetingRoomView { get; set; }
        public INavigation Navigation { get; set; }
        public string Responsability { get; set; }

        public MainViewModel()
        {
        }

        public MainViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            OpenCardapioView = new Command(async () => await AbrirCardapioView());
            OpenMeetingRoomView = new Command( () => AbrirSalaReunioesView());
            OpenChamado = new Command(async () => await OpenAberturaChamadoView());
            //OpenRHView = new Command(async () => await AbrirRHView());
            //OpenTIView = new Command(() => AbrirTIView());
        }

        private async Task OpenAberturaChamadoView()
        {
            await Navigation.PushAsync(new View.AberturaChamadoView());
        }

        private async Task AbrirCardapioView()
        {
            await Navigation.PushAsync(new View.CardapioView());
        }

        private void AbrirSalaReunioesView()
        {
            string responsabilidadeUsuario = Preferences.Get("Responsabilidade", "default_value");

            if(responsabilidadeUsuario == "solicitante")
            {
                App.Current.MainPage = new View.Master.MenuView();

            }else if(responsabilidadeUsuario == "responsavel")
            {
                App.Current.MainPage = new View.Menu.MenuView();
            }            
           
        }
    }
}

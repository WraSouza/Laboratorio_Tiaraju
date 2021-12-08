using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Laboratorio_Tiaraju.ViewModel
{
    public class RHViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public Command NovoColaboradorView { get; set; }

        public RHViewModel()
        {
                       
        }

        public RHViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            NovoColaboradorView = new Command(async () => await OpenNovoColaboradorView()); //Nome do comando, qualquer um nome de preferência 
        }

        private async Task OpenNovoColaboradorView()
        {
            await Navigation.PushAsync(new View.NovoColaboradorView());
            //await Navigation.PushModalAsync(new View.NovoColaboradorView());
        }
    }
}

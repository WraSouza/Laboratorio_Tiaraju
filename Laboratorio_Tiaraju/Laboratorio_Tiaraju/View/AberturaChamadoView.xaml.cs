using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Laboratorio_Tiaraju.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AberturaChamadoView : ContentPage
    {
        public AberturaChamadoView()
        {
            InitializeComponent();

            navegador.Source = "https://laboratoriotiaraju.verdanadesk.com/index.php?noAUTO=1";
        }

        private void carregandoPagina(object sender, WebNavigatingEventArgs e)
        {
            lblStatus.Text = "Carregando Página...";
        }

        private void paginaCarregada(object sender, WebNavigatedEventArgs e)
        {
            lblStatus.Text = "Pronto";
        }
    }
}
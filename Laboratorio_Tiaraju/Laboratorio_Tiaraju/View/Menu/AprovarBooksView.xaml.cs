using Laboratorio_Tiaraju.FirebaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Laboratorio_Tiaraju.View.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AprovarBooksView : ContentPage
    {
        public AprovarBooksView()
        {
            InitializeComponent();
        }

        private async void buscarHorariosAgendados(object sender, EventArgs e)
        {
            MeetingRoomServices mrs = new MeetingRoomServices();

            string dataAtual = datePicker.Date.ToString("dd-MM-yyyy");            

            collectionview.ItemsSource = await mrs.ReservasPorData(dataAtual);
        }
        
    }
}
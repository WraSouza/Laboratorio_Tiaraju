using Laboratorio_Tiaraju.FirebaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Laboratorio_Tiaraju.View.Master
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MeetingRoomSchedulesView : ContentPage
    {
        public MeetingRoomSchedulesView()
        {
            InitializeComponent();

            datePicker.Date = DateTime.Now;
            
        }

        private async void buscarHorariosAgendados(object sender, EventArgs e)
        {
            MeetingRoomServices mrs = new MeetingRoomServices();

            collectionview.ItemsSource = await mrs.GetBooks(datePicker.Date);
        }
    }
}
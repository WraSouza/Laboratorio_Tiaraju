using Laboratorio_Tiaraju.FirebaseServices;
using Laboratorio_Tiaraju.Services;
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

        public async void buscarHorariosAgendados(object sender, EventArgs e)
        {
            MeetingRoomServices mrs = new MeetingRoomServices();
            bool verifica;
            string dataAtual = "";

            bool verificaConectividade = Conectividade.VerificaConectividade();

            if (verificaConectividade)
            {
                verifica = DataHora.VerificaSeDiaIgualHoje(datePicker.Date.Day);

                if (verifica)
                {
                    dataAtual = datePicker.Date.ToString("dd-MM-yyyy");
                }
                else
                {
                    verifica = DataHora.VerificaDataReuniao(datePicker.Date.Day);

                    if (verifica)
                    {
                        dataAtual = datePicker.Date.ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        await DisplayAlert("Info", "A Data Precisa Ser Igual ou Maior Que a Data Atual", "OK");
                    }

                }

                collectionview.ItemsSource = await mrs.ReservasPorData(dataAtual);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Erro", "Não Foi Possível Realizar a Pesquisa. Verifique Sua Conexão de Internet.", "OK");
            }

            
        }
        
    }
}
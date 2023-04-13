using Laboratorio_Tiaraju.FirebaseServices;
using Microsoft.Maui.Controls;

namespace Laboratorio_Tiaraju.View;

public partial class CalendarioCQDetailView : ContentPage
{
	public CalendarioCQDetailView()
	{
		InitializeComponent();
	}

    protected async override void OnAppearing()
    {
        var mes = Preferences.Get("MesCalendario", "default_value");
        int dia = Preferences.Get("DiaCalendario", 0);


        var descricao = Preferences.Get("DescricaoCalendario", "default_value");
        CalendarioCQServices calendarios = new CalendarioCQServices();
        collectionView.ItemsSource = await calendarios.RetornaCalendarioEspecifico(dia, mes, descricao);      

       
    }
}
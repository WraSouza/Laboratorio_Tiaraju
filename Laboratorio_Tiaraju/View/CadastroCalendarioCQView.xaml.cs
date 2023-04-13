namespace Laboratorio_Tiaraju.View;

public partial class CadastroCalendarioCQView : ContentPage
{
	public CadastroCalendarioCQView()
	{
		InitializeComponent();

        datePicker.Date = DateTime.Now;
    }
}
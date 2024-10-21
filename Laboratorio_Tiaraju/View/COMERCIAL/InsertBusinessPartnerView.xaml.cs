using Laboratorio_Tiaraju.ViewModel;

namespace Laboratorio_Tiaraju.View.COMERCIAL;

public partial class InsertBusinessPartnerView : ContentPage
{
	public InsertBusinessPartnerView(InsertBusinessPartnerViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}
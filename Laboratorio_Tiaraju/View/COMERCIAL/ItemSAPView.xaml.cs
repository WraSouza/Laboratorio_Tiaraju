using Laboratorio_Tiaraju.ViewModel;

namespace Laboratorio_Tiaraju.View.COMERCIAL;

public partial class ItemSAPView : ContentPage
{
    private readonly ItemSAPViewModel _viewModel;

    public ItemSAPView(ItemSAPViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = _viewModel = viewModel;
    }

   

}
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Laboratorio_Tiaraju.View.COMERCIAL;

namespace Laboratorio_Tiaraju.ViewModel
{
    public partial class ComercialViewModel : ObservableObject
    {
        [RelayCommand]
        public void GoToItemSAPView()
        {
            Shell.Current.GoToAsync(nameof(ItemSAPView));

        }

        [RelayCommand]
        public async void UpdateStockInStore()
        {
            bool answer = await Shell.Current.DisplayAlert("", "Gostaria de Atualizar o Estoque da Loja Virtual?", "Sim", "Não");

            if(answer)
            {

            }
        }
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Laboratorio_Tiaraju.View.COMERCIAL;

namespace Laboratorio_Tiaraju.ViewModel
{
    public partial class DepartmentsViewModel : ObservableObject
    {
        [RelayCommand]
        public void GoToComercialView()
        {
             Shell.Current.GoToAsync(nameof(ComercialView));           

        }

    }
}

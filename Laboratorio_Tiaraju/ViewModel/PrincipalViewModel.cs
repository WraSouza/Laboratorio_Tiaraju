using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Laboratorio_Tiaraju.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_Tiaraju.ViewModel
{
    partial class PrincipalViewModel : ObservableObject
    {
        [RelayCommand]
        async void OpenCalendarioCQ()
        {
            const string cq = "CQ";
            const string micro = "MICRO";
            string departamento = Preferences.Get("Departamento", "default_value");

            bool verificaConexao = Conectividade.VerificaConectividade();

            if (verificaConexao)
            {
                if ((departamento == cq) || (departamento == micro))
                {
                    var route = $"{nameof(View.CalendarioCQView)}";

                    //var route = $"{nameof(View.CalendarioCQTabbed)}";


                    await Shell.Current.GoToAsync(route);
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("", "Acesso Não Autorizado", "OK");
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Ops!", "Verifique Sua Conexão de Internet.", "OK");
            }
        }
    }
}

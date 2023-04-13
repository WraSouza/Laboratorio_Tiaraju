using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Laboratorio_Tiaraju.FirebaseServices;
using Laboratorio_Tiaraju.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_Tiaraju.ViewModel
{
    partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        public string name;

        [ObservableProperty]
        public string password;

        [ObservableProperty]
        public bool isbusy;

        [RelayCommand]
        async void Login()
        {
            if(string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Password))
            {
                Mensagem.MensagemObrigatoriedadeCredecnciais();

                return;
            }

            if (Isbusy)
                return;

            try
            {
                bool verificaConexao = Conectividade.VerificaConectividade();

                if (!verificaConexao)
                {
                    Mensagem.MensagemErroConexao();

                    return;
                }

                Isbusy = true;

                var userService = new UserServices();

                Preferences.Set("Nome", Name);

                string departamento = await userService.GetUserDept(Name);

                string status = await userService.GetUserStatus(Name);

                string senhaUsuario = await userService.GetUserSenha(Name);

                Preferences.Set("Departamento", departamento);

                Application.Current.MainPage = new AppShell();
               
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }

        }
    }
}

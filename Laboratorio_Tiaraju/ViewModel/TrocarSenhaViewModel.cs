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
    partial class TrocarSenhaViewModel : ObservableObject
    {
        [ObservableProperty]
        public string novaSenha;

        [ObservableProperty]
        public string confirmaSenha;

        [RelayCommand]
        async void AtualizarSenha()
        {
            bool verificaConexao = Conectividade.VerificaConectividade();

            if((String.IsNullOrEmpty(NovaSenha)) || String.IsNullOrEmpty(ConfirmaSenha))
            {
                Mensagem.MensagemObrigatoriedadeCredecnciais();

                return;
            }

            if (ConfirmaSenha.Equals(NovaSenha))
            {
                if (verificaConexao)
                {
                    UserServices userServices = new UserServices();

                    string nomeUsuario = Preferences.Get("Nome", "default_value");

                    string senhaCriptografada = Criptografia.CriptografaSenha(NovaSenha);

                    bool resultado = await userServices.AtualizarSenha(nomeUsuario, senhaCriptografada);

                    if (resultado)
                    {
                        Mensagem.SenhaAtualizadaComSucesso();

                        Application.Current.MainPage = new AppShell();
                    }

                    return;
                }

                Mensagem.MensagemErroConexao();

                return;
            }

            Mensagem.SenhasNaoConferem();
            
        }
    }
}

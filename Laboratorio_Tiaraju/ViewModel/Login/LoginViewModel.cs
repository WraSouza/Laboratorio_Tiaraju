using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Laboratorio_Tiaraju.FirebaseServices.Implementations.ReadServices.ReadUsuarioServices;
using Laboratorio_Tiaraju.FirebaseServices.Implementations.WriteServices.WriteUsuarioServices;
using Laboratorio_Tiaraju.Model.Entities;
using Laboratorio_Tiaraju.Services.Conection;
using Laboratorio_Tiaraju.Services.Criptography;
using Laboratorio_Tiaraju.Services.Mensagens;
using Laboratorio_Tiaraju.View.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Laboratorio_Tiaraju.ViewModel.Login
{
    partial class LoginViewModel : ObservableObject
    {
        private int count = 0;

        [ObservableProperty]
        public string? name;

        [ObservableProperty]
        public string? password;

        [ObservableProperty]
        public string? isbusy;

        [RelayCommand]
        public async Task Login()
        {

            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Password))
            {
                Mensagem.MensagemObrigatoriedadeCredenciais();

                return;
            }

            Name = Name.Replace(" ", "");

            Preferences.Set("Nome", Name);

            RUsuarioServices userServices = new RUsuarioServices();            

            bool verificaConexao = Conectividade.VerificaConectividade();

            if (verificaConexao)
            {
                Usuario user = await userServices.GetByName(Name);              

                if (user.IsActive == true)
                {

                    if (user.Password.Equals("1234"))
                    {
                        Application.Current.MainPage = new AtualizarSenhaView();

                        return;
                    }

                   WUsuarioServices wUsuarioServices = new WUsuarioServices();                   

                   string senhaCriptografada = Criptografia.CriptografaSenha(Password);

                   bool confirmaLogin = await wUsuarioServices.Login(Name, senhaCriptografada);                    
                    
                    if (confirmaLogin)
                    {
                        Application.Current.MainPage = new AppShell();
                        return;
                    }                       

                    Mensagem.MensagemSenhaInvalida();

                    return;

                }

                Mensagem.MensagemUsuarioSemAutorizacao();

                return;
            }

            Mensagem.MensagemErroConexao();

        }
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Laboratorio_Tiaraju.FirebaseServices;
using Laboratorio_Tiaraju.Services;


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

                Name = Name.Replace(" ", "");

                Isbusy = true;

                var userService = new UserServices();

                bool verificaUsuario = await userService.IsUSerExists(Name);

                if (verificaUsuario)
                {
                    string departamento = await userService.GetUserDept(Name);

                    string statusUsuario = await userService.GetUserStatus(Name);

                    string senhaUsuario = await userService.GetUserSenha(Name);

                    Preferences.Set("Nome", Name);

                    Preferences.Set("Departamento", departamento);
                  

                    if ((senhaUsuario == "1234") && (statusUsuario == "ativo"))
                    {
                        Application.Current.MainPage = new View.TrocarSenhaView();

                        return;
                    }

                    if(statusUsuario == "ativo")
                    {
                        string senhaCriptografada = Criptografia.CriptografaSenha(Password);

                        bool verificaCredenciais = await userService.LoginUser(Name, senhaCriptografada);

                        if (verificaCredenciais)
                        {
                                                       

                            if (statusUsuario == "ativo")
                            {
                                Application.Current.MainPage = new AppShell();

                                return;
                            }

                            Mensagem.MensagemUsuarioSemAutorizacao();

                            return;
                        }
                    }                    
                   
                }

                Mensagem.MensagemSenhaInvalida();                 
               
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
            finally
            {
                Isbusy = false;
            }

        }
    }
}

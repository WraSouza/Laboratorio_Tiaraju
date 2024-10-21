using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Laboratorio_Tiaraju.Model.Entities;
using Laboratorio_Tiaraju.Repositories.Implementations.ReadServices.ReadUsuarioServices;
using Laboratorio_Tiaraju.Repositories.Implementations.WriteServices.WriteUsuarioServices;
using Laboratorio_Tiaraju.Services.Conection;
using Laboratorio_Tiaraju.Services.Criptography;
using Laboratorio_Tiaraju.Services.Mensagens;
using Laboratorio_Tiaraju.Validators;
using Laboratorio_Tiaraju.View.Login;
using Laboratorio_Tiaraju.View.MainViews;


namespace Laboratorio_Tiaraju.ViewModel.Login
{
    public partial class LoginViewModel : ObservableObject
    {

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
        private string? name;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
        public string? password;


        [RelayCommand(CanExecute = nameof(CanExecuteLogin))]
        public async Task Login()
        {
            //var login = new LoginRequest(Name, Password);

            //var contract = new LoginContract(login);

            //if(!contract.IsValid)
            //{
            //    var messages = contract.Notifications.Select(x => x.Message);

            //    var sb = new StringBuilder();

            //    foreach (var message in messages)
            //        sb.Append($"{message}\n");

            //    await Shell.Current.DisplayAlert("Atenção", sb.ToString(), "OK");

            //    return;
            //}

            Name = Name?.Replace(" ", "");

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
                        await Shell.Current.GoToAsync(nameof(AtualizarSenhaView));

                        return;
                    }

                    WUsuarioServices wUsuarioServices = new WUsuarioServices();

                    string senhaCriptografada = Criptografia.CriptografaSenha(Password);

                    bool confirmaLogin = await wUsuarioServices.Login(Name, senhaCriptografada);

                    if (confirmaLogin)
                    {
                        await Shell.Current.GoToAsync($"//{nameof(HomeView)}");

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

        private bool CanExecuteLogin()
        {
            var login = new LoginRequest(Name, Password);

            var contract = new LoginContract(login);

            if (!contract.IsValid)
                return false;

            return true;
        }
    }
}

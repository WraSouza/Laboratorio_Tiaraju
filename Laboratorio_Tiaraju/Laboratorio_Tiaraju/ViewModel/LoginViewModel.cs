using Laboratorio_Tiaraju.FirebaseServices;
using Laboratorio_Tiaraju.Model;
using Laboratorio_Tiaraju.View.Master;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Laboratorio_Tiaraju.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private string _Nome;
        private string _Senha;
        private bool _Result;
        private bool _IsBusy;       

        public Command LoginCommand { get; set; }

        public string Nome
        {
            get
            {
                return this._Nome;
            }
            set
            {
                this._Nome = value;
                OnPropertyChanged();
            }
        }

        public string Senha
        {
            get
            {
                return this._Senha;
            }
            set
            {
                this._Senha = value;
                OnPropertyChanged();
            }
        }

        //Método para verificar se o login foi realizado com sucesso
        public bool Result
        {
            get
            {
                return this._IsBusy;
            }
            set
            {
                this._IsBusy = value;
                OnPropertyChanged();
            }
        }

        //Método para verificar se o login está sendo realizado para evitar concorrência
        public bool IsBusy
        {
            get
            {
                return this._Result;
            }
            set
            {
                this._Result = value;
                OnPropertyChanged();
            }
        }

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await LoginCommandAsync()); //Nome do comando, qualquer um nome de preferência            
        }

        //Login
        private async Task LoginCommandAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var userService = new UserServices();
                Result = await userService.LoginUser(Nome, Senha);

                if (Result)
                {                    
                    Preferences.Set("Nome", Nome.ToUpper());
                    
                    if(Nome !="wladimir")
                    {
                        App.Current.MainPage = new View.Master.MenuView();
                    }
                    else
                    {
                        App.Current.MainPage = new View.AppShell();
                        //App.Current.MainPage = new View.Menu.MenuView();
                    }
                                        
                                       
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Erro", "Usuário/Senha Inválidos", "OK");
                }

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}

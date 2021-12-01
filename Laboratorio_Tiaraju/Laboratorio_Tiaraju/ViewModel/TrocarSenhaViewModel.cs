using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Laboratorio_Tiaraju.ViewModel
{
    public class TrocarSenhaViewModel : BaseViewModel
    {
        private string _Senha;

        public Command AlterarSenha { get; set; }

        public string Senha
        {
            get => _Senha;
            set
            {
                _Senha = value;
                OnPropertyChanged();
            }
        }
    }
}

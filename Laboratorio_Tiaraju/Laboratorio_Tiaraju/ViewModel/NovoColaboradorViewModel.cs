using Laboratorio_Tiaraju.Model;
using Laboratorio_Tiaraju.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Laboratorio_Tiaraju.ViewModel
{
    internal class NovoColaboradorViewModel : BaseViewModel
    {
        private string _nomeColaborador;
        private DateTime _dataNascimento;
        private DateTime _dataAdmissao;
        private string _cargo;
        private string _setor;

        public Command CadastraColaboradorCommand { get; set; }

        public NovoColaboradorViewModel()
        {
            CadastraColaboradorCommand = new Command(async () => await CadastrarCommandAsync());
        }

        public string NomeColaborador
        {
            get => _nomeColaborador;
            set
            {
                _nomeColaborador = value;
                OnPropertyChanged();
            }
        }

        public DateTime DataNascimento
        {
            get => _dataNascimento;
            set
            {
                _dataNascimento = value;
                OnPropertyChanged();
            }
        }

        public DateTime DataAdmissao
        {
            get => _dataAdmissao;
            set
            {
                _dataAdmissao = value;
                OnPropertyChanged();
            }
        }

        public string Cargo
        {
            get => _cargo;
            set
            {
                _cargo = value;
                OnPropertyChanged();
            }
        }

        public string Setor
        {
            get => _setor;
            set
            {
                _setor = value;
                OnPropertyChanged();
            }
        }

        private async Task CadastrarCommandAsync()
        {
            bool verificaConectividade = Conectividade.VerificaConectividade();

            if (verificaConectividade)
            {
                Colaborador novoColaborador = new Colaborador();
                novoColaborador.NomeColaborador = NomeColaborador;
                novoColaborador.DataAdmissao = DataAdmissao;
                novoColaborador.DataNascimento = DataNascimento;
                novoColaborador.Setor = Setor;
                novoColaborador.Cargo = Cargo;                

            }
        }

        
    }
}

using Laboratorio_Tiaraju.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Laboratorio_Tiaraju.ViewModel
{
    public class AprovarBooksViewModel : BaseViewModel
    {
        private DateTime _dataReuniao;
        private TimeSpan _horaInicioReuniao;
        private TimeSpan _horaFimReuniao;
        private int _qtdePessoas;
        private string _colaborador;
        private string _motivo;
        //private string _autorizacao = "Pendente";

        public Command AprovarReservaCommand { get; set; }

        public DateTime DataReuniao
        {
            get
            {
                return this._dataReuniao;
            }
            set
            {
                this._dataReuniao = value;
                OnPropertyChanged();
            }
        }

        public TimeSpan HoraInicioReuniao
        {
            get
            {
                return this._horaInicioReuniao;
            }
            set
            {
                this._horaInicioReuniao = value;
                OnPropertyChanged();
            }
        }

        public TimeSpan HoraFimReuniao
        {
            get
            {
                return this._horaFimReuniao;
            }
            set
            {
                this._horaFimReuniao = value;
                OnPropertyChanged();
            }
        }

        public int QtdePessoas
        {
            get
            {
                return this._qtdePessoas;
            }
            set
            {
                this._qtdePessoas = value;
                OnPropertyChanged();
            }
        }

        public string Colaborador
        {
            get
            {
                return this._colaborador;
            }
            set
            {
                this._colaborador = value;
                OnPropertyChanged();
            }
        }

        public string MotivoReuniao
        {
            get
            {
                return this._motivo;
            }
            set
            {
                this._motivo = value;
                OnPropertyChanged();
            }
        }

        public AprovarBooksViewModel()
        {
            AprovarReservaCommand = new Command( () => AprovarCommandAsync());
        }

        private void AprovarCommandAsync()
        {
            MeetingRoom meet = new MeetingRoom();

            //string hora = HoraFimReuniao.ToString();
            //string motivo = MotivoReuniao;

            meet.HoraInicioReuniao = HoraInicioReuniao.ToString();
            meet.HoraFimReuniao = HoraFimReuniao.Hours.ToString();
            meet.QtdePessoas = _qtdePessoas;
            meet.MotivoReuniao = MotivoReuniao;
        }
    }
}

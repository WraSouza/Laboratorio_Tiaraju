using Laboratorio_Tiaraju.FirebaseServices;
using Laboratorio_Tiaraju.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Laboratorio_Tiaraju.ViewModel
{
    public class MeetingRoomBookViewModel : BaseViewModel
    {
        private DateTime _dataReuniao;
        private TimeSpan _horaInicioReuniao;
        private TimeSpan _horaFimReuniao;
        private int _qtdePessoas;
        private string _colaborador;
        private string _motivo;
        private string _autorizacao = "Pendente";

        public Command SolicitaReservaCommand { get; set; }

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
        

        public MeetingRoomBookViewModel()
        {

            SolicitaReservaCommand = new Command(() => ReservaCommandAsync());
        }

        private async void ReservaCommandAsync()
        {            
            MeetingRoom meet = new MeetingRoom();
            meet.DataReuniao = _dataReuniao.Date.ToString("dd-MM-yyyy");
            meet.HoraInicioReuniao = _horaInicioReuniao.ToString();
            meet.HoraFimReuniao = _horaFimReuniao.ToString();
            meet.QtdePessoas = _qtdePessoas;
            meet.Colaborador = Preferences.Get("Nome", "default_value");
            meet.MotivoReuniao = _motivo;
            meet.StatusAutorizacao = _autorizacao;

            var newMeet = new MeetingRoomServices();

            await newMeet.ReservaSalaReuniao(meet);
        }


        //public Command ExitCommand { get; set; }

        //public MeetingRoomBookViewModel()
        //{
        //    ExitCommand = new Command( () => OpenMainView());
        //}

        //private void OpenMainView()
        //{
        //    App.Current.MainPage = new View.AppShell();
        //}
    }
}

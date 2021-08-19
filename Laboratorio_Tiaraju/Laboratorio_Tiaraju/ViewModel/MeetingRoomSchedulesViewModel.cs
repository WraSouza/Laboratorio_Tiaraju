using Laboratorio_Tiaraju.FirebaseServices;
using Laboratorio_Tiaraju.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Laboratorio_Tiaraju.ViewModel
{
    public class MeetingRoomSchedulesViewModel : BaseViewModel
    {       
        private DateTime _dataSelecionada;
        //private DateTime _dataReuniao;
        private TimeSpan _horaInicioReuniao;
        private TimeSpan _horaFimReuniao;
        private int _qtdePessoas;
        private string _colaborador;
        private string _motivo;
       // private string _autorizacao;

        public Command VerificaReservaCommand { get; set; }

        public DateTime DataSelecionada
        {
            get
            {
                return _dataSelecionada;
            }
            set
            {
                this._dataSelecionada = value;
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

        public MeetingRoomSchedulesViewModel()
        {
            VerificaReservaCommand = new Command( async () => await BuscaReservasAgendadas());
        }

        private async Task<List<MeetingRoom>> BuscaReservasAgendadas()
        {
            MeetingRoomServices meetingroom = new MeetingRoomServices();
            var horariosAgendados = await meetingroom.GetBooks(DataSelecionada);
            
            return horariosAgendados;
        }
    }
}

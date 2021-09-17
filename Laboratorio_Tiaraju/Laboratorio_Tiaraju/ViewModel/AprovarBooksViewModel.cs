using Laboratorio_Tiaraju.FirebaseServices;
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
        private string _autorizacao = "Autorizado";
        MeetingRoomServices mrs = new MeetingRoomServices();

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
            AprovarReservaCommand = new Command<MeetingRoom>( (model) => AprovarCommandAsync(model));
        }

        private void AprovarCommandAsync(MeetingRoom model)
        {
            if (model is null)
                return;

            MeetingRoom meet = new MeetingRoom();             

            meet.HoraInicioReuniao = model.HoraInicioReuniao.ToString();
            meet.HoraFimReuniao = model.HoraFimReuniao.ToString();
            meet.QtdePessoas = model.QtdePessoas;
            meet.MotivoReuniao = model.MotivoReuniao;
            meet.Colaborador = model.Colaborador;
            meet.StatusAutorizacao = _autorizacao;
            meet.DataReuniao = model.DataReuniao.ToString();

            var autoriza = mrs.AutorizaSalaReuniao(meet);

            mrs.ReservasPorData(model.DataReuniao);
        }
    }
}

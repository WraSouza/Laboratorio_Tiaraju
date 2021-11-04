using Laboratorio_Tiaraju.FirebaseServices;
using Laboratorio_Tiaraju.Model;
using Laboratorio_Tiaraju.View.Menu;
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
        public Command RejeitarReservaCommand { get; set; }

        public DateTime DataReuniao
        {
            get => _dataReuniao;
            set
            {
                _dataReuniao = value;
                OnPropertyChanged();
            }
        }

        public TimeSpan HoraInicioReuniao
        {
            get => _horaInicioReuniao;
            set
            {
                _horaInicioReuniao = value;
                OnPropertyChanged();
            }
        }

        public TimeSpan HoraFimReuniao
        {
            get => _horaFimReuniao;
            set
            {
                _horaFimReuniao = value;
                OnPropertyChanged();
            }
        }

        public int QtdePessoas
        {
            get => _qtdePessoas;
            set
            {
                _qtdePessoas = value;
                OnPropertyChanged();
            }
        }

        public string Colaborador
        {
            get => _colaborador;
            set
            {
                _colaborador = value;
                OnPropertyChanged();
            }
        }

        public string MotivoReuniao
        {
            get => _motivo;
            set
            {
                _motivo = value;
                OnPropertyChanged();
            }
        }

        public AprovarBooksViewModel()
        {
            AprovarReservaCommand = new Command<MeetingRoom>( (model) => AprovarCommandAsync(model));
            RejeitarReservaCommand = new Command<MeetingRoom>((model) => RejeitarCommandAsync(model));
        }

        private async void AprovarCommandAsync(MeetingRoom model)
        {
            if (model is null)
            {
                return;
            }

            MeetingRoom meet = new MeetingRoom();             

            meet.HoraInicioReuniao = model.HoraInicioReuniao.ToString();
            meet.HoraFimReuniao = model.HoraFimReuniao.ToString();
            meet.QtdePessoas = model.QtdePessoas;
            meet.MotivoReuniao = model.MotivoReuniao;
            meet.Colaborador = model.Colaborador;
            meet.StatusAutorizacao = _autorizacao;
            meet.DataReuniao = model.DataReuniao.ToString();

            Task<bool> autoriza = mrs.AutorizarSalaReuniao(meet);

            await Application.Current.MainPage.DisplayAlert("Sucesso", "Solicitação Autorizada Com Sucesso", "OK");           
        }

        private async void RejeitarCommandAsync(MeetingRoom model)
        {
            if (model is null)
            {
                return;
            }

            MeetingRoom meet = new MeetingRoom();

            meet.HoraInicioReuniao = model.HoraInicioReuniao.ToString();
            meet.HoraFimReuniao = model.HoraFimReuniao.ToString();
            meet.QtdePessoas = model.QtdePessoas;
            meet.MotivoReuniao = model.MotivoReuniao;
            meet.Colaborador = model.Colaborador;
            meet.StatusAutorizacao = _autorizacao;
            meet.DataReuniao = model.DataReuniao.ToString();

            bool autoriza = await mrs.AutorizarSalaReuniao(meet);

           
        }
    }
}

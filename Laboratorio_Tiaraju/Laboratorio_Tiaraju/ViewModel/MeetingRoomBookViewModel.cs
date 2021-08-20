using Laboratorio_Tiaraju.FirebaseServices;
using Laboratorio_Tiaraju.Model;
using Laboratorio_Tiaraju.Services;
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
            bool verificaDados;

            //Verificar se a data selecionada maior que dia atual
            verificaDados = DataHora.VerificaDataReuniao(Convert.ToInt32(_dataReuniao.Day));

            if (verificaDados)
            {

                if (verificaDados)
                {
                    //Verifica se a Hora Final é Maior ou Igual a Hora Inicial
                    verificaDados = DataHora.VerificaHoraFimEInicio(_horaInicioReuniao, _horaFimReuniao);

                    if (verificaDados)
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

                        await Application.Current.MainPage.DisplayAlert("Info", "Sua Solicitação Foi Inserida Com Sucesso", "Ok");
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Erro", "A Hora Fim Deve Ser Maior que a Hora Inicial", "Ok");
                    }

                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Erro", "A Hora Deve Ser Maior ou Igual a Hora Atual.", "Ok");
                }

            }else
            {
                verificaDados = DataHora.VerificaSeDiaIgualHoje(_dataReuniao.Day);

                if (verificaDados)
                {
                     int horaInicio = _horaInicioReuniao.Hours;
                     int horaAtual = DateTime.Now.Hour;
                    
                    if(horaInicio == horaAtual)
                    {
                        if(_horaInicioReuniao.Minutes < DateTime.Now.Minute)
                        {
                            await Application.Current.MainPage.DisplayAlert("Erro", "A Hora Inicial Deve Ser Maior que Hora Atual.", "Ok");
                        }
                        else
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

                            await Application.Current.MainPage.DisplayAlert("Info", "Sua Solicitação Foi Inserida Com Sucesso", "Ok");
                        }                       
                    }
                    else if(horaInicio > horaAtual)
                    {
                        if(_horaFimReuniao < _horaInicioReuniao)
                        {
                            await Application.Current.MainPage.DisplayAlert("Erro", "A Hora Final Deve Ser Maior que Hora Inicial.", "Ok");
                        }
                        else
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

                            await Application.Current.MainPage.DisplayAlert("Info", "Sua Solicitação Foi Inserida Com Sucesso", "Ok");
                        }
                       
                    }
                    else if(horaInicio < horaAtual)
                    {
                        await Application.Current.MainPage.DisplayAlert("Erro", "A Hora Inicial Deve Ser Maior que Hora Atual.", "Ok");
                    }
                    else if(_horaFimReuniao > _horaInicioReuniao)
                    {
                        await Application.Current.MainPage.DisplayAlert("Erro", "A Hora Final Deve Ser Maior que Hora Inicial.", "Ok");
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Erro", "A Data Não Pode Ser Anterior a Data Atual.", "Ok");
                }
            }

        }

        



    }
}

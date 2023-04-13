using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Laboratorio_Tiaraju.FirebaseServices;
using Laboratorio_Tiaraju.Model;
using Laboratorio_Tiaraju.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_Tiaraju.ViewModel
{
    partial class CalendarioCQDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        public bool isbusy;

        [RelayCommand]
        async void FinalizarCalendario(CalendarioCQ model)
        {
            bool verificaConexao = Conectividade.VerificaConectividade();

            if (verificaConexao)
            {
                if (Isbusy)
                    return;

                try
                {
                    CalendarioCQServices calendarioServices = new CalendarioCQServices();
                    string descricao = model.Descricao;
                    int dia = model.Dia;
                    string mes = model.Mes;
                    string finalizadoPor = Preferences.Get("Nome", "default_value");
                    string diaFinalizacao = DateTime.Today.ToShortDateString();

                    bool verificaStatusCalendario = await calendarioServices.GetCalendarioCQStatus(dia, mes, descricao);

                    if (verificaStatusCalendario)
                    {

                        await Application.Current.MainPage.DisplayAlert("Info", "Evento Já Foi Finalizado", "OK");
                    }
                    else
                    {
                        bool answer = await Application.Current.MainPage.DisplayAlert("", "Deseja Finalizar a Atividade?", "Sim", "Não");

                        if (answer)
                        {
                            bool confirmaStatusAlterado = await calendarioServices.FinalizarCalendario(dia, mes, descricao, finalizadoPor, diaFinalizacao);

                            if (confirmaStatusAlterado)
                            {
                                Mensagem.AtividadeFinalizadaComSucesso();
                            }
                        }
                        
                    }
                }
                catch (Exception e)
                {
                    await Application.Current.MainPage.DisplayAlert("Ops!", e.Message, "OK");
                }
                finally
                {
                    Isbusy = false;
                }
            }
            else
            {
                Mensagem.MensagemErroConexao();
            }

        }
    }
}

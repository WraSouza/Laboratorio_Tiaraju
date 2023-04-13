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
    partial class CadastroCalendarioCQViewModel : ObservableObject
    {
        private string _mes;
        [ObservableProperty]
        public string title;

        [ObservableProperty]
        public DateTime datacoleta;

        [ObservableProperty]
        public string description;

        [RelayCommand]
        async void SaveCalendar()
        {
            bool verificaConexao = Conectividade.VerificaConectividade();

            _mes = Datacoleta.ToString("MMMM").ToUpper();

            if (verificaConexao)
            {
                var calendarioService = new CalendarioCQServices();

                if (Description == null)
                {
                    var novoCalendario = new CalendarioCQ()
                    {

                        Dia = Datacoleta.Day,
                        Mes = _mes,
                        Descricao = " ",
                        IsFinished = false,
                        IsExcluded = false,
                        FinalizadoPor = " ",
                        MotivoExclusao = " ",
                        Titulo = Title,
                        DataFinalizacao = DateTime.Today.ToShortDateString(),
                        Ano = Datacoleta.Year

                    };

                    bool verificaData = DataHora.VerificaData(Datacoleta);

                    if (verificaData)
                    {

                        bool verificaSeExiste = await calendarioService.IsCalendarioCQExists(novoCalendario);

                        if (verificaSeExiste)
                        {
                            Mensagem.MensagemEventoJaCadastrado();
                        }
                        else
                        {
                            bool confirmaCadastro = await calendarioService.CadastrarDadosCalendario(novoCalendario);

                            if (confirmaCadastro)
                            {
                                Mensagem.MensagemCadastroSucesso();
                            }

                        }

                    }
                    else
                    {
                        Mensagem.MensagemDataDeveSerMaior();
                    }

                }
                else
                {
                    var novoCalendario = new CalendarioCQ()
                    {

                        Dia = Datacoleta.Day,
                        Mes = _mes,
                        Descricao = Description,
                        IsFinished = false,
                        IsExcluded = false,
                        FinalizadoPor = " ",
                        MotivoExclusao = " ",
                        Titulo = Title,
                        DataFinalizacao = DateTime.Today.ToShortDateString(),
                        Ano = DateTime.Now.Year

                    };

                    bool verificaData = DataHora.VerificaData(Datacoleta);

                    if (verificaData)
                    {

                        bool verificaSeExiste = await calendarioService.IsCalendarioCQExists(novoCalendario);

                        if (verificaSeExiste)
                        {
                            Mensagem.MensagemEventoJaCadastrado();
                        }
                        else
                        {
                            bool confirmaCadastro = await calendarioService.CadastrarDadosCalendario(novoCalendario);

                            if (confirmaCadastro)
                            {
                                Mensagem.MensagemCadastroSucesso();
                            }

                        }

                    }
                    else
                    {
                        Mensagem.MensagemDataDeveSerMaior();
                    }
                }
            }
            else
            {
                Mensagem.MensagemErroConexao();
            }

        }
    }
}

using Firebase.Database;
using Firebase.Database.Query;
using Laboratorio_Tiaraju.Model;
using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_Tiaraju.FirebaseServices
{
    public class CalendarioCQServices
    {
        FirebaseClient firebase;

        public CalendarioCQServices()
        {
            firebase = new FirebaseClient("https://tiaraju-afa0a-default-rtdb.firebaseio.com/");
        }

        public async Task<bool> CadastrarDadosCalendario(CalendarioCQ calendario)
        {
            await firebase.Child("CalendarioCQ")
                .PostAsync(new CalendarioCQ()
                {
                    Dia = calendario.Dia,
                    Mes = calendario.Mes,
                    Descricao = calendario.Descricao,
                    IsFinished = calendario.IsFinished,
                    IsExcluded = calendario.IsExcluded,
                    FinalizadoPor = calendario.FinalizadoPor,
                    MotivoExclusao = " ",
                    Titulo = calendario.Titulo,
                    DataFinalizacao = calendario.DataFinalizacao,
                    Ano = calendario.Ano
                });

            return true;
        }

        public async Task<bool> IsCalendarioCQExists(CalendarioCQ calendario)
        {
            var evento = (await firebase.Child("CalendarioCQ")
                .OnceAsync<CalendarioCQ>())
                .Where(u => u.Object.Dia == calendario.Dia && u.Object.Mes == calendario.Mes && u.Object.Descricao == calendario.Descricao)
                .FirstOrDefault();

            return (evento != null);
        }

        public async Task<List<CalendarioCQ>> RetornaInformacoes()
        {
            return (await firebase.Child("CalendarioCQ")
                .OnceAsync<CalendarioCQ>()).Select(item => new CalendarioCQ
                {
                    Dia = item.Object.Dia,
                    Mes = item.Object.Mes,
                    Descricao = item.Object.Descricao,
                    IsFinished = item.Object.IsFinished,
                    IsExcluded = item.Object.IsExcluded,
                    FinalizadoPor = item.Object.FinalizadoPor,
                    MotivoExclusao = item.Object.MotivoExclusao,
                    Titulo = item.Object.Titulo,
                    Ano = item.Object.Ano

                }).ToList();
        }

        public async Task<List<CalendarioCQ>> RetornaCalendariosNaoFinalizados()
        {
            var todosCalendarios = await RetornaInformacoes();
            int currentYear = DateTime.Now.Year;

            await firebase
                .Child("CalendarioCQ")
                .OnceAsync<CalendarioCQ>();

            return todosCalendarios.Where(m => m.IsFinished == false && m.IsExcluded == false && m.Ano == currentYear).ToList();
        }

        public async Task<List<CalendarioCQ>> RetornaCalendarioEspecifico(int dia, string mes, string descricao)
        {
            var calendarios = await RetornaInformacoes();
            await firebase
                .Child("CalendarioCQ")
                .OnceAsync<CalendarioCQ>();

            return calendarios.Where(a => a.Dia == dia && a.Mes == mes && a.Descricao == descricao && a.IsExcluded == false && a.IsFinished == false).ToList();
        }

        //Finalizar Calendário Selecionado
        public async Task<bool> FinalizarCalendario(int dia, string mes, string descricao, string finalizadoPor, string dataFinalizacao)
        {
            var calendarios = await RetornaInformacoes();
            var toUpdateCalendar = (await firebase
              .Child("CalendarioCQ")
              .OnceAsync<CalendarioCQ>()).Where(a => a.Object.Dia == dia && a.Object.Mes == mes && a.Object.Descricao == descricao).FirstOrDefault();

            toUpdateCalendar.Object.IsFinished = true;
            toUpdateCalendar.Object.FinalizadoPor = finalizadoPor;
            toUpdateCalendar.Object.DataFinalizacao = dataFinalizacao;

            await firebase
           .Child("CalendarioCQ")
           .Child(toUpdateCalendar.Key)
           .PutAsync(toUpdateCalendar.Object);

            return true;
        }

        public async Task<bool> GetCalendarioCQStatus(int dia, string mes, string descricao)
        {
            var user = (await firebase.Child("CalendarioCQ")
               .OnceAsync<CalendarioCQ>())
               .Where(u => u.Object.Dia == dia && u.Object.Mes == mes && u.Object.Descricao == descricao)
               .FirstOrDefault();

            return user.Object.IsFinished;
        }

        //Retornar calendários finalizados
        public async Task<List<CalendarioCQ>> RetornaCalendariosFinalizados()
        {
            var todosCalendarios = await RetornaInformacoes();
            int currentYear = DateTime.Now.Year;

            await firebase
                .Child("CalendarioCQ")
                .OnceAsync<CalendarioCQ>();

            return todosCalendarios.Where(m => m.IsFinished == true && m.IsExcluded == false && m.Ano == currentYear).ToList();
        }

        //Retorna Calendários Excluídos
        public async Task<List<CalendarioCQ>> RetornaCalendariosExcluidos()
        {
            var todosCalendarios = await RetornaInformacoes();
            int currentYear = DateTime.Now.Year;

            await firebase
                .Child("CalendarioCQ")
                .OnceAsync<CalendarioCQ>();

            return todosCalendarios.Where(m => m.IsExcluded == true && m.Ano == currentYear).ToList();
        }

    }
}

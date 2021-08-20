using Firebase.Database;
using Firebase.Database.Query;
using Laboratorio_Tiaraju.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_Tiaraju.FirebaseServices
{
    public class MeetingRoomServices
    {
        FirebaseClient firebase;        

        public MeetingRoomServices()
        {
            firebase = new FirebaseClient("https://tiaraju-afa0a-default-rtdb.firebaseio.com/");
        }

        public async Task ReservaSalaReuniao(MeetingRoom meetingroomdata)
        {
            await firebase.Child("MeetingRoom")
                   .PostAsync(new MeetingRoom()
                   {
                       DataReuniao = meetingroomdata.DataReuniao,
                       HoraInicioReuniao = meetingroomdata.HoraInicioReuniao,
                       HoraFimReuniao = meetingroomdata.HoraFimReuniao,
                       QtdePessoas = meetingroomdata.QtdePessoas,
                       Colaborador = meetingroomdata.Colaborador,
                       MotivoReuniao = meetingroomdata.MotivoReuniao,
                       StatusAutorizacao = meetingroomdata.StatusAutorizacao
                   });
        }

        public async Task<List<MeetingRoom>> GetBooks()
        {
            return (await firebase.Child("MeetingRoom")
                .OnceAsync<MeetingRoom>()).Select(item => new MeetingRoom
                {
                    DataReuniao = item.Object.DataReuniao,
                    HoraInicioReuniao = item.Object.HoraInicioReuniao,
                    HoraFimReuniao = item.Object.HoraFimReuniao,
                    QtdePessoas = item.Object.QtdePessoas,
                    Colaborador = item.Object.Colaborador,
                    MotivoReuniao = item.Object.MotivoReuniao,
                    StatusAutorizacao = item.Object.StatusAutorizacao

                }).ToList();
        }

        public async Task<List<MeetingRoom>> ReservasPorData(string _dataReuniao)
        {
            var reuniao = await GetBooks();

            await firebase.Child("MeetingRoom")
                .OnceAsync<MeetingRoom>();

            return reuniao.Where(item => item.DataReuniao == _dataReuniao).ToList();
        }

    }
    }

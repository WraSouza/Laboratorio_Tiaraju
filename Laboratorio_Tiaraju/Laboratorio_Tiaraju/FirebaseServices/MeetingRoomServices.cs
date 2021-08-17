using Firebase.Database;
using Firebase.Database.Query;
using Laboratorio_Tiaraju.Model;
using System;
using System.Collections.Generic;
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
                       MotivoReuniao = meetingroomdata.MotivoReuniao
                   });
        }
    }
}

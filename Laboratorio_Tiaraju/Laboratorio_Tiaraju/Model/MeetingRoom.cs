using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_Tiaraju.Model
{
    public class MeetingRoom
    {
        public string DataReuniao { get; set; }
        public string HoraInicioReuniao { get; set; }
        public string HoraFimReuniao { get; set; }
        public int QtdePessoas { get; set; }
        public string Colaborador { get; set; }
        public string MotivoReuniao { get; set; }
        public string StatusAutorizacao { get; set; }
    }
}

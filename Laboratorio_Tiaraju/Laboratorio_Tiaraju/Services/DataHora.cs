using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_Tiaraju.Services
{
    public class DataHora
    {
        public static bool VerificaHoraFimEInicio(TimeSpan _horaInicio, TimeSpan _horaFim)
        {
            bool verificado = false;

            if(_horaFim > _horaInicio)
            {
                verificado = true;
            }

            return verificado;
        }

        public static bool VerificaHoraInicio(int _horaInicio)
        {
            bool verificado = false;

            if(_horaInicio > DateTime.Now.Hour)
            {
                verificado = true;
            }

            return verificado;
        }
        
        public static bool VerificaSeDiaIgualHoje(int _dataReuniao)
        {
            bool verificado = false;

            if(_dataReuniao == DateTime.Now.Day)
            {
                verificado = true;
            }

            return verificado;
        }

        public static bool VerificaDataReuniao(int _dataReuniao)
        {
            bool verificado = false;

            if(_dataReuniao > DateTime.Now.Day)
            {
                verificado = true;
            }
            return verificado;
        }
    }
}

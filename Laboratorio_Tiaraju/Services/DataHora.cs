using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_Tiaraju.Services
{
    public class DataHora
    {
        public static bool VerificaData(DateTime dataDesejada)
        {
            bool confirmacao = false;

            if (dataDesejada >= DateTime.Today)
            {
                confirmacao = true;
            }

            return confirmacao;
        }
    }
}

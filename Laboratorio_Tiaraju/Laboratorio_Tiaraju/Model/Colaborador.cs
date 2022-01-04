using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_Tiaraju.Model
{
    internal class Colaborador
    {
        public string NomeColaborador { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataAdmissao { get; set; }
        public string Cargo { get; set; }
        public string Setor { get; set; }
    }
}

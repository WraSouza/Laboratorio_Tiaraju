using Firebase.Database;
using Firebase.Database.Query;
using Laboratorio_Tiaraju.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_Tiaraju.FirebaseServices
{
    internal class ColaboradorService
    {
        FirebaseClient firebase;

        public ColaboradorService()
        {
            firebase = new FirebaseClient("https://tiaraju-afa0a-default-rtdb.firebaseio.com/");
        }

        public async Task AdicionarColaborador(Colaborador colaborador)
        {
            await firebase.Child("Colaborador")
                   .PostAsync(new Colaborador()
                   {
                       NomeColaborador = colaborador.NomeColaborador,
                       DataNascimento = colaborador.DataNascimento,
                       DataAdmissao = colaborador.DataAdmissao,
                       Cargo = colaborador.Cargo,
                       Setor = colaborador.Setor
                   });
        }
    }
}

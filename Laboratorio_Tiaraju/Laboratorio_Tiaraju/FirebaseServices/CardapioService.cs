using Firebase.Database;
using Laboratorio_Tiaraju.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_Tiaraju.FirebaseServices
{
    internal class CardapioService
    {
        FirebaseClient firebase;

        public CardapioService()
        {
            firebase = new FirebaseClient("gs://tiaraju-afa0a.appspot.com");
        }

        //public async Task<Cardapio> RetornaCardapio()
        //{

        //    return (Cardapio)(await firebase.Child("Cardapio")
        //        .OnceAsync<Cardapio>()).Select(item => new Cardapio
        //        {
        //            Imagem = item.Object.Imagem
        //        });
        //}
    }
}

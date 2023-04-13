using Firebase.Database;
using Laboratorio_Tiaraju.Model;
using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_Tiaraju.FirebaseServices
{
    public class UserServices
    {
        FirebaseClient firebase;

        public UserServices()
        {
            firebase = new FirebaseClient("https://tiaraju-afa0a-default-rtdb.firebaseio.com/");
        }

        public async Task<string> GetUserDept(string name)
        {
            var user = (await firebase.Child("Usuario")
               .OnceAsync<Usuario>())
               .Where(u => u.Object.NomeUsuario == name)
               .FirstOrDefault();

            return user.Object.Departamento;
        }

        public async Task<string> GetUserStatus(string name)
        {
            var user = (await firebase.Child("Usuario")
               .OnceAsync<Usuario>())
               .Where(u => u.Object.NomeUsuario == name)
               .FirstOrDefault();

            return user.Object.Status;
        }

        public async Task<string> GetUserSenha(string name)
        {
            var user = (await firebase.Child("Usuario")
               .OnceAsync<Usuario>())
               .Where(u => u.Object.NomeUsuario == name)
               .FirstOrDefault();

            return user.Object.Senha;
        }
    }
}

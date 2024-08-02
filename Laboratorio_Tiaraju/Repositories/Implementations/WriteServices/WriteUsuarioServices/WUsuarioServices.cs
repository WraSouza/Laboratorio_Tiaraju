using Firebase.Database;
using Laboratorio_Tiaraju.Model.Entities;
using Laboratorio_Tiaraju.Repositories.Interfaces.IWriteServices.IWriteUsuarioServices;
using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_Tiaraju.Repositories.Implementations.WriteServices.WriteUsuarioServices
{
    public class WUsuarioServices : IWUsuarioServices
    {
        FirebaseClient firebase;

        public WUsuarioServices()
        {
            firebase = new FirebaseClient("https://laboratoriotiaraju-6c89e-default-rtdb.firebaseio.com/");
        }
        public void AddUser(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Login(string username, string password)
        {
            var user = (await firebase.Child("Usuario")
               .OnceAsync<Usuario>())
               .Where(u => u.Object.UserName == username)
               .Where(u => u.Object.Password == password)
               .FirstOrDefault();


            return user != null;
        }

        public void UpdateStatus(bool status, string username)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}

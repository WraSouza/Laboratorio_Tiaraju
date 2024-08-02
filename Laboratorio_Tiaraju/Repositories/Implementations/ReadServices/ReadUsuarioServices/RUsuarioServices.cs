using Firebase.Database;
using Laboratorio_Tiaraju.Model.Entities;
using Laboratorio_Tiaraju.Repositories.Interfaces.IReadServices.IReadUsuarioServices;
using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_Tiaraju.Repositories.Implementations.ReadServices.ReadUsuarioServices
{
    public class RUsuarioServices : IRUsuarioServices
    {
        FirebaseClient firebase;
        public RUsuarioServices()
        {
            firebase = new FirebaseClient("https://laboratoriotiaraju-6c89e-default-rtdb.firebaseio.com/");
        }
        public async Task<List<Usuario>> GetAll()
        {
            return (await firebase.Child("Usuario")
                .OnceAsync<Usuario>()).Select(item => new Usuario
                {
                    Name = item.Object.Name,
                    UserName = item.Object.UserName,
                    IsActive = item.Object.IsActive,
                    Password = item.Object.Password,
                    Departments = item.Object.Departments,

                }).ToList();
        }

        public Task<Usuario> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> GetByName(string name)
        {
            var users = await GetAll();

            await firebase
               .Child("Usuario")
               .OnceAsync<Usuario>();

            var selectedUser = users.Where(x => x.UserName == name).FirstOrDefault();

            return selectedUser;
        }
    }
}

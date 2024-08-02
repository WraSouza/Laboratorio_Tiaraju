using Laboratorio_Tiaraju.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_Tiaraju.Repositories.Interfaces.IWriteServices.IWriteUsuarioServices
{
    public interface IWUsuarioServices
    {
        void AddUser(Usuario usuario);

        void UpdateUser(Usuario usuario);

        void UpdateStatus(bool status, string username);

        Task<bool> Login(string username, string password);
    }
}

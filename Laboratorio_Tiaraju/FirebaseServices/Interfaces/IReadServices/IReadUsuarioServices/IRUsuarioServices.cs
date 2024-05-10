using Laboratorio_Tiaraju.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_Tiaraju.FirebaseServices.Interfaces.IReadServices.IReadUsuarioServices
{
    public interface IRUsuarioServices
    {
        Task<List<Usuario>> GetAll();

        Task<Usuario> GetById(int id);

        Task<Usuario> GetByName(string name);
    }
}

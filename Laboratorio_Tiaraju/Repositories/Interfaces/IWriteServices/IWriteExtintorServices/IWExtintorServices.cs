using Laboratorio_Tiaraju.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_Tiaraju.Repositories.Interfaces.IWriteServices.IWriteExtintorServices
{
    public interface IWExtintorServices
    {
        Task AdicionarExtintor(Extintor extintor);
        void UpdateExtintor(Extintor extintor);

    }
}

using MyVid.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVid.Core.Repositories
{
    public interface IContenidoRepository : IRepository<Contenido>
    {
        Task<IEnumerable<Contenido>> GetContenidosByTipoAsync(string tipo);
        Task<IEnumerable<Contenido>> GetContenidosByGeneroAsync(int generoId);
        // Otros métodos específicos de Contenido
    }
}

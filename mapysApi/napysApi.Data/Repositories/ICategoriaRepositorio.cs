using mapysApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mapysApi.Data.Repositories
{
    public interface ICategoriaRepositorio
    {
        Task<IEnumerable<Categoria>> GetAllCategorias();
    }
}

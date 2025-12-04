using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain.entities;

namespace domain.interfaces.Irepos
{
    public interface IUserRepo
    {
        void Create(Usuario usuario);
        Usuario Read(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(Usuario usuario);
        bool Exists(Usuario usuario);
        bool Exists(int IdUsuario);
        IEnumerable<Usuario> ReadAll();
    }
}
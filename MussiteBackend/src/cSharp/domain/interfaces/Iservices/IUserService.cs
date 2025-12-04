using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain.DTOs;
using domain.entities;
namespace domain.interfaces.Iservices
{
    public interface IUserService
    {
        bool POST(RegisterDTO usuario);
        void GET(UserDTOs usuario);
        void PUT(RegisterDTO usuario);
        void DELETE(Usuario usuario);
        Usuario Login(LoginDTO loginDTO);
        List<Usuario> GetAll();
    }
}
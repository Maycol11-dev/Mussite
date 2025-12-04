using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain.DTOs;
using domain.entities;
using domain.interfaces.Irepos;
using domain.interfaces.Iservices;
using Mapster;

namespace aplication.services
{
    public class UserServ : IUserService
    {
        private readonly IUserRepo userRepo;
        public UserServ(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }
        public bool POST(RegisterDTO usuario)
        {
            if(userRepo.Exists(usuario.Adapt<Usuario>()) is true)
            {
                Console.WriteLine(" Este usuario ya se encuentra registrado");
                return false;
            }
            userRepo.Create(usuario.Adapt<Usuario>());
            return true;
        }
        public Usuario Login(LoginDTO loginDTO)
        {
            if(!userRepo.Exists(loginDTO.Adapt<Usuario>()))
                return null!;
                
            var user = userRepo.Read(loginDTO.Adapt<Usuario>());
            return user;
        }
        public void GET(UserDTOs usuario){}
        public List<Usuario> GetAll()
        {
            var IEnumUsuarios = userRepo.ReadAll();
            return IEnumUsuarios.ToList();
        } 
        public void PUT(RegisterDTO usuario){}
        public void DELETE(Usuario usuario){}
    }
}
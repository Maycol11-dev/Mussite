using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace domain.DTOs
{
    public class UserDTOs
    {
        public string Nombre {get; set;} = string.Empty;
        public string Email {get; set;} = string.Empty;
        public string Contrasena {get; set;} = string.Empty;
    }
    public class RegisterDTO : UserDTOs
    {
    }
    public class LoginDTO
    {
        public string Email {get; set;} = string.Empty;
        public string Contrasena {get; set;} = string.Empty;
    }
}
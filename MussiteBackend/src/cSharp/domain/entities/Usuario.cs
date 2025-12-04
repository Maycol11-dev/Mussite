using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace domain.entities
{
    public class Usuario
    {
        public int IdUsuario {get; set;}
        public string Nombre {get; set;} = string.Empty;
        public string Email {get; set;} = string.Empty;
        public string Contrasena {get; set;} = string.Empty;
        public string PerfilUrl {get; set;} = string.Empty;
        public string BannerUrl {get; set;} = string.Empty;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain.enums;

namespace domain.entities
{
    public class Partitura
    {
        public int IdPartitura { get; set; }
        public int IdUsuario {get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string ImagenUrl { get; set; } = string.Empty;
        public string PDFUrl { get; set; } = string.Empty;
        public DateTime Publicacion { get; set; }
        public string Compositor { get; set; } = string.Empty;
    }
}
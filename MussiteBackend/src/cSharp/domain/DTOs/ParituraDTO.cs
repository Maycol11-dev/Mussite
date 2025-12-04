using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace domain.DTOs
{
    public class ParituraDTO
{
    public int IdUsuario { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Compositor { get; set; } = string.Empty;
    public IFormFile Imagen { get; set; } = null!;
    public IFormFile PDF { get; set; } = null!;
    public static async ValueTask<ParituraDTO> BindAsync(HttpContext context)
    {
        var form = await context.Request.ReadFormAsync();
        return new ParituraDTO
        {
            IdUsuario = int.Parse(form["IdUsuario"]!),
            Titulo = form["Titulo"]!,
            Compositor = form["Compositor"]!,
            Imagen = form.Files.GetFile("Imagen")!,
            PDF = form.Files.GetFile("PDF")!
        };
    }
}

}
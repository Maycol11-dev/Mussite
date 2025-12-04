

using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http;
using domain.interfaces;
using domain.entities;
using domain.DTOs;
using aplication.repositories;
using aplication.services;
using domain.interfaces.Iservices;
using domain.interfaces.Irepos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddScoped<IUserRepo>(sp =>
    new UserRepo("Server=localhost;Database=bd_mussitedatabase;Uid=admin;Password=Admin123!;")
);
builder.Services.AddScoped<IPartituraRepo>(sp =>
    new PartituraRepo("Server=localhost;Database=bd_mussitedatabase;Uid=admin;Password=Admin123!;")
);

builder.Services.AddScoped<IPartituraService, PartituraServ>();
builder.Services.AddScoped<IUserService, UserServ>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "wwwroot", "uploads")),
    RequestPath = "/uploads"
});

#region Account

app.MapGet("/api/usuarios", (IUserService userService) =>
{
    var usuariosList = userService.GetAll();
    return Results.Ok(usuariosList);
});
app.MapPost("/api/account/Register", ( RegisterDTO registerDTO, IUserService userServ) =>
{
    var hecho = userServ.POST(registerDTO);
    if (!hecho)
        return Results.BadRequest(new { success = false, message = "Tal usuario es existente" });

    return Results.Ok(new { success = true, message = "Registro exitoso." });
});

app.MapPost("/api/account/Login", ( LoginDTO loginDTO, IUserService userServ, HttpContext httpContext) =>
{
    var user = userServ.Login(loginDTO);
    if (user is null)
        return Results.BadRequest(new { message = "No existe un usuario con estas credenciales" });

    httpContext.Response.Cookies.Append(
    "user_session",
    loginDTO.Email,
    new CookieOptions
    {
        HttpOnly = true,
        Secure = false,
        SameSite = SameSiteMode.Strict,
        Expires = DateTime.UtcNow.AddHours(4)
    }
);
    return Results.Ok(new
    {
        idUsuario = user.IdUsuario,
        nombre = user.Nombre,
        email = user.Email,
        perfilUrl = user.PerfilUrl,
        bannerUrl = user.BannerUrl,
        message = "Inicio de sesión exitosa."
    });
});

#endregion

#region Partitura

app.MapGet("/api/partituras", ( IPartituraService partituraService) =>
{
    var partiturasList = partituraService.GetAll();
    return Results.Ok(partiturasList);
});

app.MapGet("/api/compositores", ( IPartituraService partituraService) =>
{
    var partiturasList = partituraService.GetAll();

    var compositores = partiturasList
        .Select(p => p.Compositor?.Trim())
        .Where(c => !string.IsNullOrEmpty(c))
        .Distinct()
        .ToList();

    return Results.Ok(compositores);
});

app.MapPost("/api/partituras/subir", async (
    ParituraDTO partituraDTO,
    IPartituraRepo partituraRepo,
    IUserRepo userRepo,
    IWebHostEnvironment env
) =>
{
    if (!userRepo.Exists(partituraDTO.IdUsuario))
        return Results.NotFound("No se encontró el usuario.");

    if (partituraDTO.Imagen == null || partituraDTO.PDF == null)
        return Results.BadRequest("Archivos faltantes.");

    var imgFolder = Path.Combine(env.WebRootPath, "uploads/partituras/img");
    var pdfFolder = Path.Combine(env.WebRootPath, "uploads/partituras/pdf");

    Directory.CreateDirectory(imgFolder);
    Directory.CreateDirectory(pdfFolder);

    var imgFileName = $"{Guid.NewGuid()}{Path.GetExtension(partituraDTO.Imagen.FileName)}";
    var pdfFileName = $"{Guid.NewGuid()}{Path.GetExtension(partituraDTO.PDF.FileName)}";

    using var imgStream = new FileStream(Path.Combine(imgFolder, imgFileName), FileMode.Create);
    await partituraDTO.Imagen.CopyToAsync(imgStream);

    using var pdfStream = new FileStream(Path.Combine(pdfFolder, pdfFileName), FileMode.Create);
    await partituraDTO.PDF.CopyToAsync(pdfStream);

    var nuevaPartitura = new Partitura
    {
        IdUsuario = partituraDTO.IdUsuario,
        Titulo = partituraDTO.Titulo,
        Compositor = partituraDTO.Compositor,
        ImagenUrl = $"/uploads/partituras/img/{imgFileName}",
        PDFUrl = $"/uploads/partituras/pdf/{pdfFileName}"
    };

    partituraRepo.Create(nuevaPartitura);

    return Results.Ok("Partitura subida con éxito");
});


#endregion

app.UseHttpsRedirection();

app.Run();

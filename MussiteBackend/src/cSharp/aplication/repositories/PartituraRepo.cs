using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using domain.entities;
using domain.interfaces;
using domain.interfaces.Irepos;

namespace aplication.repositories
{
    public class PartituraRepo : Database, IPartituraRepo
    {
        public PartituraRepo (string connection) : base (connection){}
        const string insSQL = @"INSERT INTO Partitura (IdUsuario, Titulo, ImagenUrl, PDFUrl, Publicacion, Compositor)
                                VALUES (@IdUsuario, @Titulo, @ImagenUrl, @PDFUrl, NOW() , @Compositor)";
        const string selSQL = @"nose";
        public void Create(Partitura partitura) => Exec(db => db.Execute( insSQL , new
        {
            partitura.IdUsuario,
            partitura.Titulo,
            partitura.ImagenUrl,
            partitura.PDFUrl,
            partitura.Compositor
        }));
        public IEnumerable<Partitura> ReadAll() => Exec(db => db.Query<Partitura>("SELECT * FROM Partitura"));
        public Partitura Read(Partitura partitura) => Exec(db => db.QueryFirstOrDefault<Partitura>(selSQL, partitura))!;
        public void Update(Partitura partitura) => Exec(db => db.Execute( insSQL ,partitura));
        public void Delete(Partitura partitura) => Exec(db => db.Execute( insSQL ,partitura));
        public bool Exists(Partitura partitura) => Exec(db => db.ExecuteScalar<bool>( insSQL ,partitura));
    }
}
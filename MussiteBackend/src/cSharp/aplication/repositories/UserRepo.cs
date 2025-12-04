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
    public class UserRepo : Database, IUserRepo
    {
        public UserRepo(string connection) : base (connection){}
        const string insSQL = @"INSERT INTO Usuario (Nombre, Email, Contrasena, perfilUrl, bannerUrl)
                                VALUES (@Nombre, @Email, @Contrasena, '/uploads/avatars/predeterminado.png', '/uploads/banners/predeterminado.jpg')";
        const string selSQL = @"SELECT * FROM Usuario WHERE Email = @Email";
        const string strExists = @"SELECT EXISTS(SELECT * 
                                          FROM Usuario 
                                          WHERE Email = @Email 
                                          AND Contrasena = @Contrasena)";
        const string strExistsById = @"SELECT EXISTS(SELECT * 
                                          FROM Usuario 
                                          WHERE IdUsuario = @ID)";
        public void Create(Usuario usuario) => Exec(db => db.Execute(insSQL, usuario));
        public Usuario Read(Usuario usuario) => Exec(db => db.QueryFirstOrDefault<Usuario>(selSQL, new{ usuario.Email}))!;
        public IEnumerable<Usuario> ReadAll() => Exec(db => db.Query<Usuario>("SELECT * FROM Usuario"));
        public void Update(Usuario usuario) => Exec(db => db.Execute(insSQL, usuario));
        public void Delete(Usuario usuario)=> Exec(db => db.Execute(insSQL, usuario));
        public bool Exists(Usuario usuario) => Exec(db => db.ExecuteScalar<bool>(strExists, usuario));
        public bool Exists(int IdUsuario) => Exec(db => db.ExecuteScalar<bool>( strExistsById , new{ ID = IdUsuario}));
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using MySqlConnector;
using System.Linq;
using System.Threading.Tasks;

namespace aplication.repositories
{
    public abstract class Database
{
    protected readonly string connectionString;

    public Database(string connection)
    {
        connectionString = connection; 
    }

    protected T Exec<T>(Func<IDbConnection, T> newConnection)
    {
        using var conn = new MySqlConnection(connectionString);
        conn.Open();
        return newConnection(conn);
    }
}

}
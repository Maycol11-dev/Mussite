using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain.entities;

namespace domain.interfaces.Irepos
{
    public interface IPartituraRepo
    {
        void Create(Partitura partitura);
        Partitura Read(Partitura partitura);
        void Update(Partitura partitura);
        void Delete(Partitura partitura);
        bool Exists(Partitura partitura);
        IEnumerable<Partitura> ReadAll();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain.entities;

namespace domain.interfaces.Iservices
{
    public interface IPartituraService
    {
        List<Partitura> GetAll();
    }
}
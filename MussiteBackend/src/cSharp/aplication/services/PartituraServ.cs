using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain.DTOs;
using domain.entities;
using domain.interfaces.Irepos;
using domain.interfaces.Iservices;
using Mapster;

namespace aplication.services
{
    public class PartituraServ : IPartituraService
    {
        private readonly IPartituraRepo partituraRepo;
        public PartituraServ(IPartituraRepo partituraRepo)
        {
            this.partituraRepo = partituraRepo;
        }

        public List<Partitura> GetAll()
        {
            var IEnumPartituras = partituraRepo.ReadAll();
            return IEnumPartituras.ToList();
        }
    }
}
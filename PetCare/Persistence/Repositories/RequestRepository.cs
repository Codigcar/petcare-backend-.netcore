using PetCare.Domain.Models;
using PetCare.Domain.Repositories;
using PetCare.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Persistence.Repositories
{
    public class RequestRepository : BaseRepository, IRequestRepository
    {
        public RequestRepository(AppDbContext context) : base(context)
        {

        }

        public Task AddAsyn(Request request)
        {
            throw new NotImplementedException();
        }
    }
}

using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Repositories
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> ListAsync();
        Task AddAsyn(Review review);
        Task<Review> FindByIdAsync(int id);
        void Update(Review review);
        void Remove(Review review);
    }
}

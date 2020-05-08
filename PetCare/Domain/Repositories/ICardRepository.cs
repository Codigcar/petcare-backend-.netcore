using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Repositories
{
    public interface ICardRepository
    {
        Task<IEnumerable<Card>> ListAsync();
        Task AddAsyn(Card Card);
        Task<Card> FindByIdAsync(int id);
        void Update(Card Card);
        void Remove(Card Card);
    }
}

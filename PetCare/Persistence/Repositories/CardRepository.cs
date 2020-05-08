using Microsoft.EntityFrameworkCore;
using PetCare.Domain.Models;
using PetCare.Domain.Repositories;
using PetCare.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Persistence.Repositories
{
    public class CardRepository : BaseRepository, ICardRepository
    {
        public CardRepository(AppDbContext context) : base(context)
        {

        }

        public async Task AddAsyn(Card Card)
        {
            await _context.Cards.AddAsync(Card);
        }

        public async Task<Card> FindByIdAsync(int id)
        {
            return await _context.Cards.FindAsync(id);
        }

        public async Task<IEnumerable<Card>> ListAsync()
        {
            return await _context.Cards.ToListAsync();
        }

        public void Remove(Card Card)
        {
            _context.Cards.Remove(Card);
        }

        public void Update(Card Card)
        {
            _context.Update(Card);
        }
    }
}

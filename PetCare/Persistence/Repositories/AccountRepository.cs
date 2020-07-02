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

    public class AccountRepository : BaseRepository, IAccountRepository
    {
        public AccountRepository(AppDbContext context) : base(context)
        {

        }

        public async Task AddAsyn(Account account)
        {
            await _context.Accounts.AddAsync(account);
        }

        public async Task<IEnumerable<Account>> ListAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account> GetByUserandPasswordIdAsync(string username, string password) =>
           await _context.Accounts
           .Where(p => p.User == username)
           .Include(p => p.User)
           .FirstOrDefaultAsync();
    }
}

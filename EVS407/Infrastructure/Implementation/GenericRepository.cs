using DomainModels;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implementation
{
    public class GenericRepository : IGenericRepository
    {
        private Evs407Context _context;

        public GenericRepository(Evs407Context context)
        {
            _context = context;
        }
        public async Task<bool> Create(object entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Update(object entity)
        {
             _context.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(object entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

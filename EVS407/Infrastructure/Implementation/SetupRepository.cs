using DomainModels;
using Infrastructure.Interface;
using Infrastructure.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implementation
{
    public class SetupRepository : ISetupRepository
    {
        private Evs407Context _context;

        public SetupRepository(Evs407Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<GenderVM>> GenderGetAll()
        {
            var resultVM = new List<GenderVM>();
            var Genders = await _context.Genders.ToListAsync();
            if (Genders != null && Genders.Count > 0)
            {
                foreach (var gender in Genders)
                {
                    resultVM.Add(new GenderVM()
                    {
                        GenderName = gender.GenderName,
                        Id = gender.Id,
                    });
                }
                return resultVM;
            }
            return resultVM;
        }
    }
}

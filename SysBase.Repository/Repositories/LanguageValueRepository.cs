using Microsoft.EntityFrameworkCore;
using SysBase.Core.Models;
using SysBase.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysBase.Repository.Repositories
{
    public class LanguageValueRepository : GenericRepository<LanguageValue>, ILanguageValueRepository
    {
        public LanguageValueRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<LanguageValue>> GetLanguageValuesWithLanguageKey(String languageCode, int type)
        {
            if (type == 0)
            {
                return await _context.LanguageValues.Include(x => x.LanguageKey).Where(x => x.Language.Code == languageCode).ToListAsync();
            }
            else
            {
                return await _context.LanguageValues.Include(x => x.LanguageKey).Where(x => x.Language.Code == languageCode && x.LanguageKey.Type == type).ToListAsync();
            }

        }
    }
}

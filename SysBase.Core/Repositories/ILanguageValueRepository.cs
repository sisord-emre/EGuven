using SysBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysBase.Core.Repositories
{
    public interface ILanguageValueRepository:IGenericRepository<LanguageValue>
    {
        Task<List<LanguageValue>> GetLanguageValuesWithLanguageKey(String languageCode, int type);
    }
}

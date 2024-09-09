using SysBase.Core.DTOs;
using SysBase.Core.Models;

namespace SysBase.Core.Services
{
    public interface ILanguageValueService : IService<LanguageValue>
    {
        Task<List<LanguageValuesWithLanguageKeyDto>> GetLanguageValuesWithLanguageKey(String languageCode, int type);
    }
}

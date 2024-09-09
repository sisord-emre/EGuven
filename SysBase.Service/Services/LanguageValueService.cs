using AutoMapper;
using SysBase.Core.DTOs;
using SysBase.Core.Models;
using SysBase.Core.Repositories;
using SysBase.Core.Services;
using SysBase.Core.UnitOfWorks;

namespace SysBase.Service.Services
{
    public class LanguageValueService : Service<LanguageValue>, ILanguageValueService
    {
        private readonly ILanguageValueRepository _languageValueRepository;
        private readonly IMapper _mapper;
        public LanguageValueService(IGenericRepository<LanguageValue> repository, IUnitOfWork unitOfWork = null, ILanguageValueRepository languageValueRepository = null, IMapper mapper = null) : base(repository, unitOfWork)
        {
            _languageValueRepository = languageValueRepository;
            _mapper = mapper;
        }

        public async Task<List<LanguageValuesWithLanguageKeyDto>> GetLanguageValuesWithLanguageKey(String languageCode, int type)
        {
            var languageValues = await _languageValueRepository.GetLanguageValuesWithLanguageKey(languageCode, type);
            return _mapper.Map<List<LanguageValuesWithLanguageKeyDto>>(languageValues);
        }
    }
}

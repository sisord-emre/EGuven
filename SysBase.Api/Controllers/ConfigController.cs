using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SysBase.Core.DTOs;
using SysBase.Core.Models;
using SysBase.Core.Services;

namespace SysBase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ApiBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Config> _service;
        public ConfigController(IService<Config> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        //tümünü listele
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var config = await _service.GetAllAsync();
            var configsDto = _mapper.Map<List<ConfigDto>>(config.ToList());

            return CreateActionResult(ResponseDto<List<ConfigDto>>.Success(200, configsDto));
        }
        //id ile tek satır
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var config = await _service.GetByIdAsync(id);
            var configsDto = _mapper.Map<ConfigDto>(config);

            return CreateActionResult(ResponseDto<ConfigDto>.Success(200, configsDto));
        }
        //yeni kayıt
        [HttpPost]
        public async Task<IActionResult> Save(ConfigDto configDto)
        {
            var config = await _service.AddAsync(_mapper.Map<Config>(configDto));
            var configsDto = _mapper.Map<ConfigDto>(config);

            return CreateActionResult(ResponseDto<ConfigDto>.Success(201, configsDto));
        }
        //update
        [HttpPut]
        public async Task<IActionResult> Update(ConfigDto configDto)
        {
            await _service.UpdateAsync(_mapper.Map<Config>(configDto));

            return CreateActionResult(ResponseDto<NoContentResult>.Success(204));
        }
        //silme
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var config = await _service.GetByIdAsync(id);
            if (config == null)
            {
                return CreateActionResult(ResponseDto<NoContentResult>.Fail(404, "Not Found"));
            }
            await _service.RemoveAsync(config);

            return CreateActionResult(ResponseDto<NoContentResult>.Success(204));
        }
    }
}

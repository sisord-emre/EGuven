using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SysBase.Core.DTOs;

namespace SysBase.Api.Controllers
{
    public class ApiBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(ResponseDto<T> response)
        {
            if (response.StatusCode == 204)//başarılı ana data dönmicek ise
            {
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode
                };
            }
            else//başarılı ana data dönecek ise
            {
                return new ObjectResult(response)
                {
                    StatusCode = response.StatusCode
                };
            }
        }
    }
}

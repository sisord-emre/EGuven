using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog.Context;
using SysBase.Core.Models;
using SysBase.Core.Services;
using SysBase.Web.Resources;

namespace SysBase.Web.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class UserTableController : BaseController
    {
        // UserTableController specific dependencies
        protected readonly IService<UserTable> _service;
        protected readonly ILogger<UserTableController> _logger;

        public UserTableController(IHtmlLocalizer<SharedResource> localizer, UserManager<AppUser> userManager,
                                      IService<UserTable> service, ILogger<UserTableController> logger)
            : base(localizer, userManager)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> UserTableAdd(int menuId, string data)
        {
            // menuId ve data kontrolü
            if (menuId <= 0)
            {
                return Json(new { success = false, message = "Geçersiz parametreler: menuId kontrol ediniz." });
            }

            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var userTableList = await _service.Where(x => x.UserId == currentUser.Id && x.MenuId == menuId).FirstOrDefaultAsync();
            if (userTableList != null)
            {
                // Sadece TableInformation alanını güncelle
                userTableList.TableInformation = data;

                // Kaydet
                await _service.UpdateAsync(userTableList);

                // Log işlemleri
                LogContext.PushProperty("TypeName", "Update");
                _logger.LogCritical(functions.LogCriticalMessage(
                    ControllerContext.ActionDescriptor.ActionName,
                    ControllerContext.ActionDescriptor.ControllerName,
                    userTableList.Id.ToString(),
                    JsonConvert.SerializeObject(userTableList)
                ));
            }
            else
            {
                UserTable addItem = new UserTable
                {
                    UserId = currentUser.Id,
                    MenuId = menuId,
                    TableInformation = data
                };

                await _service.AddAsync(addItem);

                // Log işlemleri
                LogContext.PushProperty("TypeName", ControllerContext.ActionDescriptor.ActionName);
                _logger.LogCritical(functions.LogCriticalMessage(
                    ControllerContext.ActionDescriptor.ActionName,
                    ControllerContext.ActionDescriptor.ControllerName,
                    addItem.Id.ToString(),
                    JsonConvert.SerializeObject(addItem)
                ));
            }

            return NoContent();
        }


        [HttpPost]
        public async Task<IActionResult> UserTableList(int menuId)
        {
            // menuId ve data kontrolü
            if (menuId <= 0 )
            {
                return Json(new { success = false, message = "Geçersiz parametreler: menuId ve data kontrol ediniz." });
            }

            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var userTableList = await _service.Where(x => x.UserId == currentUser.Id && x.MenuId == menuId).FirstOrDefaultAsync();

            if (userTableList != null)
            {
                // Sadece TableInformation verisini döndür
                return Ok(userTableList.TableInformation); // HTTP 200 ile yalnızca TableInformation verisi döndürülür
            }

            // Eğer userTableList bulunamazsa NoContent döndür
            return NoContent();
        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog.Context;
using SysBase.Core.Models;
using SysBase.Core.Services;
using SysBase.Web.Areas.Admin.Models;
using SysBase.Web.Resources;

namespace SysBase.Web.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class BlogTypeController : BaseController
    {
        // BlogTypeController specific dependencies
        protected readonly IService<BlogType> _service;
        protected readonly ILogger<BlogTypeController> _logger;
        protected readonly IService<Language> _languageService;

        public BlogTypeController(IHtmlLocalizer<SharedResource> localizer, UserManager<AppUser> userManager,
                                  IService<BlogType> service, ILogger<BlogTypeController> logger, IService<Language> languageService)
            : base(localizer, userManager)
        {
            _service = service;
            _logger = logger;
            _languageService = languageService;
        }

        public async Task<IActionResult> Add(string Id = null)
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, ControllerContext.ActionDescriptor.ActionName))
            {
                return Content("<div class='alert alert-danger alert-dismissible fade show' role='alert'><strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong></div>");
            }

            BlogType blogType = null;
            if (Id != null)
            {
                blogType = await _service.GetByIdAsync(Int32.Parse(Id));
            }

            //log işleme alanı     
            LogContext.PushProperty("TypeName", "List");
            _logger.LogCritical(functions.LogCriticalMessage("List", ControllerContext.ActionDescriptor.ControllerName, Id));

            return View
            (
                new BlogTypeAddViewModel
                {
                    MenuPermission = menuPermission,
                    BlogType = blogType,
                    Languages = await _languageService.GetAllAsync()
                }
            );
        }

        [HttpPost]
        public async Task<IActionResult> Add(BlogType model)
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, ControllerContext.ActionDescriptor.ActionName))
            {
                return Content("<div class='alert alert-danger alert-dismissible fade show' role='alert'><strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong></div>");
            }

            BlogType isControl;
            if (ModelState.IsValid)
            {
                isControl = await _service.UpdateAsync(model);

                //log işleme alanı
                LogContext.PushProperty("TypeName", "Update");
                _logger.LogCritical(functions.LogCriticalMessage("Update", ControllerContext.ActionDescriptor.ControllerName, isControl.Id.ToString(), JsonConvert.SerializeObject(model)));
            }
            else
            {
                isControl = await _service.AddAsync(model);

                //log işleme alanı
                LogContext.PushProperty("TypeName", ControllerContext.ActionDescriptor.ActionName);
                _logger.LogCritical(functions.LogCriticalMessage(ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName, isControl.Id.ToString(), JsonConvert.SerializeObject(model)));
            }
            if (isControl.Id != 0)
            {
                TempData["SuccessMessage"] = _localizer["admin.Kayıt İşlemi Başarıyle Gerçekleşmiştir."].Value;
            }
            else
            {
                TempData["ErrorMessage"] = _localizer["admin.Bilgileri Kontrol Ediniz"].Value;
            }

            return View
            (
                new BlogTypeAddViewModel
                {
                    MenuPermission = menuPermission,
                    BlogType = isControl,
                    Languages = (List<Language>)await _languageService.GetAllAsync()
                }
            );
        }

        public async Task<IActionResult> List()
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, ControllerContext.ActionDescriptor.ActionName))
            {
                return Content("" +
                    "<div class='alert alert-danger alert-dismissible fade show' role='alert'>" +
                        "<strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong>" +
                    "</div>");
            }

            //log işleme alanı
            LogContext.PushProperty("TypeName", ControllerContext.ActionDescriptor.ActionName);
            _logger.LogCritical(functions.LogCriticalMessage(ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName));

            return View(new BlogTypeListViewModel { MenuPermission = menuPermission, BlogTypes = await _service.GetAllAsync() });
        }

        public async Task<ResultJson> Delete(string Id = null)
        {
            ResultJson resultJson = new ResultJson();
            resultJson.status = "error";
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, ControllerContext.ActionDescriptor.ActionName))
            {
                resultJson.message = _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value;
                return resultJson;
            }

            if (Id != null)
            {
                BlogType item = await _service.GetByIdAsync(Int32.Parse(Id));
                if (item != null)
                {
                    await _service.RemoveAsync(item);
                    resultJson.status = "success";
                    return resultJson;
                }
            }

            //log işleme alanı
            LogContext.PushProperty("TypeName", ControllerContext.ActionDescriptor.ActionName);
            _logger.LogCritical(functions.LogCriticalMessage(ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName, Id));

            return resultJson;
        }

        public async Task<IActionResult> BlogTypeLayout(int blogTypeLanguageId)
        {
            var orderedBlogTypes = await _service
               .Where(x => x.LanguageId == blogTypeLanguageId)
               .Include(x => x.Language) // Language varlığını sorguya dahil ediyoruz
               .OrderBy(s => s.Sequence)
               .ToListAsync();

            return View(orderedBlogTypes);

        }

        [HttpPost]
        public async Task<IActionResult> BlogTypeLayoutAdd([FromBody] BlogTypeLayoutModel model)
        {
            try
            {
                // blogTypeLayoutList ile blogType sırasını güncelleme işlemi
                int sayac1 = 0;
                foreach (var blogTypeId in model.BlogTypeLayoutList)
                {
                    sayac1++;
                    BlogType item = await _service.GetByIdAsync(blogTypeId);
                    item.Sequence = sayac1;
                    await _service.UpdateAsync(item);
                }

                // Başarılı bir işlem olduğunda
                return Json(new { success = true, message = "Güncelleme Sağlandı." });
            }
            catch (Exception ex)
            {
                // Hata durumunda
                return Json(new { success = false, message = ex.Message });
            }
        }

    }
}

﻿using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog.Context;
using SysBase.Core.Models;
using SysBase.Core.Services;
using SysBase.Repository.Migrations;
using SysBase.Web.Areas.Admin.Models;
using SysBase.Web.Resources;
using System.Diagnostics;

namespace SysBase.Web.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class FooterMenuController : BaseController
    {
        // PageController specific dependencies
        protected readonly IService<FooterMenu> _service;
        protected readonly ILogger<FooterMenuController> _logger;
        protected readonly IService<Language> _languageService;

        public FooterMenuController(IHtmlLocalizer<SharedResource> localizer, UserManager<AppUser> userManager,
                              IService<FooterMenu> service, ILogger<FooterMenuController> logger, IService<Language> languageService)
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

            FooterMenu model = null;
            if (Id != null)
            {
                model = await _service.GetByIdAsync(Int32.Parse(Id));
            }

            //log işleme alanı     
            LogContext.PushProperty("TypeName", "List");
            _logger.LogCritical(functions.LogCriticalMessage("List", ControllerContext.ActionDescriptor.ControllerName, Id));

            return View
            (
                new FooterMenuAddViewModel
                {
                    MenuPermission = menuPermission,
                    FooterMenu = model,
                    Languages = (List<Language>)await _languageService.GetAllAsync()
                }
            );
        }

        [HttpPost]
        public async Task<IActionResult> Add(FooterMenu model)
        {
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            MenuPermission menuPermission = functions.MenuPermSelect(currentUser.MenuPermissions, ControllerContext.ActionDescriptor.ControllerName);
            if (!functions.MenuPermControl(menuPermission, ControllerContext.ActionDescriptor.ActionName))
            {
                return Content("<div class='alert alert-danger alert-dismissible fade show' role='alert'><strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong></div>");
            }

            FooterMenu isControl;
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
                new FooterMenuAddViewModel
                {
                    MenuPermission = menuPermission,
                    FooterMenu = model,
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
                return Content("<div class='alert alert-danger alert-dismissible fade show' role='alert'><strong>" + _localizer["admin.Menü Erişim Yetkiniz Bulunmamaktadır."].Value + "</strong></div>");
            }

            //log işleme alanı
            LogContext.PushProperty("TypeName", ControllerContext.ActionDescriptor.ActionName);
            _logger.LogCritical(functions.LogCriticalMessage(ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName));

            return View
            (
                new FooterMenuListViewModel
                {
                    MenuPermission = menuPermission,
                    FooterMenus = await _service.ToListAsync()
                }
            );
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
                FooterMenu item = await _service.GetByIdAsync(Int32.Parse(Id));
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

        public async Task<IActionResult> MenuLayout(int footerMenuLanguageId)
        {
            var siteMenus = await _service
                .Where(x => x.LanguageId == footerMenuLanguageId)
                .Include(x => x.Language) // Language varlığını sorguya dahil ediyoruz
                .ToListAsync();

            return View(siteMenus);
        }

        public async Task<string> MenuLayoutAdd(string siteMenuLayout)
        {
            List<Dictionary<string, object>> menuLayout = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(siteMenuLayout);
            int sayac1 = 0;
            foreach (var menu in menuLayout)
            {
                sayac1++;
                FooterMenu item = await _service.GetByIdAsync(Convert.ToInt32(menu["id"]));
                item.ParentId = 0;
                item.Sequence = sayac1;
                await _service.UpdateAsync(item);
                try
                {
                    if (menu["children"] != null)
                    {
                        int sayac2 = 0;
                        foreach (var altMenu in JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(menu["children"].ToString()))
                        {
                            sayac2++;
                            FooterMenu altItem = await _service.GetByIdAsync(Convert.ToInt32(altMenu["id"]));
                            altItem.ParentId = item.Id;
                            altItem.Sequence = sayac2;
                            await _service.UpdateAsync(altItem);
                            try
                            {
                                if (altMenu["children"] != null)
                                {
                                    int sayac3 = 0;
                                    foreach (var altAltMenu in JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(altMenu["children"].ToString()))
                                    {
                                        sayac3++;
                                        FooterMenu altAltItem = await _service.GetByIdAsync(Convert.ToInt32(altAltMenu["id"]));
                                        altAltItem.ParentId = altItem.Id;
                                        altAltItem.Sequence = sayac3;
                                        await _service.UpdateAsync(altAltItem);
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                Debug.WriteLine("Alt Child Yok");
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    Debug.WriteLine("Child Yok");
                }
            }
            return "1";
        }

    }
}
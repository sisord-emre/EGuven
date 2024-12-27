using CrmService;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.EntityFrameworkCore;
using SysBase.Core.Models;
using SysBase.Core.Services;
using SysBase.Web.Resources;
using SysBase.Web.ViewModels;
using System.Diagnostics;
using System.Globalization;

namespace SysBase.Web.Controllers
{
    public class ContactController : BaseController
    {
        private readonly ILogger<ContactController> _logger;
        protected readonly IService<SiteMenu> _siteMenuService;
        protected readonly IService<FooterMenu> _footerMenuService;
        protected readonly IService<Language> _languageService;
        protected readonly IService<QuickMenu> _quickMenuService;
        protected readonly IService<Form> _formService;
        protected readonly IService<PageLanguageInfo> _pageLanguageInfoService;

        public ContactController(IHtmlLocalizer<SharedResource> localizer, IService<Config> service,
           ILogger<ContactController> logger, IService<SiteMenu> siteMenuService, IService<FooterMenu> footerMenuService,
           IService<Language> languageService, IService<QuickMenu> quickMenuService,
           IService<PageLanguageInfo> pageLanguageInfoService, IService<Form> formService)
          : base(localizer, service)
        {
            _logger = logger;
            _siteMenuService = siteMenuService;
            _footerMenuService = footerMenuService;
            _languageService = languageService;
            _quickMenuService = quickMenuService;
            _pageLanguageInfoService = pageLanguageInfoService;
            _formService = formService;
        }

        public async Task<IActionResult> Index()
        {
            var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            var langCode = rqf.RequestCulture.Culture;
            Debug.WriteLine(langCode);

            UiLayoutViewModel uiLayoutViewModel = new UiLayoutViewModel();
            uiLayoutViewModel.Config = _service.Where(x => x.Id == 1).FirstOrDefault();
            uiLayoutViewModel.SiteMenus = _siteMenuService.Where(x => x.Status && x.Language.Code == CultureInfo.CurrentCulture.Name).OrderBy(x => x.Sequence).ToList();
            uiLayoutViewModel.FooterMenus = _footerMenuService.Where(x => x.Status && x.Language.Code == CultureInfo.CurrentCulture.Name).OrderBy(x => x.Sequence).ToList();
            uiLayoutViewModel.Languages = _languageService.Where(x => x.Status).ToList();
            uiLayoutViewModel.QuickMenus = _quickMenuService.Where(x => x.Status && x.Language.Code == CultureInfo.CurrentCulture.Name).OrderBy(x => x.Sequence).ToList();

            ContactViewModel model = new ContactViewModel
            {
                Config = uiLayoutViewModel.Config,
                SiteMenus = uiLayoutViewModel.SiteMenus,
                FooterMenus = uiLayoutViewModel.FooterMenus,
                Languages = uiLayoutViewModel.Languages,
                QuickMenus = uiLayoutViewModel.QuickMenus,
                CompanyInformation = await _pageLanguageInfoService.Where(x => x.Language.Code == CultureInfo.CurrentCulture.Name && x.Status && x.PageId == 3).Include(x => x.Page).FirstOrDefaultAsync(),
                AccountNumber = await _pageLanguageInfoService.Where(x => x.Language.Code == CultureInfo.CurrentCulture.Name && x.Status && x.PageId == 4).Include(x => x.Page).FirstOrDefaultAsync(),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ResultJson> Kayit(Form model, string soyad, [FromForm(Name = "cf-turnstile-response")] string cfTurnstileResponse)
        {
            ResultJson resultJson = new ResultJson();
            resultJson.status = "error";
            resultJson.message = "Kayıt İşlemi Sırasında Hata Oluştu.";

            string resCT = await functions.CloudflareTurnstile(cfTurnstileResponse);
            if (resCT != "1")
            {
                resultJson.message = resCT;
                return resultJson;
            }

            model.Name = model.Name + " " + soyad;
            model.Status = false;
            await _formService.AddAsync(model);


            // Servis istemcisini oluşturun
            var client = new Web2Client(Web2Client.EndpointConfiguration.BasicHttpBinding_IWeb2);
            try
            {
                // FormIletisimRequest nesnesini oluşturun
                var formRequest = new FormIletisimRequest
                {
                    Email = model.Email,
                    Message = model.Message,
                    Name = model.Name,
                    Phone = model.Phone,
                    Subject = model.Subject,
                    Tcno = model.Tcno,
                    Type = model.Type
                };
                // SOAP isteğini yapın
                var response = await client.FormIletisimAsync(formRequest, "2", "EgVn2016");
                // Yanıtı gösterin
                Debug.WriteLine($"Result: {response}");
                if (response.Contains("Kaydınız Alınmıştır"))
                {
                    resultJson.status = "success";
                    resultJson.message = response;
                    model.Status = true;
                    model.UpdatedDate = DateTime.Now;
                    await _formService.UpdateAsync(model);
                }
                else
                {
                    resultJson.status = "error";
                    resultJson.message = response;
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda çıktı
                Debug.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                // İstemciyi kapat
                if (client.State == System.ServiceModel.CommunicationState.Opened)
                    await client.CloseAsync();
            }

            return resultJson;
        }

    }
}

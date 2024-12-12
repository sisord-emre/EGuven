using Azure;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using SysBase.Core.Models;
using SysBase.Core.Services;
using SysBase.Service.Functions;
using SysBase.Web.Resources;
using SysBase.Web.ViewModels;
using System.Diagnostics;
using System.Globalization;

namespace SysBase.Web.Controllers
{
    public class PinController : BaseController
    {
        private readonly ILogger<PinController> _logger;
        protected readonly IService<SiteMenu> _siteMenuService;
        protected readonly IService<FooterMenu> _footerMenuService;
        protected readonly IService<Language> _languageService;
        protected readonly IService<QuickMenu> _quickMenuService;
        protected Functions functions = new Functions();

        public PinController(IHtmlLocalizer<SharedResource> localizer, IService<Config> service,
           ILogger<PinController> logger, IService<SiteMenu> siteMenuService, IService<FooterMenu> footerMenuService,
           IService<Language> languageService, IService<QuickMenu> quickMenuService)
          : base(localizer, service)
        {
            _logger = logger;
            _siteMenuService = siteMenuService;
            _footerMenuService = footerMenuService;
            _languageService = languageService;
            _quickMenuService = quickMenuService;
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

            return View(uiLayoutViewModel);
        }

        [HttpPost]
        public async Task<ResultJson> Kayit(string tcpasport, string tel,string type, [FromForm(Name = "cf-turnstile-response")] string cfTurnstileResponse)
        {
            ResultJson resultJson = new ResultJson();
            resultJson.status = "error";
            resultJson.message = "Kayıt İşlemi Sırasında Hata Oluştu.";

            string resCT = await functions.CloudflareTurnstile(cfTurnstileResponse);
            if (resCT!="1")
            {
                resultJson.message = resCT;
                return resultJson;
            }

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://192.168.127.25:5558/Web2.svc");
            request.Headers.Add("SOAPAction", "http://tempuri.org/IWeb2/SendPINPUKMailbyTCNO");
            var content = new StringContent("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">\r\n  <soap:Header/>\r\n  <soap:Body>\r\n    <SendPINPUKMailbyTCNO xmlns=\"http://tempuri.org/\">\r\n      <token></token>\r\n      <tcno>" + tcpasport + "</tcno>\r\n      <teldigit>" + tel + "</teldigit>\r\n      <pass></pass>\r\n      <type>"+ type + "</type>\r\n      <tokenserial></tokenserial>\r\n    </SendPINPUKMailbyTCNO>\r\n  </soap:Body>\r\n</soap:Envelope>\r\n", null, "text/xml");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string res = await response.Content.ReadAsStringAsync();
            if (res.Contains("Şifreniz Cep Telefonunuza Gönderilmiştir."))
            {
                resultJson.status = "success";
                resultJson.message = "Şifreniz Cep Telefonunuza Gönderilmiştir.";
            }
            else
            {
                resultJson.status = "error";
                resultJson.message = "Cep Telefonu ve TC No Uyumsuzdur.";
            }

            return resultJson;
        }
    }
}

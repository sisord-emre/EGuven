using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using SysBase.Core.Models;
using SysBase.Core.Services;
using SysBase.Service.Functions;
using SysBase.Web.Resources;
using System.Diagnostics;
using System.Linq;

namespace SysBase.Web.Controllers
{
    public class PaymentErrorController : BaseController
    {
        protected Functions functions = new Functions();
        private readonly ILogger<PaymentErrorController> _logger;
        protected readonly IService<SiteMenu> _siteMenuService;
        protected readonly IService<FooterMenu> _footerMenuService;
        protected readonly IService<Language> _languageService;
        protected readonly IService<QuickMenu> _quickMenuService;
        protected readonly IService<ProjectProduct> _projectProductService;
        protected readonly IService<ProjectField> _projectFieldService;
        protected readonly IService<City> _cityService;
        protected readonly IService<County> _countyService;
        protected readonly IService<ApiBasvuruRequest> _apiBasvuruRequestService;

        public PaymentErrorController(IHtmlLocalizer<SharedResource> localizer, IService<Config> service,
           ILogger<PaymentErrorController> logger, IService<SiteMenu> siteMenuService, IService<FooterMenu> footerMenuService,
           IService<Language> languageService, IService<QuickMenu> quickMenuService, IService<ProjectProduct> projectProductService, IService<ProjectField> projectFieldService, IService<City> cityService, IService<County> countyService, IService<ApiBasvuruRequest> apiBasvuruRequestService)
          : base(localizer, service)
        {
            _logger = logger;
            _siteMenuService = siteMenuService;
            _footerMenuService = footerMenuService;
            _languageService = languageService;
            _quickMenuService = quickMenuService;
            _projectProductService = projectProductService;
            _projectFieldService = projectFieldService;
            _cityService = cityService;
            _countyService = countyService;
            _apiBasvuruRequestService = apiBasvuruRequestService;
        }

        public async Task<IActionResult> Index(string slug)
        {
            string digestData = string.Empty; // Eksik değişken tanımlandı
            string strStoreKey = "12345678"; // Store Key'inizi buraya ekleyin
            bool isValidHash = false; // Hash doğrulama için flag

            Debug.WriteLine(Request.Form.Keys);
            Debug.WriteLine(Request.Form["procreturncode"]);

            if (Request.Form["procreturncode"]!="00")
            {
                return Content("!!!!!" + Request.Form["mderrormessage"] + "!!!!!");
            }
            string responseHash = Request.Form.ContainsKey("hash") ? Request.Form["hash"] : "";
            char[] separator = new char[] { ':' };
            // Ayıraç için kullanılacak hashparams
            string responseHashparams = Request.Form.ContainsKey("hashparams") ? Request.Form["hashparams"] : "";
            // Dönen parametrelerin isimlerine göre tek tek değerleri alınır
            string[] paramList = responseHashparams.Split(separator);
            foreach (string param in paramList)
            {
                if (Request.Form.ContainsKey(param)) // Key'in var olup olmadığını kontrol ediyoruz
                {
                    digestData += Request.Form[param]; // Eğer varsa değeri ekliyoruz
                }
                else
                {
                    digestData += ""; // Yoksa bir şey eklemiyoruz (boş bırakıyoruz)
                }
            }
            // Sonuna store key eklenir
            digestData += strStoreKey;
            // Aşağıdaki gibi şifreleme uygulanır
            using (var sha = new System.Security.Cryptography.SHA512CryptoServiceProvider())
            {
                byte[] hashbytes = System.Text.Encoding.GetEncoding("ISO-8859-9").GetBytes(digestData);
                byte[] inputbytes = sha.ComputeHash(hashbytes);
                string hashCalculated = Convert.ToBase64String(inputbytes);
                if (responseHash.Equals(hashCalculated))
                {
                    // MESAJ BANKADAN GELİYOR
                    isValidHash = true;
                    return View();
                }
            }
            return Content("!!!!!" + Request.Form["mderrormessage"] + "!!!!!");
        }
    }
}

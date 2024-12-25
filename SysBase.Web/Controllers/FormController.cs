using DocumentFormat.OpenXml.Drawing.Charts;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.EntityFrameworkCore;
using SysBase.Core.Models;
using SysBase.Core.Services;
using SysBase.Service.Functions;
using SysBase.Web.Models;
using SysBase.Web.Resources;
using SysBase.Web.ViewModels;
using System.Diagnostics;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace SysBase.Web.Controllers
{
    public class FormController : BaseController
    {
        protected Functions functions = new Functions();
        private readonly ILogger<FormController> _logger;
        protected readonly IService<SiteMenu> _siteMenuService;
        protected readonly IService<FooterMenu> _footerMenuService;
        protected readonly IService<Language> _languageService;
        protected readonly IService<QuickMenu> _quickMenuService;
        protected readonly IService<ProjectProduct> _projectProductService;
        protected readonly IService<ProjectField> _projectFieldService;
        protected readonly IService<City> _cityService;
        protected readonly IService<County> _countyService;
        protected readonly IService<ApiBasvuruRequest> _apiBasvuruRequestService;
        protected readonly IService<ConfigLanguageInfo> _configLanguageInfoService;

        public FormController(IHtmlLocalizer<SharedResource> localizer, IService<Config> service,
           ILogger<FormController> logger, IService<SiteMenu> siteMenuService, IService<FooterMenu> footerMenuService,
           IService<Language> languageService, IService<QuickMenu> quickMenuService, IService<ProjectProduct> projectProductService, IService<ProjectField> projectFieldService, IService<City> cityService, IService<County> countyService, IService<ApiBasvuruRequest> apiBasvuruRequestService, IService<ConfigLanguageInfo> configLanguageInfoService)
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
            _configLanguageInfoService = configLanguageInfoService;
        }

        public async Task<IActionResult> Index(string slug)
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

            List<ProjectProduct> projectProducts = new List<ProjectProduct>();
            if (slug != null && slug != "")
            {
                if (slug.EndsWith("-Y"))
                {
                    string code = slug.Split('-')[0];
                    projectProducts = await _projectProductService
                        .Where(x => x.Project.Code == slug && x.Project.Status && x.Product.Status && x.Product.Type == 2 && x.Project.StartDate < DateTime.Now && x.Project.EndDate > DateTime.Now)
                        .Include(x => x.Project)
                        .ThenInclude(x => x.Company)
                        .Include(x => x.Product)
                        .ThenInclude(x => x.ProductLanguageInfos.Where(lng => lng.Language.Code == CultureInfo.CurrentCulture.Name))
                        .ToListAsync();
                }
                else
                {
                    string code = slug.Split('-')[0];
                    projectProducts = await _projectProductService
                        .Where(x => x.Project.Code == slug && x.Project.Status && x.Product.Status && x.Product.Type == 1 && x.Project.StartDate < DateTime.Now && x.Project.EndDate > DateTime.Now)
                        .Include(x => x.Project)
                        .ThenInclude(x => x.Company)
                        .Include(x => x.Product)
                        .ThenInclude(x => x.ProductLanguageInfos.Where(lng => lng.Language.Code == CultureInfo.CurrentCulture.Name))
                        .ToListAsync();
                }
            }
            if (projectProducts.Count() == 0)
            {
                projectProducts = await _projectProductService
                    .Where(x => x.Project.Id == 1 && x.Project.Status && x.Product.Status)
                    .Include(x => x.Project)
                    .ThenInclude(x => x.Company)
                    .Include(x => x.Product)
                    .ThenInclude(x => x.ProductLanguageInfos.Where(lng => lng.Language.Code == CultureInfo.CurrentCulture.Name))
                    .ToListAsync();
            }

            List<ProjectField> projectFields = new List<ProjectField>();
            projectFields = await _projectFieldService.Where(x => x.ProjectId == projectProducts[0].ProjectId && x.Visible).Include(x => x.Field).OrderBy(x => x.Field.Sequence).ToListAsync();

            FormViewModel model = new FormViewModel
            {
                Config = uiLayoutViewModel.Config,
                SiteMenus = uiLayoutViewModel.SiteMenus,
                FooterMenus = uiLayoutViewModel.FooterMenus,
                Languages = uiLayoutViewModel.Languages,
                QuickMenus = uiLayoutViewModel.QuickMenus,
                ProjectProducts = projectProducts,
                ProjectFields = projectFields,
                Cities = await _cityService.Where(x => x.CountryId == 2).OrderBy(x => x.Name).ToListAsync(),
                ConfigLanguageInfo = await _configLanguageInfoService.Where(c => c.Language.Code == CultureInfo.CurrentCulture.Name && c.Status).FirstOrDefaultAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ResultJson> Kayit(ApiBasvuruRequest model, IFormFile Dosya, string[] UrunList)
        {
            ResultJson resultJson = new ResultJson { status = "error" };
            ApiBasvuruRequest isControl;
            try
            {
                string[] allowedExtensions = { ".zip", ".rar", ".exe", ".deb", ".xls", ".xlsx", ".doc", ".docx" };
                if (Dosya != null && Dosya.Length > 0)
                {
                    model.Dosya = await functions.FileUpload(Dosya, "Images/Basvuru", Guid.NewGuid().ToString("N"), allowedExtensions);
                }
                else if (model.Id != 0)
                {
                    model.Dosya = await functions.FileUpload(Dosya, "Images/Basvuru", Guid.NewGuid().ToString("N"), allowedExtensions);
                }

                List<int> urunArray = UrunList.Select(item => Convert.ToInt32(item)).ToList();

                List<ProjectProduct> projectProducts = await _projectProductService
                .Where(x => urunArray.Contains(x.Id) && x.Project.Status && x.Product.Status)
                .Include(x => x.Product)
                .ThenInclude(x => x.ProductLanguageInfos)
                .ToListAsync();
                decimal toplamFiyat = 0;
                decimal toplamKdv = 0;
                string crmUrunler = "";
                foreach (ProjectProduct item in projectProducts)
                {
                    toplamFiyat += item.Amount;
                    toplamKdv += item.Amount / 100 * item.Product.Tax;
                    crmUrunler += "<urun> " +
                    "            <urunad>" + item.Product.ProductLanguageInfos[0].Title + "</urunad><!--excel 'de var--> " +
                    "            <urunkod>" + item.Product.Id + "</urunkod> <!--excel 'de var--> " +
                    "            <adet>1</adet> <!--adet--> " +
                    "            <fiyat>" + (item.Amount + (item.Amount / 100 * item.Product.Tax)) + "</fiyat> <!--fiyat double--> " +
                    "          </urun>";
                }

                model.ProjectProductId = urunArray[0];
                model.Uid = Guid.NewGuid().ToString("N");
                model.OdemeTutar = (toplamFiyat + toplamKdv);
                isControl = await _apiBasvuruRequestService.AddAsync(model);
                if (isControl.Id != 0)
                {
                    ProjectProduct projectProduct = await _projectProductService
                    .Where(x => x.Id == model.ProjectProductId)
                    .Include(x => x.Project)
                    .ThenInclude(x => x.Company)
                    .Include(x => x.Product)
                    .ThenInclude(x => x.ProductLanguageInfos.Where(lng => lng.Language.Code == CultureInfo.CurrentCulture.Name))
                    .FirstOrDefaultAsync();

                    if (!projectProduct.Project.PaymetForm || model.OdemeTipi == 2)
                    {
                        //CrmSend(model, crmUrunler);
                    }

                    resultJson.status = "success";
                    resultJson.message = _localizer["admin.Kayıt İşlemi Başarıyle Gerçekleşmiştir."].Value;
                    resultJson.data = model.Uid;
                }
                else
                {
                    resultJson.message = _localizer["admin.Bilgileri Kontrol Ediniz"].Value;
                }
            }
            catch (Exception ex)
            {
                resultJson.message = $"Hata: {ex.Message}";
            }

            return resultJson;
        }

        public async Task<IActionResult> CrmGonderim(string slug)
        {
            if (slug != "ZknF8ee2rpTAdJpcjJJAj6")
            {
                return Content("Token Hatalı.");
            }
            int sayac = 0;
            foreach (ApiBasvuruRequest item in await _apiBasvuruRequestService.ToListAsync())
            {
                CrmSend(item, "");
                sayac++;
            }

            return Content(sayac + " İşlem Tamamlandı");
        }

        protected async void CrmSend(ApiBasvuruRequest model, string crmUrunler)
        {
            string DogumTarihi = "";
            if (model.DogumTarihi != null)
            {
                DogumTarihi = model.DogumTarihi?.ToString("dd.MM.yyyy");
            }

            ProjectProduct projectProduct = await _projectProductService
                .Where(x => x.Id == model.ProjectProductId)
                .Include(x => x.Project)
                .ThenInclude(x => x.Company)
                .Include(x => x.Product)
                .ThenInclude(x => x.ProductLanguageInfos.Where(lng => lng.Language.Code == CultureInfo.CurrentCulture.Name))
                .FirstOrDefaultAsync();

            if (crmUrunler == "")
            {
                crmUrunler += "<urun> " +
                    "            <urunad>" + projectProduct.Product.ProductLanguageInfos[0].Title + "</urunad><!--excel 'de var--> " +
                    "            <urunkod>" + projectProduct.Product.Id + "</urunkod> <!--excel 'de var--> " +
                    "            <adet>1</adet> <!--adet--> " +
                    "            <fiyat>" + (projectProduct.Amount + (projectProduct.Amount / 100 * projectProduct.Product.Tax)) + "</fiyat> <!--fiyat double--> " +
                    "          </urun>";
            }

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://192.168.127.25:5558/Web2.svc");
            request.Headers.Add("SOAPAction", "http://tempuri.org/IWeb2/CRMSATIS");
            var content = new StringContent("<?xml version=\"1.0\" encoding=\"utf-8\"?> " +
                "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\"> " +
                "  <soap:Header/> " +
                "  <soap:Body> " +
                "    <CRMSATIS xmlns=\"http://tempuri.org/\"> " +
                "      <basvururequest> " +
                "        <kanal></kanal><!--boş mu olacak->BOŞ evet-->  " +
                "        <Durum></Durum><!--boş mu olacak->BOŞ evet--> " +
                "        <KayitID>" + model.Uid + "</KayitID>  <!--boş mu olacak->uniq id olacak--> " +
                "        <SiparisAdi>" + model.SiparisAdi + "</SiparisAdi> <!--boş mu olacak->zorunlu alan değil, string kafamıza göre--> " +
                "        <Sirket>" + model.Sirket + "</Sirket>  <!--şahıslarda şirket bilgilsi ve vergi no olmadığı için boş mu göndereceğiz->zorunlu değil--> " +
                "        <VergiNo>" + model.VergiNo + "</VergiNo> " +
                "        <VergiDairesi>" + model.VergiDairesi + "</VergiDairesi> " +
                "        <TCKimlikNo>" + model.TCKimlikNo + "</TCKimlikNo> " +
                "        <AdSoyad>" + model.AdSoyad + "</AdSoyad> " +
                "        <DogumTarihi>" + DogumTarihi + "</DogumTarihi> <!--Doğru tarihi bu şekilde doğru mudur?ay.gün.yıl-> format doğru--> " +
                "        <DogumYeri>" + model.DogumYeri + "</DogumYeri> " +
                "        <Eposta>" + model.Eposta + "</Eposta> " +
                "        <Uyruk>" + model.Uyruk + "</Uyruk>  <!--TC bu şekilde doğru mu, doğru--> " +
                "        <ilkKullanmaTarihi>" + DateTime.Now.ToString("dd.MM.yyyy") + "</ilkKullanmaTarihi> <!--Yeni başvurularda olacak mı, var olan yenilemelerde bu tarihleri nereden alacağız.->kaç yıllık ise bugünden itiabren + alınan yıl üzerine koyularak eklenecek tarih, tarih formatı 01.01.1990--> " +
                "        <SonKullanmaTarihi>" + DateTime.Now.AddYears(projectProduct.Product.Year).ToString("dd.MM.yyyy") + "</SonKullanmaTarihi> " +
                "        <IPAdresi>" + HttpContext.Connection.RemoteIpAddress?.ToString() + "</IPAdresi> " +
                "        <Teslimat_Adresi>" + model.TeslimatAdresi + "</Teslimat_Adresi> " +
                "        <Il>" + model.Il + "</Il> " +
                "        <Ilce>" + model.Ilce + "</Ilce> " +
                "        <PostaKodu>" + model.PostaKodu + "</PostaKodu> " +
                "        <Telefon>" + model.Telefon + "</Telefon> <!--Telefon formatı bu şekilde doğru mudur?--> " +
                "        <CepTelefonu>" + model.CepTelefonu + "</CepTelefonu> " +
                "        <Fax>" + model.Fax + "</Fax> <!--Yoksa boş mu gönderilecek--> " +
                "        <Aciklama>" + model.Aciklama + "</Aciklama> " +
                "        <EmailAdresiSertifikadaGorulsun>true</EmailAdresiSertifikadaGorulsun> " +
                "        <ProjeAdi>" + projectProduct.Project.Code + "</ProjeAdi> <!--ne yazılacak,boş gidebilir--> " +
                "        <OdemeSekli>ODEME_SEKLI</OdemeSekli> <!--ödeme şekilleri standart mı, ne açıklamada göndereceğiz, boş geçilebilir--> " +
                "        <OdemeMiktari>" + (projectProduct.Amount + (projectProduct.Amount / 100 * projectProduct.Product.Tax)) + "</OdemeMiktari> <!--ne açıklamada göndereceğiz, string olarak rasgele yazsak kabul eder mi, boş geçilebilir--> " +
                "        <kurulumVarMi>false</kurulumVarMi> <!--VIP se true, değilse false mu olacak, vip ise true olacak--> " +
                "        <FirmaUnvani>" + model.FirmaUnvani + "</FirmaUnvani> <!--Şahıslarda boş mu olacak, ünvanda ne geçiyorsa yukarıda, aynısı olacak--> " +
                "        <Yil>" + projectProduct.Product.Year + "</Yil> <!--hangi projenin yılı, tam anlamadık, ürünün alım yılı kaçsa o , mesela 1 sene ise 1 yıl--> " +
                "        <Avukat>false</Avukat> <!--bunu tam olarak anlamadık, her zaman false olacak--> " +
                "        <izin>" + model.Izin + "</izin> <!--sözleşme mi?, eğer formdan onay verilirse hepsi true olacak--> " +
                "        <pass></pass> <!--parola nedir?--> " +
                "        <kimlikdogrulandi>true</kimlikdogrulandi> <!--NVI doğrulama değil mi?, boş gönderilecek her zaman--> " +
                "        <pasaportno>" + model.PasaportNo + "</pasaportno> " +
                "        <urunler><!--ürünlere örnek gönderim nasıl olacak, kafamıza göre açıklayıcı ürün isimlerini göndersek olur mu--> " +
                        crmUrunler +
                "        </urunler> " +
                "        <istest>false</istest> " +
                "        <guvenliksozcugu>" + model.GuvenlikSozcugu + "</guvenliksozcugu> <!--güvenlik şifreniz nedir?->formda sorulan soru--> " +
                "        <onaytik>true</onaytik> <!--formdaki sözleşmelerden biri mi?eğer formdan onay verilirse hepsi true olacak--> " +
                "        <kvkonaytik>true</kvkonaytik><!--formdaki sözleşmelerden biri olarak baz alacağız,eğer formdan onay verilirse hepsi true olacak--> " +
                "        <TCSeriNo>" + model.TCSeriNo + "</TCSeriNo> " +
                "        <GizliSoru>" + model.GizliSoru + "</GizliSoru> " +
                "        <DeliveryType></DeliveryType><!--teslimat tipleriniz nedir?, kafamıza göre yazsak olur mu,->her zaman boş olacak--> " +
                "        <nvidogrulama></nvidogrulama> <!--şimdilik boş--> " +
                "        <PdfErisimToken></PdfErisimToken> <!--Bu tam olarak nedir? token ı nereden alacağız., boş olacak her zaman--> " +
                "        <isedevlet>true</isedevlet> <!--faz 1 de yok değil mi-> form son syafasında e-devleti seçerse true olacak, değilse false olacak--> " +
                "        <emuhurkisi></emuhurkisi> <!--E-mühür ürünü alındığında aşağıdaki bilgiler gönderilecek bilgiler mi?, şuanlık boş geçilecek--> " +
                "        <emuhurtc></emuhurtc> " +
                "        <emuhurvergiil></emuhurvergiil> " +
                "        <emuhurvergidairesi></emuhurvergidairesi> " +
                "        <emuhurvergino></emuhurvergino> " +
                "        <ikincikisitc></ikincikisitc> " +
                "        <kepadres></kepadres> " +
                "        <ikincikisiadsoyad></ikincikisiadsoyad> " +
                "      </basvururequest> " +
                "    </CRMSATIS> " +
                "  </soap:Body> " +
                "</soap:Envelope> " +
                "", null, "text/xml");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);

            if (false)
            {
                await _apiBasvuruRequestService.RemoveAsync(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> GarantiModal(string uid, string dateMonth, string dateYear, string cardAdSoyad, string cardNo, string code)
        {
            ApiBasvuruRequest apiBasvuruRequest = await _apiBasvuruRequestService.Where(x => x.Uid == uid).FirstOrDefaultAsync();
            List<ProjectProduct> projectProducts = await _projectProductService
              .Where(x => x.Id == apiBasvuruRequest.ProjectProductId && x.Project.Status && x.Product.Status)
              .Include(x => x.Product)
              .ThenInclude(x => x.ProductLanguageInfos)
              .ToListAsync();
            decimal toplamFiyat = 0;
            decimal toplamKdv = 0;
            foreach (ProjectProduct item in projectProducts)
            {
                toplamFiyat += item.Amount;
                toplamKdv += item.Amount / 100 * item.Product.Tax;
            }


            var hashedPassword = GVPOSHelper.Sha1(GVPOSConfigurations.ProvUserPassword + GVPOSHelper.IsRequireZero(GVPOSConfigurations.TerminalID_For_3D_PAY, 9)).ToUpper();
            var hash = GVPOSHelper.ThreeDHashData(GVPOSConfigurations.TerminalID_For_3D_PAY, apiBasvuruRequest.Uid, Convert.ToInt32((toplamFiyat + toplamKdv) * 100).ToString(), 949, "https://eguven.sisord.net/thanks", "https://eguven.sisord.net/paymenterror", "sales", "", "12345678", hashedPassword);
            return View(new GarantiModalViewModel
            {
                ApiBasvuruRequest = apiBasvuruRequest,
                dateMonth = dateMonth,
                dateYear = dateYear,
                cardAdSoyad = cardAdSoyad,
                cardNo = cardNo,
                code = code,
                //ThreeDHashData(string terminalID, string orderID, string amount, int currencyCode, string successUrl, string errorUrl, string type, string installmentCount, string storeKey, string hashedPassword)
                Hash = hash
            });
        }

        [HttpPost]
        public async Task<String> IlIlce(string il)
        {
            string selectOptionList = "<option>" + _localizer["admin.Seçiniz"].Value + "</option>";
            foreach (County item in await _countyService.Where(x => x.City.Name == il).OrderBy(x => x.Name).ToListAsync())
            {
                selectOptionList += "<option value='" + item.Name + "'>" + item.Name + "</option>";
            }
            return selectOptionList;
        }

        [HttpPost]
        public async Task<IActionResult> SepetList(string UrunList)
        {
            int[] urunArray = UrunList.Split(',').Select(int.Parse).ToArray();

            List<ProjectProduct> projectProducts = await _projectProductService
                .Where(x => urunArray.Contains(x.Id) && x.Project.Status && x.Product.Status)
                .Include(x => x.Product)
                .ThenInclude(x => x.ProductLanguageInfos)
                .ToListAsync();

            return View(projectProducts);
        }

    }
}

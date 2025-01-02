using Azure.Core;
using CrmService;
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
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

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
        protected readonly IService<Company> _companyService;
        protected readonly IService<CompanyInvoice> _companyInvoiceService;
        protected readonly IService<PageLanguageInfo> _pageLanguageInfoService;

        public FormController(IHtmlLocalizer<SharedResource> localizer, IService<Config> service,
           ILogger<FormController> logger, IService<SiteMenu> siteMenuService, IService<FooterMenu> footerMenuService,
           IService<Language> languageService, IService<QuickMenu> quickMenuService, IService<ProjectProduct> projectProductService, IService<ProjectField> projectFieldService, IService<City> cityService, IService<County> countyService, IService<ApiBasvuruRequest> apiBasvuruRequestService, IService<ConfigLanguageInfo> configLanguageInfoService, IService<CompanyInvoice> companyInvoiceService, IService<Company> companyService, IService<PageLanguageInfo> pageLanguageInfoService)
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
            _companyInvoiceService = companyInvoiceService;
            _companyService = companyService;
            _pageLanguageInfoService = pageLanguageInfoService;
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
                        .ThenInclude(x => x.ProjectLanguageInfos.Where(lng => lng.Language.Code == CultureInfo.CurrentCulture.Name))
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
                        .ThenInclude(x => x.ProjectLanguageInfos.Where(lng => lng.Language.Code == CultureInfo.CurrentCulture.Name))
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
                    .ThenInclude(x => x.ProjectLanguageInfos.Where(lng => lng.Language.Code == CultureInfo.CurrentCulture.Name))
                    .Include(x => x.Product)
                    .ThenInclude(x => x.ProductLanguageInfos.Where(lng => lng.Language.Code == CultureInfo.CurrentCulture.Name))
                    .ToListAsync();
            }

            List<ProjectField> projectFields = new List<ProjectField>();
            projectFields = await _projectFieldService.Where(x => x.ProjectId == projectProducts[0].ProjectId && x.Visible && x.Field.Status).Include(x => x.Field).OrderBy(x => x.Field.Sequence).ToListAsync();

            CompanyInvoice companyInvoice = new CompanyInvoice();
            if (projectProducts[0] != null && projectProducts[0].Project.CompanyId != null)
            {
                companyInvoice = await _companyInvoiceService.Where(x => x.CompanyId == projectProducts[0].Project.CompanyId).FirstOrDefaultAsync();
            }

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
                ConfigLanguageInfo = await _configLanguageInfoService.Where(c => c.Language.Code == CultureInfo.CurrentCulture.Name && c.Status).FirstOrDefaultAsync(),
                Company = await _companyService.Where(c => c.Id == projectProducts[0].Project.CompanyId && c.Status).FirstOrDefaultAsync(),
                CompanyInvoice = companyInvoice,
                AydinlatmaMetni = await _pageLanguageInfoService.Where(x => x.Status && x.Page.Code == "44316b9d0dfa45168b2bed9435b3f7ce" && x.Language.Code == CultureInfo.CurrentCulture.Name && x.Status && x.Page.Status).FirstOrDefaultAsync(),
                HavaleEft = await _pageLanguageInfoService.Where(x => x.Status && x.Page.Code == "303ac68194e84761b3b4ed91958a2451" && x.Language.Code == CultureInfo.CurrentCulture.Name && x.Status && x.Page.Status).FirstOrDefaultAsync(),
                OnBilgilendirme = await _pageLanguageInfoService.Where(x => x.Status && x.Page.Code == "bbbdb13fc0b94b8682906b0da0492aeb" && x.Language.Code == CultureInfo.CurrentCulture.Name && x.Status && x.Page.Status).FirstOrDefaultAsync(),
                MesafeliSatis = await _pageLanguageInfoService.Where(x => x.Status && x.Page.Code == "4a6fb246a430437ea076bc586d878a3f" && x.Language.Code == CultureInfo.CurrentCulture.Name && x.Status && x.Page.Status).FirstOrDefaultAsync()
            };
            ViewData["slug"] = slug;
            return View(model);
        }

        [HttpPost]
        public async Task<ResultJson> Kayit(ApiBasvuruRequest model,string Ad, string Soyad, IFormFile Dosya, string[] UrunList, [FromForm(Name = "cf-turnstile-response")] string cfTurnstileResponse)
        {
            ResultJson resultJson = new ResultJson { status = "error" };
            string resCT = await functions.CloudflareTurnstile(cfTurnstileResponse);
            if (resCT != "1")
            {
                resultJson.message = resCT;
                return resultJson;
            }
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

                //sipariş kodu ilerletildi
                Config config = _service.Where(x => x.Id == 1).FirstOrDefault();
                int siparisKodu = config.SiparisKodu + 1;
                config.SiparisKodu = siparisKodu;
                await _service.UpdateAsync(config);

                model.ProjectProductId = urunArray[0];
                model.Uid = Guid.NewGuid().ToString("N");
                model.OdemeTutar = (toplamFiyat + toplamKdv);
                model.SiparisKodu = siparisKodu;
                model.AdSoyad = Ad + " " + Soyad;

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
                    resultJson.message = _localizer["Kayıt İşlemi Başarıyle Gerçekleşmiştir."].Value;
                    resultJson.data = model.Uid;
                }
                else
                {
                    resultJson.message = _localizer["Bilgileri Kontrol Ediniz"].Value;
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
            string odemeSekli = "Kredi Kartı";
            if (model.OdemeTipi==2)
            {
                odemeSekli = "Havale";
            }

            var client = new Web2Client(Web2Client.EndpointConfiguration.BasicHttpBinding_IWeb2);
            try
            {
                // basvururequest nesnesi oluşturuluyor
                var request = new basvururequest
                {
                    Aciklama = model.Aciklama,
                    AdSoyad = model.AdSoyad,
                    Avukat = false,
                    CepTelefonu = model.CepTelefonu,
                    DeliveryType = "Standard",
                    DogumTarihi = DogumTarihi,
                    DogumYeri = "",
                    Durum = 1,
                    EmailAdresiSertifikadaGorulsun = model.EmailAdresiSertifikadaGorulsun.ToString(),
                    Eposta = model.Eposta,
                    FaturaAdresiCepTelefonu = model.Telefon,
                    FaturaAdresiDetay = model.FaturaAdresiDetay,
                    FaturaAdresiFax = model.FaturaAdresiFax,
                    FaturaAdresiIl = model.FaturaAdresiIl,
                    FaturaAdresiIlce = model.FaturaAdresiIlce,
                    FaturaAdresiPostaKodu = model.PostaKodu,
                    FaturaAdresiTelefon = model.Telefon,
                    Fax = model.FaturaAdresiFax,
                    FirmaUnvani = model.FirmaUnvani,
                    GizliSoru = "",
                    IPAdresi = HttpContext.Connection.RemoteIpAddress?.ToString(),
                    Il = model.Il,
                    Ilce = model.Ilce,
                    KayitID = model.Uid,
                    KurulumAdresiCepTelefonu = "",
                    KurulumAdresiDetay = "",
                    KurulumAdresiFax = "",
                    KurulumAdresiIl = "",
                    KurulumAdresiIlce = "",
                    KurulumAdresiPostaKodu = "",
                    KurulumAdresiTelefon = "",
                    OdemeMiktari = (projectProduct.Amount + (projectProduct.Amount / 100 * projectProduct.Product.Tax)).ToString(),
                    OdemeSekli = odemeSekli,
                    PdfErisimToken = "",
                    PostaKodu = model.PostaKodu,
                    ProjeAdi = projectProduct.Project.Code,
                    SiparisAdi = model.SiparisAdi,
                    Sirket = model.FirmaUnvani,
                    SonKullanmaTarihi = DateTime.Now.AddYears(projectProduct.Product.Year).ToString("dd.MM.yyyy"),
                    TCKimlikNo = model.TCKimlikNo,
                    TCSeriNo = model.TCSeriNo,
                    Telefon = model.Telefon,
                    Teslimat_Adresi = model.TeslimatAdresi,
                    Uyruk = model.Uyruk,
                    VergiDairesi = model.VergiDairesi,
                    VergiNo = model.VergiNo,
                    Yil = projectProduct.Product.Year.ToString(),
                    emuhurkisi = "",
                    emuhurtc = "",
                    emuhurvergidairesi = "",
                    emuhurvergiil = "",
                    emuhurvergino = "",
                    guvenliksozcugu = model.GuvenlikSozcugu,
                    ikincikisiadsoyad = "",
                    ikincikisitc = "",
                    ilkKullanmaTarihi = DateTime.Now.ToString("dd.MM.yyyy"),
                    isedevlet = true,
                    istest = false,
                    izin = model.Izin,
                    kanal = "",
                    kepadres = "",
                    kimlikdogrulandi = true,
                    kurulumVarMi = false,
                    kvkonaytik = "true",
                    nvidogrulama = "true",
                    onaytik = "true",
                    pasaportno = model.TCKimlikNo,
                    pass = "EgVn2016",
                    urunler = new urun[]
                    {
                        new urun {
                            adet = 1,
                            fiyat = (projectProduct.Amount + (projectProduct.Amount / 100 * projectProduct.Product.Tax)),
                            urunad = projectProduct.Product.ProductLanguageInfos[0].Title,
                            urunkod =projectProduct.Product.Id.ToString()
                        },
                    },
                };
                // CRMSATIS servisine istek gönderiliyor
                var response = await client.CRMSATISAsync(request);
                // Yanıt ekrana yazdırılıyor
                Debug.WriteLine("CRM SATIŞ Yanıtı:");
                Debug.WriteLine($"CRM ID: {response.CRMID}");
                Debug.WriteLine($"Hata Mesajı: {response.errormessage}");
                Debug.WriteLine($"Durum: {response.status}");
            }
            catch (Exception ex)
            {
                // Hata durumunda çıktı
                Debug.WriteLine($"Hata: {ex.Message}");
            }
            finally
            {
                // İstemciyi kapat
                if (client.State == System.ServiceModel.CommunicationState.Opened)
                    await client.CloseAsync();
            }

            /*//ESKİ KOD
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
            Debug.WriteLine(result);
            */
            if (false)
            {
                model.CrmGonderim = true;
                await _apiBasvuruRequestService.UpdateAsync(model);
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
        public async Task<ResultJson> CrmTcKontrol(string TCKimlikNo, string Tel)
        {
            ResultJson resultJson = new ResultJson { status = "error" };

            var client = new Web2Client(Web2Client.EndpointConfiguration.BasicHttpBinding_IWeb2);
            try
            {
                string response = await client.SMSCodeForMobileAsync("token", TCKimlikNo, Regex.Replace(Tel, @"[^\d]", ""));
                // Yanıtı gösterin
                Debug.WriteLine($"Result: {response}");
                if (response.Contains("Success"))
                {
                    resultJson.status = "success";
                    if (response.Split(" ").Length > 1 && response.Split(" ")[1] != null && response.Split(" ")[1] != "")
                    {
                        HttpContext.Session.SetString("SmsKod", GVPOSHelper.Sha512(response.Split(" ")[1]));
                        resultJson.data = GVPOSHelper.Sha512(response.Split(" ")[1]);
                    }
                }
                else
                {
                    resultJson.status = "error";
                    resultJson.message = response.Replace("error ", "");
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

        [HttpPost]
        public async Task<ResultJson> SmsKodDogrula(string kod)
        {
            ResultJson resultJson = new ResultJson { status = "error" };
            string hasKod = GVPOSHelper.Sha512(kod);
            if (hasKod == HttpContext.Session.GetString("SmsKod"))
            {
                resultJson.status = "success";
                resultJson.message = "Sms Kodu Doğrulandı";
            }
            else
            {
                resultJson.status = "error";
                resultJson.message = "Sms Kodu Doğrulanamadı";
            }
            return resultJson;
        }


        [HttpPost]
        public async Task<ResultJson> TcDogrulama(string TCKimlikNo, string Ad, string Soyad, string DogumYili)
        {
            ResultJson resultJson = new ResultJson { status = "error" };
            // SOAP XML
            string soapRequest = $@"<soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
            <soap:Body>
                <TCKimlikNoDogrula xmlns=""http://tckimlik.nvi.gov.tr/WS"">
                    <TCKimlikNo>{TCKimlikNo}</TCKimlikNo>
                    <Ad>{Ad}</Ad>
                    <Soyad>{Soyad}</Soyad>
                    <DogumYili>{DogumYili}</DogumYili>
                </TCKimlikNoDogrula>
            </soap:Body>
            </soap:Envelope>";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://tckimlik.nvi.gov.tr/service/kpspublic.asmx");
                    // Header bilgileri
                    request.Headers.Add("SOAPAction", "http://tckimlik.nvi.gov.tr/WS/TCKimlikNoDogrula");
                    request.Content = new StringContent(soapRequest, Encoding.UTF8, "text/xml");
                    // İstek gönderme
                    HttpResponseMessage response = await client.SendAsync(request);
                    // Yanıt okuma
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine(responseContent);
                    // Basit bir doğrulama sonucu kontrolü
                    if (responseContent.Contains("<TCKimlikNoDogrulaResult>true</TCKimlikNoDogrulaResult>"))
                    {
                        resultJson.status = "success";
                        resultJson.message = "TC Kimlik Numarası geçerli.";
                        resultJson.data = "true";
                    }
                    else
                    {
                        resultJson.status = "error";
                        resultJson.message = "TC Kimlik Numarası geçersiz.";
                    }
                }
            }
            catch (Exception ex)
            {
                resultJson.status = "error";
                resultJson.message = $"Bir hata oluştu: {ex.Message}";
            }
            return resultJson;
        }

        [HttpPost]
        public async Task<String> IlIlce(string il)
        {
            string selectOptionList = "<option>" + _localizer["Seçiniz"].Value + "</option>";
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

using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SysBase.Core.Models;
using SysBase.Core.Services;
using SysBase.Service.Functions;
using SysBase.Web.Resources;
using SysBase.Web.ViewModels;
using System.Diagnostics;
using System.Globalization;
using System.Web.Helpers;

namespace SysBase.Web.Controllers
{
    public class ThanksController : BaseController
    {
        protected Functions functions = new Functions();
        private readonly ILogger<ThanksController> _logger;
        protected readonly IService<SiteMenu> _siteMenuService;
        protected readonly IService<FooterMenu> _footerMenuService;
        protected readonly IService<Language> _languageService;
        protected readonly IService<QuickMenu> _quickMenuService;
        protected readonly IService<ProjectProduct> _projectProductService;
        protected readonly IService<ProjectField> _projectFieldService;
        protected readonly IService<City> _cityService;
        protected readonly IService<County> _countyService;
        protected readonly IService<ApiBasvuruRequest> _apiBasvuruRequestService;
        protected readonly IService<PageLanguageInfo> _pageLanguageInfoService;
        protected readonly IService<MailTemplateLanguageInfo> _mailTemplateLanguageInfoService;

        public ThanksController(IHtmlLocalizer<SharedResource> localizer, IService<Config> service,
           ILogger<ThanksController> logger, IService<SiteMenu> siteMenuService, IService<FooterMenu> footerMenuService,
           IService<Language> languageService, IService<QuickMenu> quickMenuService, IService<ProjectProduct> projectProductService, IService<ProjectField> projectFieldService, IService<City> cityService, IService<County> countyService, IService<ApiBasvuruRequest> apiBasvuruRequestService, IService<PageLanguageInfo> pageLanguageInfoService, IService<MailTemplateLanguageInfo> mailTemplateLanguageInfoService)
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
            _pageLanguageInfoService = pageLanguageInfoService;
            _mailTemplateLanguageInfoService = mailTemplateLanguageInfoService;
        }

        public async Task<IActionResult> Index(string slug)
        {
            UiLayoutViewModel uiLayoutViewModel = new UiLayoutViewModel();
            uiLayoutViewModel.Config = _service.Where(x => x.Id == 1).FirstOrDefault();
            uiLayoutViewModel.SiteMenus = _siteMenuService.Where(x => x.Status && x.Language.Code == CultureInfo.CurrentCulture.Name).OrderBy(x => x.Sequence).ToList();
            uiLayoutViewModel.FooterMenus = _footerMenuService.Where(x => x.Status && x.Language.Code == CultureInfo.CurrentCulture.Name).OrderBy(x => x.Sequence).ToList();
            uiLayoutViewModel.Languages = _languageService.Where(x => x.Status).ToList();
            uiLayoutViewModel.QuickMenus = _quickMenuService.Where(x => x.Status && x.Language.Code == CultureInfo.CurrentCulture.Name).OrderBy(x => x.Sequence).ToList();
            ApiBasvuruRequest apiBasvuruRequest = new ApiBasvuruRequest();

            if (slug == "" || slug == null)
            {
                Debug.WriteLine(Request.Form.Keys);
                Debug.WriteLine(Request.Form["procreturncode"]);
                if (Request.Form["procreturncode"] != "00")
                {
                    return Content("!!!!!" + Request.Form["mderrormessage"] + "!!!!!");
                }

                var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
                var langCode = rqf.RequestCulture.Culture;
                Debug.WriteLine(langCode);

                string Uid = Request.Form["orderid"];
                apiBasvuruRequest = await _apiBasvuruRequestService.Where(x => x.Uid == Uid).FirstOrDefaultAsync();
                apiBasvuruRequest.OdemeCevap = JsonConvert.SerializeObject(Request.Form);
                await _apiBasvuruRequestService.UpdateAsync(apiBasvuruRequest);
            }
            else
            {
                apiBasvuruRequest = await _apiBasvuruRequestService.Where(x => x.Uid == slug).FirstOrDefaultAsync();
            }

            if (apiBasvuruRequest.Eposta != "" && apiBasvuruRequest.Eposta != null)
            {
                Mail mail = new Mail();
                mail.Email = apiBasvuruRequest.Eposta;
                mail.Subject = _localizer["Siparişiniz Alındı"].Value;
                string odemeSekli = "Havale";
                if (apiBasvuruRequest.OdemeTipi == 1)
                {
                    odemeSekli = "Kredi Kartı";
                }
                string FaturaAdresi = apiBasvuruRequest.FaturaAdresiDetay;
                if (apiBasvuruRequest.KurulumAdresiDetay != null && apiBasvuruRequest.KurulumAdresiDetay != "")
                {
                    FaturaAdresi = apiBasvuruRequest.KurulumAdresiDetay;
                }

                ProjectProduct projectProduct = await _projectProductService
               .Where(x => x.Id == apiBasvuruRequest.ProjectProductId)
               .Include(x => x.Project)
               .ThenInclude(x => x.Company)
               .Include(x => x.Product)
               .ThenInclude(x => x.ProductLanguageInfos.Where(lng => lng.Language.Code == CultureInfo.CurrentCulture.Name))
               .FirstOrDefaultAsync();

                mail.Message = "<div style=\"background-color:#f3f3f3;margin:0px\">\r\n\r\n    <table cellpadding=\"50\" cellspacing=\"0\" border=\"0\" width=\"100%\" align=\"center\" style=\"border-spacing:0;border-collapse:collapse;background-color:#f3f3f3;font-family:Arial\">\r\n        <tbody><tr>\r\n            <td>\r\n                <table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"600\" align=\"center\" style=\"border-spacing:0;border-collapse:collapse;font-family:Arial,HelveticaNeue;color:#646868;font-size:15px\">\r\n                    <tbody><tr>\r\n                        <td width=\"600\" align=\"center\">\r\n                            <span style=\"color:#bbbfbf;font-size:12px\"> Bu e-postayı tarayıcı da görüntülemek için <a style=\"color:#bbbfbf;font-size:12px;text-decoration:none\">burayı tıklayın</a></span>\r\n                        </td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td width=\"600\" align=\"center\" style=\"padding-top:40px;padding-bottom:45px\">\r\n                            <img style=\"width:161px\" src=\"https://ci3.googleusercontent.com/meips/ADKq_NYpk1GHe9C3mFJI8RxJvqahnIFDHgszaD2V3IsLIOymaCL4NY3xI_irAclyzGt2SIuXuIf8PtnW_a7eXbxuaXuNGzQMUfrOcQE8k5U86INL4hrb=s0-d-e1-ft#http://Basvuru.e-guven.com//Content/Images/Banners/Banner.png\" class=\"CToWUd\" data-bit=\"iit\">\r\n                        </td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td width=\"600\" style=\"background-color:#fff\">\r\n                            <table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"600\" align=\"center\" style=\"border-spacing:0;border-collapse:collapse;font-family:Arial,HelveticaNeue;background-color:#fff;color:#646868;font-size:15px\">\r\n                                <tbody><tr>\r\n                                    <td width=\"600\" align=\"center\">\r\n                                        <a href=\"https://panel.paperzero.com/account/login#register\" target=\"_blank\" data-saferedirecturl=\"https://www.google.com/url?q=https://panel.paperzero.com/account/login%23register&amp;source=gmail&amp;ust=1735716986106000&amp;usg=AOvVaw0i7tBv2lWJsNrCn87hRSys\">\r\n                                            <img src=\"https://ci3.googleusercontent.com/meips/ADKq_NYMPkbRorewr4dmtyYWMBpCRrvG6gp-qkCZ7Yiubp7T1Mw1FYnqAo_fr5UhzAoleg5F1pAJ05qCLY1gtKo_L7XWaoacO_CXHYjdR_Pdqi7r_anVzA=s0-d-e1-ft#http://Basvuru.e-guven.com//Content/Images/Banners/banner2.png\" class=\"CToWUd\" data-bit=\"iit\">\r\n                                        </a>                               \r\n                                    </td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td width=\"600\" align=\"center\" style=\"padding-top:35px;padding-bottom:35px;border-bottom:1px solid #edf1f1\">\r\n                                        <span style=\"color:#d1111c;font-size:24px\"><b>Siparişiniz alındı!</b></span>\r\n                                    </td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td width=\"600\" align=\"center\" style=\"padding-top:25px;padding-bottom:35px;border-bottom:1px solid #edf1f1;text-align:center;font-family:Arial\">\r\n                                        <span style=\"color:#3e4242;font-size:17px\"> Merhaba <b>" + apiBasvuruRequest.AdSoyad + ", </b></span>\r\n                                        <br><br>\r\n                                        <span style=\"color:#3e4242;font-size:17px\">Siparişiniz için teşekkür ederiz.</span> <br><br>\r\n                                        <span style=\"color:#3e4242;font-size:17px\">Sipariş detaylarınızı aşağıda bulabilirsiniz</span>\r\n                                        <br><br>\r\n                                        <table style=\"text-align:left\">\r\n                                            <tbody><tr>\r\n                                                <td style=\"padding-top:5px;padding-left:15px\"><b style=\"font-weight:bold;color:#3e4242;display:block;float:left;width:140px\">Sipariş Numarası</b><u></u>:<u></u><span>" + apiBasvuruRequest.SiparisKodu + "</span></td>\r\n                                            </tr>\r\n                                            <tr>\r\n                                                <td style=\"padding-top:5px;padding-left:15px\"><b style=\"font-weight:bold;color:#3e4242;display:block;float:left;width:140px\">Sipariş Tarihi</b><u></u>:<u></u><span>" + apiBasvuruRequest.CreatedDate + "</span></td>\r\n                                            </tr>\r\n                                            <tr>\r\n                                                <td style=\"padding-top:5px;padding-left:15px\">\r\n                                                    <b style=\"font-weight:bold;color:#3e4242;display:block;float:left;width:140px\">Ödeme Şekli</b><u></u>:<u></u>\r\n\r\n                                                            <span>" + odemeSekli + "</span>\r\n                                                </td>\r\n                                            </tr>\r\n                                            <tr>\r\n                                                <td style=\"padding-top:5px;padding-left:15px\"> <b style=\"font-weight:bold;color:#3e4242;display:block;float:left;width:140px\">Fatura Adresi</b><u></u>:<u></u><span>" + FaturaAdresi + "</span></td>\r\n                                            </tr>\r\n                                            <tr>\r\n                                                <td style=\"padding-top:5px;padding-left:15px\"><b style=\"font-weight:bold;color:#3e4242;display:block;float:left;width:140px\">Teslimat Adresi</b><u></u>:<u></u><span>" + apiBasvuruRequest.TeslimatAdresi + "</span></td>\r\n                                            </tr>\r\n                                            <tr>\r\n                                                <td style=\"padding-top:5px;padding-left:15px\"><b style=\"font-weight:bold;color:#3e4242;display:block;float:left;width:140px\">Sipariş Durumu</b><u></u>:<u></u> <span>Kimlik Doğrulamanız Beklenmektedir.</span></td>\r\n                                            </tr>\r\n                                            <tr>\r\n                                                <td style=\"padding-top:5px;padding-left:15px\"><b style=\"font-weight:bold;color:#3e4242;display:block;float:left;width:140px\">Sipariş İçeriği</b><u></u>:<u></u></td>\r\n                                            </tr>\r\n                                            <tr>\r\n                                                <td width=\"500\">\r\n                                                    <table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"500\" align=\"center\" style=\"border-spacing:0;border-collapse:collapse;font-size:12px;background-color:#fff;font-family:Arial,HelveticaNeue;padding-top:10px\">\r\n                                                        <tbody><tr>\r\n                                                            <td width=\"460\" height=\"105\">\r\n                                                                <table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"460\" height=\"105\" align=\"center\" style=\"border-spacing:0;border-collapse:collapse;font-size:12px;background-color:#fff;font-family:Arial,HelveticaNeue\">\r\n                                                                        <tbody><tr>\r\n                                                                            <td width=\"300\" style=\"text-align:right\">\r\n                                                                                <span style=\"color:#3e4242;font-weight:bold\">" + projectProduct.Product.ProductLanguageInfos[0].Title + " ( E-Devlet Kimlik Doğrulama Seçenekli Pakettir. )</span>\r\n\r\n                                                                            </td>\r\n                                                                            <td width=\"100\" style=\"text-align:right\">\r\n                                                                                <span>" + apiBasvuruRequest.OdemeTutar + " TL</span>\r\n\r\n                                                                            </td>\r\n                                                                        </tr>\r\n                                                                        <tr>\r\n                                                                            <td colspan=\"3\"> <br></td>\r\n                                                                        </tr>\r\n                                                                    <tr>\r\n                                                                        <td width=\"340px\" style=\"padding-top:13px;padding-bottom:25px;text-align:right\">\r\n\r\n                                                                            <span style=\"color:#3e4242;font-weight:bold\">Toplam Tutar</span>\r\n                                                                        </td>\r\n                                                                        <td width=\"120px\" style=\"padding-top:13px;padding-bottom:25px;text-align:right\">\r\n                                                                            <span> " + apiBasvuruRequest.OdemeTutar + " TL</span>\r\n                                                                        </td>\r\n                                                                    </tr>\r\n                                                                </tbody></table>\r\n                                                            </td>\r\n                                                        </tr>\r\n                                                    </tbody></table>\r\n                                                </td>\r\n                                            </tr>\r\n                                        </tbody></table>\r\n                                    </td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td width=\"100%\" style=\"padding-top:25px\">\r\n\r\n                                        <p style=\"color:#181c1c;line-height:20px;font-size:8.5pt;font-family:Arial\">\r\n\r\n                                            <span style=\"font-size:8.5pt\">\r\n\r\n                                                </span></p><p style=\"text-align:center;color:#3e4242;font-size:16px\">Bilgi ve destek talepleriniz için bize 0850 3218555 nolu hattımızdan ulaşabilirsiniz.</p>\r\n\r\n                                                <p style=\"text-align:center;color:#3e4242;font-size:16px\">Saygılarımızla,</p>\r\n\r\n                                                <p style=\"text-align:center;color:#3e4242;font-size:16px\"><strong>E-GÜVEN</strong></p>\r\n                                            \r\n                                        <p></p>\r\n                                    </td>\r\n                                </tr>\r\n                            </tbody></table>\r\n                            <table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"540\" align=\"center\" style=\"border-spacing:0;border-collapse:collapse;background-color:#f5f7f7;font-family:Arial,HelveticaNeue\">\r\n                                <tbody><tr>\r\n                                    <td>\r\n                                        <table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"650\" align=\"center\" style=\"border-spacing:0;border-collapse:collapse;font-size:12px;background-color:#fff;font-family:Arial,HelveticaNeue\">\r\n                                            <tbody><tr>\r\n                                                <td width=\"540\" style=\"padding-bottom:20px;padding-left:55px\">\r\n                                                    <table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"540\" style=\"border-spacing:0;border-collapse:collapse;font-size:12px;background-color:#fff;text-align:center;font-family:Arial,HelveticaNeue\">\r\n                                                        <tbody><tr align=\"center\">\r\n                                                            <td style=\"padding-top:35px\">\r\n                                                                <a href=\"http://Basvuru.e-guven.com/gw/salesnotice?oid=" + apiBasvuruRequest.SiparisKodu + "&amp;t=bZsNXc6aPragPt4RJAq2vBEjDpJXSoIvUF19owQaw\" style=\"color:#3e4242;font-size:14px;text-decoration:none;font-family:Arial\" target=\"_blank\" data-saferedirecturl=\"https://www.google.com/url?q=http://Basvuru.e-guven.com/gw/salesnotice?oid%" + apiBasvuruRequest.SiparisKodu + "%26t%3DbZsNXc6aPragPt4RJAq2vBEjDpJXSoIvUF19owQaw&amp;source=gmail&amp;ust=1735716986106000&amp;usg=AOvVaw3ooDchXSxsE7DRsaLXyfjW\"><b>Mesafeli Satış Sözleşmesi</b></a>\r\n                                                            </td>\r\n                                                            <td style=\"padding-top:35px\">\r\n                                                                <a href=\"http://Basvuru.e-guven.com/gw/salesagreement?oid=" + apiBasvuruRequest.SiparisKodu + "&amp;t=bZsNXc6aPragPt4RJAq2vBEjDpJXSoIvUF19owQaw\" style=\"color:#3e4242;font-size:14px;text-decoration:none;font-family:Arial\" target=\"_blank\" data-saferedirecturl=\"https://www.google.com/url?q=http://Basvuru.e-guven.com/gw/salesagreement?oid%3D" + apiBasvuruRequest.SiparisKodu + "%26t%3DbZsNXc6aPragPt4RJAq2vBEjDpJXSoIvUF19owQaw&amp;source=gmail&amp;ust=1735716986106000&amp;usg=AOvVaw3W_hw5itQrFPPvU07u5kzs\"><b>Sipariş Ön Bilgilendime Formu</b></a>\r\n                                                            </td>\r\n                                                        </tr>\r\n                                                    </tbody></table>\r\n                                                </td>\r\n                                            </tr>\r\n                                        </tbody></table>\r\n                                    </td>\r\n                                </tr>\r\n                            </tbody></table>\r\n                        </td>\r\n                    </tr>\r\n                </tbody></table>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td width=\"600\" align=\"center\" style=\"padding-top:40px;padding-bottom:45px;color:#969a9a\">\r\n                <span style=\"font-size:12px;line-height:18px\">© Copyright 2018 E-GÜVEN. Tüm Hakları Saklıdır.</span>\r\n            </td>\r\n        </tr>\r\n    </tbody></table><div class=\"yj6qo\"></div><div class=\"adL\">\r\n</div></div>";

                await functions.SendMail(uiLayoutViewModel.Config, mail);

                ////


                mail.Subject = "Kimlik Doğrulamanızı Gerçekleştirmeniz Beklenmektedir.";
                mail.Email = apiBasvuruRequest.Eposta;

                MailTemplateLanguageInfo mailTemplateLanguageInfo = await _mailTemplateLanguageInfoService
                .Where(x => x.Status && x.MailTemplate.Code == "c7da2ce07eb44a88a7176b2121e13726" && x.Language.Code == CultureInfo.CurrentCulture.Name && x.Status && x.MailTemplate.Status)
                .FirstOrDefaultAsync();

                mail.Message = "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"600\" align=\"center\" style=\"border-spacing:0;border-collapse:collapse;font-family:Arial,HelveticaNeue;color:#646868;font-size:15px\">\r\n                    <tbody><tr>\r\n                        <td width=\"600\" align=\"center\">\r\n                            <span style=\"color:#bbbfbf;font-size:12px\"> Bu e-postayı tarayıcı da görüntülemek için <a style=\"color:#bbbfbf;font-size:12px;text-decoration:none\">burayı tıklayın</a></span>\r\n                        </td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td width=\"600\" align=\"center\" style=\"padding-top:40px;padding-bottom:45px\">\r\n                            <img style=\"width:161px\" src=\"https://ci3.googleusercontent.com/meips/ADKq_NYpk1GHe9C3mFJI8RxJvqahnIFDHgszaD2V3IsLIOymaCL4NY3xI_irAclyzGt2SIuXuIf8PtnW_a7eXbxuaXuNGzQMUfrOcQE8k5U86INL4hrb=s0-d-e1-ft#http://Basvuru.e-guven.com//Content/Images/Banners/Banner.png\" class=\"CToWUd\" data-bit=\"iit\">\r\n\r\n                        </td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td width=\"600\" style=\"background-color:#fff\">\r\n                            <table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"600\" align=\"center\" style=\"border-spacing:0;border-collapse:collapse;font-family:Arial,HelveticaNeue;background-color:#fff;color:#646868;font-size:15px\">\r\n                                <tbody><tr>\r\n                                    <td width=\"600\" align=\"center\" style=\"padding-top:35px;padding-bottom:35px;border-bottom:1px solid #edf1f1\">\r\n                                        <span style=\"color:#d1111c;font-size:24px\"><b>Kimlik Doğrulamanızı Gerçekleştirmeniz Beklenmektedir.</b></span>\r\n                                    </td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td width=\"600\" align=\"center\" style=\"padding-top:25px;padding-bottom:35px;border-bottom:1px solid #edf1f1;text-align:center;font-family:Arial\">\r\n                                        <span style=\"color:#3e4242;font-size:20px\"> Merhaba <b>" + apiBasvuruRequest.AdSoyad + ", </b></span>\r\n                                        <br><br>\r\n\r\n                                        <table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"540\" align=\"center\" style=\"border-spacing:0;border-collapse:collapse;font-family:Arial,HelveticaNeue\">\r\n\r\n                                            <tbody><tr>\r\n                                                <td width=\"460\" style=\"border-top:10px solid #fff\">\r\n                                                    <table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"460\" align=\"center\" style=\"border-spacing:0;border-collapse:collapse;font-size:12px;font-family:Arial,HelveticaNeue\">\r\n                                                        <tbody><tr>\r\n                                                            <td width=\"460\" style=\"padding-bottom:20px\">\r\n                                                                <table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"460\" style=\"border-spacing:0;border-collapse:collapse;font-size:14px;text-align:left;font-family:Arial,HelveticaNeue\">\r\n\r\n\r\n                                                                                                                                            <tbody><tr>\r\n                                                                            <td style=\"padding-top:7px\">" + mailTemplateLanguageInfo.Content + "</td>\r\n                                                                        </tr>\r\n                                                                </tbody></table>\r\n                                                            </td>\r\n                                                        </tr>\r\n                                                    </tbody></table>\r\n                                                </td>\r\n                                            </tr>\r\n\r\n                                        </tbody></table>\r\n                                    </td>\r\n                                </tr>\r\n                            </tbody></table>\r\n                        </td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td width=\"600\" align=\"center\" style=\"padding-top:40px;padding-bottom:45px;color:#969a9a\">\r\n                            <span style=\"font-size:12px;line-height:18px\">© Copyright 2018 E-GÜVEN. Tüm Hakları Saklıdır.</span>\r\n                        </td>\r\n                    </tr>\r\n                </tbody></table>";
            }


            //await _apiBasvuruRequestService.RemoveAsync(apiBasvuruRequest);//en son sistemdem silinecek

            ThanksViewModel thanksViewModel = new ThanksViewModel
            {
                Config = uiLayoutViewModel.Config,
                SiteMenus = uiLayoutViewModel.SiteMenus,
                FooterMenus = uiLayoutViewModel.FooterMenus,
                Languages = uiLayoutViewModel.Languages,
                QuickMenus = uiLayoutViewModel.QuickMenus,
                ApiBasvuruRequest = apiBasvuruRequest,
                HavaleEft = await _pageLanguageInfoService.Where(x => x.Status && x.Page.Code == "303ac68194e84761b3b4ed91958a2451" && x.Language.Code == CultureInfo.CurrentCulture.Name && x.Status && x.Page.Status).FirstOrDefaultAsync(),
            };
            return View(thanksViewModel);
        }
    }
}

﻿using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SysBase.Core.Models;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace SysBase.Service.Functions
{
    public class Functions
    {
        ResultJson resultJson = new ResultJson();
        public Functions()
        {
        }

        public async Task<ResultJson> SendMail(Config config, Mail mail)
        {
            SmtpClient smtpClient = new SmtpClient(config.MailHost)
            {
                Port = config.MailPort, // Yandex Mail için SMTP portu
                Credentials = new NetworkCredential(config.Mail, config.MailPassword), // Gönderen e-posta ve şifre
                EnableSsl = true // SSL kullanarak güvenli bağlantı
            };
            MailMessage mailMessage = new MailMessage(config.Mail, mail.Email, mail.Subject, mail.Message);
            mailMessage.IsBodyHtml = true;
            try
            {
                smtpClient.Send(mailMessage);
                resultJson.status = "success";
                resultJson.message = "Form Bilgileri Alınmıştır. İlginiz İçin Teşekkürler.";
            }
            catch (Exception ex)
            {
                resultJson.status = "error";
                resultJson.message = ex.Message;
            }
            finally
            {
                smtpClient.Dispose();
            }

            return resultJson;
        }

        public async Task<string> CloudflareTurnstile(string token)
        {
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent($"secret=1x0000000000000000000000000000000AA&response={token}", Encoding.UTF8, "application/x-www-form-urlencoded");
                var response = await httpClient.PostAsync("https://challenges.cloudflare.com/turnstile/v0/siteverify", content);
                if (!response.IsSuccessStatusCode)
                {
                    return "Cloudflare Not Response";
                }
                string jsonResponse = await response.Content.ReadAsStringAsync();
                JObject responseObj = JObject.Parse(jsonResponse);
                if (responseObj["success"] != null && responseObj["success"].Value<bool>() == true)
                {
                    return "1";
                }
                else
                {
                    if (responseObj["error-codes"] != null && responseObj["error-codes"].HasValues)
                    {
                        return responseObj["error-codes"].First.ToString(); // İlk hata kodunu döndür
                    }
                    else
                    {
                        return "Bilinmeyen bir hata oluştu."; // Hata kodu yoksa
                    }
                }
            }
        }

        public async Task<string> ImageUpload(IFormFile Image, string path, string title)
        {
            if (Image != null)
            {
                string[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                string extent = Path.GetExtension(Image.FileName).ToLower();
                if (allowedExtensions.Contains(extent))
                {
                    string fileName = this.ToSlug(title) + "" + extent;
                    // Dosya adını ve yolunu belirleme
                    var filePath = Path.Combine("wwwroot/" + path + "/", fileName);
                    // Dosyayı sunucuya kaydetme
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await Image.CopyToAsync(stream);
                    }
                    return fileName;
                }
            }
            return null;
        }

        public async Task<string> FileUpload(IFormFile File, string path, string title, string[] allowedExtensions)
        {
            if (File != null)
            {
                string extent = Path.GetExtension(File.FileName).ToLower();
                if (allowedExtensions.Contains(extent))
                {
                    string fileName = this.ToSlug(title) + "" + extent;
                    // Dosya adını ve yolunu belirleme
                    var filePath = Path.Combine("wwwroot/" + path + "/", fileName);
                    // Dosyayı sunucuya kaydetme
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await File.CopyToAsync(stream);
                    }
                    return fileName;
                }
            }
            return null;
        }

        public string ToSlug(string value, short limit = 100)
        {
            // Is the source null?
            if (null == value)
            {
                return "";
            }
            //First to lower case
            value = value.ToLowerInvariant();
            //Remove all accents
            var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(value);
            value = Encoding.ASCII.GetString(bytes);
            //Replace spaces
            value = Regex.Replace(value, @"\s", "-", RegexOptions.Compiled);
            value = Regex.Replace(value, @"I", "i", RegexOptions.Compiled);
            //Remove invalid chars
            value = Regex.Replace(value, @"[^a-z0-9\s-_]", "", RegexOptions.Compiled);
            //Trim dashes from end
            value = value.Trim('-', '_');
            //Replace double occurences of - or _
            value = Regex.Replace(value, @"([-_]){2,}", "$1", RegexOptions.Compiled);
            // Check the limit and truncate the string
            if (limit > 0 && value.Length > limit)
            {
                value = value.Substring(0, limit).Trim('-');
            }
            return value;
        }

        public int Rand(int basamak)
        {
            Random random = new Random();
            return random.Next((int)Math.Pow(10, basamak), (int)Math.Pow(10, basamak + 1) - 1);
        }

        public string ClearText(string metin)
        {
            if (metin == null)
            {
                return metin;
            }
            return metin.Replace("<li><p>", "<li>").Replace("</p></li>", "</li>").Replace("<li>\n<p>", "<li>").Replace("</p>\n</li>", "</li>").Replace("<li> \n<p>", "<li>").Replace("</p> \n</li>", "</li>").Replace("<li>\r\n\t<p>", "<li>").Replace("</p>\r\n\t</li>", "</li>");
        }

        public MenuPermission MenuPermSelect(string menuPermissionsStr, string controllerName)
        {
            List<MenuPermission> menuPermissions = JsonConvert.DeserializeObject<List<MenuPermission>>(menuPermissionsStr);
            foreach (MenuPermission menuPermission in menuPermissions)
            {
                if (menuPermission.ControllerName == controllerName)
                {
                    return menuPermission;
                }
            }
            return null;
        }

        public bool MenuPermControl(MenuPermission menuPermission, string menuType)
        {
            if (menuPermission == null)
            {
                return false;
            }
            if (menuType == "List")
            {
                return menuPermission.List;
            }
            if (menuType == "Add")
            {
                return menuPermission.Add;
            }
            if (menuType == "Edit")
            {
                return menuPermission.Edit;
            }
            if (menuType == "Delete")
            {
                return menuPermission.Delete;
            }
            if (menuType == "Export")
            {
                return menuPermission.Export;
            }
            return false;
        }

        public string LogCriticalMessage(string typeName, string tableName, string primaryId = "null", string content = "{}")
        {
            List<LogMessageDetail> logMessageDetails = new List<LogMessageDetail>
            {
                new LogMessageDetail
                {
                    TypeName = typeName,
                    TableName = tableName,
                    PrimaryId = primaryId,
                    Content = content
                }
            };

            string logMessageDetailsJSON = JsonConvert.SerializeObject(logMessageDetails);
            return logMessageDetailsJSON;
        }

        //otomatik excel indirme
        public byte[] AutomaticExportToExcel<T>(List<T> dataList, string tableName)
        {
            // Başlıkları toplama
            var headlines = new List<string>();
            if (dataList.Count > 0)
            {
                var firstRow = dataList[0];
                foreach (var property in firstRow.GetType().GetProperties())
                {
                    headlines.Add(property.Name); // Başlıkları topluyoruz
                }
            }

            // Veriyi hazırlama
            var exportData = new List<List<object>>
            {
                // İlk satıra başlıkları ekleyin
                headlines.Cast<object>().ToList()
            };

            // Diğer satırlara verileri ekleyin
            foreach (var row in dataList)
            {
                var rowData = new List<object>();
                foreach (var headline in headlines)
                {
                    var value = row.GetType().GetProperty(headline)?.GetValue(row, null);
                    rowData.Add(value);
                }
                exportData.Add(rowData);
            }

            // Excel oluşturma
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add(tableName);

            // Veriyi Excel'e yazma
            for (int i = 0; i < exportData.Count; i++)
            {
                for (int j = 0; j < exportData[i].Count; j++)
                {
                    // Değer null ise hücreye boş değer yaz
                    var cellValue = exportData[i][j] ?? "";

                    // Eğer cellValue türü uygun değilse, string'e çevirerek yaz
                    worksheet.Cell(i + 1, j + 1).Value = cellValue.ToString();
                }
            }

            // Dosyayı belleğe kaydetme ve indirme
            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                return stream.ToArray(); // Dosya içeriğini byte array olarak döndür
            }
        }


        public string ConvertToEmbedUrl(string youtubeUrl)
        {
            if (string.IsNullOrEmpty(youtubeUrl))
            {
                return string.Empty;
            }

            // YouTube URL'sinden video ID'sini çıkar
            var videoId = string.Empty;
            var uri = new Uri(youtubeUrl);
            var query = System.Web.HttpUtility.ParseQueryString(uri.Query);

            if (query.AllKeys.Contains("v"))
            {
                videoId = query["v"];
            }
            else
            {
                // Short URL için video ID'si yolu
                videoId = uri.Segments.LastOrDefault()?.Trim('/');
            }

            if (string.IsNullOrEmpty(videoId))
            {
                return string.Empty; // Geçerli bir video ID'si yoksa boş döner
            }

            // Embed URL formatına dönüştür
            return $"https://www.youtube.com/embed/{videoId}";
        }

    }
}

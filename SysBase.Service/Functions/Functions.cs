using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SysBase.Core.Models;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SysBase.Service.Functions
{
    public class Functions
    {
        public Functions()
        {
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
    }
}

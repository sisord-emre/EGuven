using Microsoft.AspNetCore.Mvc;

namespace SysBase.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FileUploadController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public FileUploadController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile upload, string CKEditorFuncNum)
        {
            if (upload != null && upload.Length > 0)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName);
                var filePath = Path.Combine(_environment.WebRootPath, "uploads", fileName);

                if (!Directory.Exists(Path.Combine(_environment.WebRootPath, "uploads")))
                {
                    Directory.CreateDirectory(Path.Combine(_environment.WebRootPath, "uploads"));
                }

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await upload.CopyToAsync(fileStream);
                }

                // Yükleme sonrası CKEditor'a dönecek yanıt
                var fileUrl = $"/uploads/{fileName}";
                var callbackScript = $"<script>window.parent.CKEDITOR.tools.callFunction({CKEditorFuncNum}, '{fileUrl}', 'Upload successful');</script>";
                return Content(callbackScript, "text/html");
            }

            // Hata durumunda CKEditor'a dönecek yanıt
            var errorScript = $"<script>window.parent.CKEDITOR.tools.callFunction({CKEditorFuncNum}, '', 'Upload failed');</script>";
            return Content(errorScript, "text/html");
        }

    }
}

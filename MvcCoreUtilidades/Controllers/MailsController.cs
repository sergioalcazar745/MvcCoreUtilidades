using Microsoft.AspNetCore.Mvc;
using MvcCoreUtilidades.Helpers;
using System.Net;
using System.Net.Mail;

namespace MvcCoreUtilidades.Controllers
{
    public class MailsController : Controller
    {
        private HelperUploadFile helperUploadFiles;
        private HelperMail helperMail;
        public MailsController(HelperUploadFile helperUploadFiles, HelperMail helperMail)
        {
            this.helperUploadFiles = helperUploadFiles;
            this.helperMail = helperMail;
        }

        public IActionResult SendMails()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMails(string para, string asunto, string mensaje, List<IFormFile> files)
        {
            if(files is not null)
            {
                if(files.Count > 1)
                {
                    List<string> paths = await this.helperUploadFiles.UploadFilesAsync(files, Folder.Temporal);
                    await this.helperMail.SendMailAsync(para, asunto, mensaje, paths);
                }
                else
                {
                    string path = await this.helperUploadFiles.UploadFileAsync(files[0], Folder.Temporal);
                    await this.helperMail.SendMailAsync(para, asunto, mensaje, path);
                }
            }
            else
            {
                await this.helperMail.SendMailAsync(para, asunto, mensaje);
            }
            ViewData["MENSAJE"] = "Email enviado correctamente"; 
            return View();
        }

    }
}

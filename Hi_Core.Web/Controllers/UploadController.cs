using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hi_Core.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Upload")]
    public class UploadController : BaseController
    {
        private IHostingEnvironment hostingEnv;
        public UploadController(IHostingEnvironment env)
        {
            this.hostingEnv = env;
        }

        string tempPath = $@"\UploadFile\temp\";
        /// <summary>
        /// 文件上传，支持多文件上传
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Files()
        {
            var files = Request.Form.Files;
            long size = files.Sum(f => f.Length);

            //size > 100MB refuse upload !
            if (size > 104857600)
            {
                return Error("文件总大小不能超过100MB");
            }

            List<string> filePathResultList = new List<string>();

            foreach (var file in files)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                string filePath = hostingEnv.WebRootPath + tempPath;

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                fileName = Guid.NewGuid() + "." + fileName.Split('.')[1];

                string fileFullName = filePath + fileName;

                using (FileStream fs = System.IO.File.Create(fileFullName))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
                filePathResultList.Add(fileFullName);
            }

            return Json(filePathResultList);
        }

        [HttpPost]
        public IActionResult Pic()
        {
            string[] pictureFormatArray = { "png", "jpg", "jpeg", "bmp", "gif", "ico", "PNG", "JPG", "JPEG", "BMP", "GIF", "ICO" };

            var files = Request.Form.Files;
            long size = files.Sum(f => f.Length);

            if (size > 104857600)
            {
                return Error("文件总大小不能超过100MB");
            }

            List<string> filePathResultList = new List<string>();

            foreach (var file in files)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                string filePath = hostingEnv.WebRootPath + tempPath;

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                string suffix = fileName.Split('.')[1];

                if (!pictureFormatArray.Contains(suffix))
                {
                    return Error("不支持的图片格式，请上传'png','jpg','jpeg','bmp','gif','ico'格式的图片。");
                }

                fileName = Guid.NewGuid() + "." + suffix;

                string fileFullName = filePath + fileName;

                using (FileStream fs = System.IO.File.Create(fileFullName))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
                filePathResultList.Add(fileFullName);
            }
            return Json(filePathResultList);
        }
    }
}
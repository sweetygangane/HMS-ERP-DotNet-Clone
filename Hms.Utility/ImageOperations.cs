using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Hms.Utility
{
    public class ImageOperations
    {
        private readonly IWebHostEnvironment _env;

        public ImageOperations(IWebHostEnvironment env)
        {
            _env = env;
        }

        public string ImageUpload(IFormFile file)
        {
            string filename = null;

            if (file != null)
            {
                string fileDirectory =
                    Path.Combine(_env.WebRootPath, "Images");

                if (!Directory.Exists(fileDirectory))
                {
                    Directory.CreateDirectory(fileDirectory);
                }

                filename =
                    Guid.NewGuid() + "-" + file.FileName;

                string filepath =
                    Path.Combine(fileDirectory, filename);

                using (FileStream fs =
                    new FileStream(filepath, FileMode.Create))
                {
                    file.CopyTo(fs);
                }
            }

            return filename;
        }
    }
}
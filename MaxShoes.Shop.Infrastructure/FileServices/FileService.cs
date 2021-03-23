using MaxShoes.Shop.Application.Contracts.Infrastructure;
using MaxShoes.Shop.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MaxShoes.Shop.Infrastructure.FileServices
{
    class FileService : IFileService
    {
        private readonly ILogger<FileService> logger;

        public FileService(ILogger<FileService> logger)
        {
            this.logger = logger;
        }
        public bool CheckIfSuportedFile(IFormFile file)
        {
                var extension = "." + file.FileName.Split('.')[^1];
                return (extension == ".pdf" || extension == ".jpg");
        }

        public async Task<MemoryStream> DownloadFile(string file)
        {
            var uploads = Path.Combine(Directory.GetCurrentDirectory(), "Resources");
            var filePath = Path.Combine(uploads, file);

            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return memory;
        }

        public async Task<bool> WriteFile(IFormFile file)
        {
            bool isSaveSuccess = false;
            string fileName;
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                fileName = DateTime.Now.Ticks + extension;

                var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "Resources");

                if (!Directory.Exists(pathBuilt))
                {
                    Directory.CreateDirectory(pathBuilt);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "Resources",
                   fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                isSaveSuccess = true;
                logger.LogInformation($"File {fileName} saved.");
            }
            catch (Exception e)
            {
                logger.LogWarning(e,"Saving file failed.");
            }

            return isSaveSuccess;
        }
    }

    
}

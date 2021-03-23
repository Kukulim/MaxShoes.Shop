using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MaxShoes.Shop.Application.Contracts.Infrastructure
{
    public interface IFileService
    {
        Task<MemoryStream> DownloadFile(string file);
        Task<bool> WriteFile(IFormFile file);

        bool CheckIfSuportedFile(IFormFile file);

    }
}

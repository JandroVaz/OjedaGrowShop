using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OjedaGrowShop.EF.DTOS;
using OjedaGrowShop.EF.Services.Interfaces;
using System.Threading;

namespace OjedaGrowShop.Controllers
{
    public class DownloadController : Controller
    {
        IExportPDFService exportPDFService;
        public DownloadController(IExportPDFService _exportPDFService)
        {
            exportPDFService = _exportPDFService;
        }
        [HttpGet("~/invoice/{path}")]
        public IActionResult Invoice(string path, CancellationToken cancel)
        {

            PhotoStreamWrapper photoStreamWrapper = exportPDFService.GetPDFStream(path);
            photoStreamWrapper.Stream.Position = 0;

            Response.Clear();
            Response.Headers.Add("Content-Type", $"image/{photoStreamWrapper.Type}");
            Response.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");
            Response.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue($"application/{photoStreamWrapper.Type}").MediaType;
            Response.Headers.Add("Content-Disposition", $"attachment; filename={photoStreamWrapper.Name}.{photoStreamWrapper.Type}");
            return File(photoStreamWrapper.Stream, $"application/{photoStreamWrapper.Type}", $"{photoStreamWrapper.Name}.{photoStreamWrapper.Type}");


        }



    }
}

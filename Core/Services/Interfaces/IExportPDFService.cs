using OjedaGrowShop.EF.DTOS;
using System.Collections.Generic;

namespace OjedaGrowShop.EF.Services.Interfaces
{
    public partial interface IExportPDFService
    {
        string ExportPDF(string fileName, IList<ProductoCarritoDTO> listProd, double total, string usuario);
        PhotoStreamWrapper GetPDFStream(string path);

        int DeletePDF(string name);
    }
}

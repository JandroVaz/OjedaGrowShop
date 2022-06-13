using iTextSharp.text;
using iTextSharp.text.pdf;
using OjedaGrowShop.EF.DTOS;
using OjedaGrowShop.EF.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OjedaGrowShop.EF.Services
{
    public partial class ExportPDFService : IExportPDFService
    {
        public string ExportPDF(string fileName, IList<ProductoCarritoDTO> listProd, double totalCompra, string usuario)
        {

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Document doc = new Document();
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\temp\\{fileName.Trim().ToLower()}");
            var fs = new FileStream(path, FileMode.OpenOrCreate);
            if (doc == null)
            {
                doc = new Document();
            }
            PdfWriter_GetInstance(doc, fs);
            //PdfWriter.GetInstance(doc, fs);
            // Importante Abrir el documento
            doc.Open();
            // Creamos un titulo personalizado con tamaño de fuente 18 y color Azul
            Paragraph title = new Paragraph
            {
                Font = FontFactory.GetFont(FontFactory.HELVETICA, 20f)
            };

            Image image1 = Image.GetInstance("wwwroot/images/logoogs.png");
            //image1.ScalePercent(50f);
            image1.ScaleAbsoluteWidth(200);
            image1.ScaleAbsoluteHeight(180);
            doc.Add(image1);

            Paragraph text = new Paragraph
            {
                Font = FontFactory.GetFont(FontFactory.HELVETICA, 12f)
            };
            text.Add("Factura del cliente aportada por la empresa OjedaGrowShop.");
            text.Add(new Paragraph(" "));
            text.Add("Para cualquier duda o problema consulte con: +34 677161127");
            doc.Add(text);
            doc.Add(new Paragraph(" "));
            title.Add($"Factura de la compra realizada por: {usuario}");
            doc.Add(title);
            // Agregamos un parrafo vacio como separacion.
            doc.Add(new Paragraph(" "));
            // Empezamos a crear la tabla, definimos una tabla de 6 columnas
            PdfPTable table = new PdfPTable(5);
            // Esta es la primera fila
            table.AddCell("Nombre");
            table.AddCell("Categoría");
            table.AddCell("Precio");
            table.AddCell("Cantidad");
            table.AddCell("Precio Total");


            foreach (ProductoCarritoDTO prod in listProd)
            {
                table.AddCell(prod.Nombre);
                table.AddCell(prod.Categoria);
                table.AddCell($"{Math.Round(prod.Precio, 2)} €");
                table.AddCell(prod.Cantidad.ToString());
                table.AddCell($"{Math.Round(prod.PrecioTotal, 2)} €");
            }
            // Agregamos la tabla al documento
            doc.Add(table);
            doc.Add(new Paragraph(" "));
            PdfPTable table2 = new PdfPTable(2);

            Paragraph totalBuy = new Paragraph
            {
                Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18f)
            };
            totalBuy.Add($"TOTAL: {Math.Round(totalCompra, 2)} €");
            doc.Add(totalBuy);
            // Ceramos el documento
            doc.Close();
            return fileName;




        }
        public PhotoStreamWrapper GetPDFStream(string path)
        {
            string fileName = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/temp/{path}.pdf");
            if (!File.Exists(fileName))
            {
                return null;
            }
            return new PhotoStreamWrapper()
            {
                Stream = File.OpenRead(fileName),
                Name = fileName.Split('.')[0],
                Type = fileName.Split('.')[1]
            };
        }
        public int DeletePDF(string name)
        {
            string fileName = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/temp/{name}.pdf");
            try
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public PdfWriter PdfWriter_GetInstance(Document document, FileStream filestrm)
        {
            PdfWriter pdfwr = null;

            for (int repeat = 0; repeat < 6; repeat++)
            {
                try
                {
                    pdfwr = PdfWriter.GetInstance(document, filestrm);
                    break; //created, then exit loop
                }
                catch // instantiation of PdfWriter failed, then pause
                {
                    System.Threading.Thread.Sleep(300);
                }
            }
            if (pdfwr == null)
            {
                throw new Exception("iTextSharp PdfWriter was not instantiated");
            }

            return pdfwr;
        }




    }
}

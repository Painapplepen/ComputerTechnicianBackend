using ComputerTechnicianBackend.Data.Domain.Models;
using ComputerTechnicianBackend.Data.EF.SQL;
using ComputerTechnicianBackend.Data.Services.Abstraction;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
namespace ComputerTechnicianBackend.Data.Services
{
    public interface IMailService : IBaseService<Supplier>
    {
        bool GeneratePdf(List<Supplier> supplier);
        bool GenerateEmail();
    }
    public class MailService : BaseService<Supplier>, IMailService
    {
        private readonly ComputerTechnicianDbContext dbContext;

        public MailService(ComputerTechnicianDbContext dbContext) : base(dbContext)
        { 
            this.dbContext = dbContext;
        }

        public bool GeneratePdf(List<Supplier> supplier)
        {
            iTextSharp.text.Document doc = new iTextSharp.text.Document();
            PdfWriter.GetInstance(doc, new FileStream("DataSupplier.pdf", FileMode.Create));
            doc.Open();

            BaseFont baseFont = BaseFont.CreateFont("C:\\Windows\\Fonts\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);

            PdfPTable table = new PdfPTable(4);
            PdfPCell cell = new PdfPCell(new Phrase("Таблица Поставщиков", font));

            string[] colums = new string[] { "Address", "City", "Country", "Name" };

            cell.Colspan = 4;
            cell.HorizontalAlignment = 1;
            cell.Border = 0;
            table.AddCell(cell);

            for (int j = 0; j < 4; j++)
            {
                cell = new PdfPCell(new Phrase(new Phrase(colums[j], font)));
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell);
            }

            for (int j = 0; j < supplier.Count; j++)
            {
                cell = new PdfPCell(new Phrase(supplier[j].Address));
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(supplier[j].City));
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(supplier[j].Country));
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(supplier[j].Name));
                table.AddCell(cell);
            }
            doc.Add(table);
            doc.Close();

            return true;
        }

        public bool GenerateEmail()
        {
            var fromAddress = new MailAddress("computtech55@gmail.com", "From Name");
            var toAddress = new MailAddress("zditovets55@gmail.com", "To Name");
            const string fromPassword = "zbmtrfqricrqdbpj";
            const string subject = "Test";
            const string body = "All information in the file";
            string file = "C:\\Users\\User\\source\\repos\\ComputerTechnicianBackend\\ComputerTechnicianBackend\\DataSupplier.pdf";
            Attachment attach = new Attachment(file, MediaTypeNames.Application.Octet);

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                message.Attachments.Add(attach);
                smtp.Send(message);
            }

            return true;
        }
    }
}

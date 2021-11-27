using ComputerTechnicianBackend.Data.Domain.Models;
using ComputerTechnicianBackend.Data.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ComputerTechnicianBackend.API.Application.Queries.MailQueries
{
    public class GenerateMailPdfQuery : IRequest
    {
        public GenerateMailPdfQuery() { }
    }

    public class GenerateMailPdfQueryHandler : IRequestHandler<GenerateMailPdfQuery>
    {
        private readonly ISupplierService supplierService;
        private readonly IMailService mailService;

        public GenerateMailPdfQueryHandler(ISupplierService supplierService, IMailService mailService)
        {
            this.supplierService = supplierService;
            this.mailService = mailService;
        }

        public async Task<Unit> Handle(GenerateMailPdfQuery request, CancellationToken cancellationToken)
        {
            var suppliers = await supplierService.GetAllAsync();

            var generate = mailService.GeneratePdf((List<Supplier>)suppliers);

            if (!generate)
            {
                return Unit.Value;
            }

            mailService.GenerateEmail();

            return Unit.Value;
        }
    }
}

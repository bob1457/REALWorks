using MediatR;
using REALWorks.AssetData;
using REALWorks.AssetServer.Commands;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.CommandHandlers
{
    public class UploadSignedContractCommandHandler : IRequestHandler<UploadSignedContractCommand, bool>
    {
        private readonly AppDataBaseContext _context;

        public UploadSignedContractCommandHandler(AppDataBaseContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(UploadSignedContractCommand request, CancellationToken cancellationToken)
        {
            var file = request.ContractFile;

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files\\");
            string url = "files/" + file.FileName;

            if (file.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                {
                    try
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }

                }
            }

            var contract = _context.ManagementContract.FirstOrDefault(c => c.Id ==request.ContractId );

            contract.AddSignedContractFile(url, contract);

            _context.Update(contract);

            //var property = _context.Property.FirstOrDefault(p => p.Id == request.PropertyId);


            //var image = property.AddImages(request.Caption, url, request.PropertyId);


            //_context.Add(image);

            try
            {
                await _context.SaveChangesAsync();

                // logging
                Log.Information("Signed contract for the property {ContractTitle} has been added successfully", contract.ManagementContractTitle);

                // Send messages if necessary

            }
            catch (Exception ex)
            {
                //throw ex;
                Log.Error(ex, "Error occured while adding contract file to the property {ContractTitle}.", contract.ManagementContractTitle);
            }

            return true;


            //throw new NotImplementedException();

        }
    }
}

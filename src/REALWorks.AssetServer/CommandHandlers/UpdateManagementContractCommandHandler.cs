using MediatR;
using Microsoft.EntityFrameworkCore;
using REALWorks.AssetData;
using REALWorks.AssetServer.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.CommandHandlers
{
    public class UpdateManagementContractCommandHandler : IRequestHandler<UpdateManagementContractCommand, bool>
    {
        private readonly AppDataBaseContext _context;

        public UpdateManagementContractCommandHandler(AppDataBaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateManagementContractCommand request, CancellationToken cancellationToken)
        {

            var contract = _context.ManagementContract.Include(p => p.Property).FirstOrDefault(c => c.Id == request.ManagementContractId); //get the record to be updated

            var newContract = contract.Property.UpdateContract(contract, request.ManagementContractTitle, request.StartDate, request.EndDate, 
                request.PlacementFeeScale, request.ManagementContractTitle, request.Notes);


            _context.Update(newContract);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;

            //throw new NotImplementedException();
        }
    }
}

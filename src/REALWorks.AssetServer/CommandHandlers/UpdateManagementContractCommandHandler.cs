using MediatR;
using Microsoft.EntityFrameworkCore;
using REALWorks.AssetData;
using REALWorks.AssetServer.Commands;
using Serilog;
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

            var contract = _context.ManagementContract.Include(p => p.Property).FirstOrDefault(c => c.Id == request.ManagementContractId);      

            var newContract = contract.Property.UpdateContract(contract, request.ManagementContractTitle, request.StartDate, request.EndDate, 
                request.PlacementFeeScale, request.ManagementContractTitle, request.Notes);


            _context.Update(newContract);

            try
            {
                await _context.SaveChangesAsync();

                // logging
                Log.Information("The management contract for the property {PorpertyName} has been updated successfully", contract.Property.PropertyName);

                // Send messages if necessary
            }
            catch (Exception ex)
            {
                //throw ex;
                Log.Error(ex, "Error occured while updating the management contract for the property {PropertyName}.", contract.Property.PropertyName);
            }

            return true;

        }
    }
}

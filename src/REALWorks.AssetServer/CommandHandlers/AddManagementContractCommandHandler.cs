using MediatR;
using REALWorks.AssetData;
using REALWorks.AssetServer.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.CommandHandlers
{
    public class AddManagementContractCommandHandler : IRequestHandler<AddManagementContractCommand, bool>
    {
        private readonly AppDataBaseContext _context;

        public AddManagementContractCommandHandler(AppDataBaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(AddManagementContractCommand request, CancellationToken cancellationToken)
        {
            var property = _context.Property.FirstOrDefault(p => p.Id == request.PropertyId);

            if(request.ManagementContractType.ToString() == "Renewal")
            {
                var existingContract = _context.ManagementContract.FirstOrDefault(a => a.IsActive == true);
                var updatedContract = property.UpdateManagementContractStatus(existingContract, false);
                _context.Update(updatedContract);
            }

            var contract = property.AddManabgementContract(request.PropertyId, request.ManagementContractTitle, request.ManagementContractType,  
                request.StartDate, request.EndDate, request.PlacementFeeScale, request.ManagementFeeScale, 
                request.ContractSignDate, request.IsActive, request.Notes);

            _context.Add(contract);

            try
            {
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;

        }
    }
}

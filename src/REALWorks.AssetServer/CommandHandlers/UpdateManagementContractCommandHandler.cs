using MediatR;
using Microsoft.EntityFrameworkCore;
using REALWorks.AssetData;
using REALWorks.AssetServer.Commands;
using REALWorks.AssetServer.Services.ViewModels;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.CommandHandlers
{
    public class UpdateManagementContractCommandHandler : IRequestHandler<UpdateManagementContractCommand, ManagementContractListByPropertyViewModel>
    {
        private readonly AppDataBaseContext _context;

        public UpdateManagementContractCommandHandler(AppDataBaseContext context)
        {
            _context = context;
        }

        public async Task<ManagementContractListByPropertyViewModel> Handle(UpdateManagementContractCommand request, CancellationToken cancellationToken)
        {

            var contract = _context.ManagementContract.Include(p => p.Property).FirstOrDefault(c => c.Id == request.Id);      

            var updatedContract = contract.Property.UpdateContract(contract, request.ManagementContractTitle, request.StartDate, request.EndDate, 
                request.PlacementFeeScale, request.ManagementContractTitle, request.Notes);


            _context.Update(updatedContract);

            var updatedView = new ManagementContractListByPropertyViewModel();

            try
            {
                await _context.SaveChangesAsync();


                updatedView.Id = request.Id;
                updatedView.ManagementContractTitle = request.ManagementContractTitle;
                updatedView.StartDate = request.StartDate;
                updatedView.EndDate = request.EndDate;
                updatedView.ContractSignDate = request.StartDate;
                updatedView.ManagementFeeScale = request.ManagementFeeScale;
                updatedView.PlacementFeeScale = request.PlacementFeeScale;
                updatedView.ManagementFeeScale = request.Notes;
                updatedView.PropertyName = contract.Property.PropertyName;
                //updatedView.PropertyStreet = contract.Property.Address.PropertyStreet;


                updatedView.Created = contract.Created;
                updatedView.Updated = DateTime.Now;


                // logging
                Log.Information("The management contract for the property {PorpertyName} has been updated successfully", contract.Property.PropertyName);

                // Send messages if necessary
            }
            catch (Exception ex)
            {
                //throw ex;
                Log.Error(ex, "Error occured while updating the management contract for the property {PropertyName}.", contract.Property.PropertyName);
            }

            return updatedView;

        }
    }
}

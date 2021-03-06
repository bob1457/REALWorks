﻿using MediatR;
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
    public class AddManagementContractCommandHandler : IRequestHandler<AddManagementContractCommand, ManagementContractDetailsViewModel>
    {
        private readonly AppDataBaseContext _context;

        public AddManagementContractCommandHandler(AppDataBaseContext context)
        {
            _context = context;
        }

        public async Task<ManagementContractDetailsViewModel> Handle(AddManagementContractCommand request, CancellationToken cancellationToken)
        {
            var property = _context.Property
                .Include(p => p.ManagementContract)
                .FirstOrDefault(p => p.Id == request.PropertyId);

            // Get existing contract
            //
            var existingContract = property.ManagementContract.FirstOrDefault(c => c.IsActive == true);

            if (existingContract != null)
            {
                // Deactivate the existing active contract
                //   
                var updatedContract = property.UpdateManagementContractStatus(existingContract, false);

                _context.Update(updatedContract);



                //if (request.ManagementContractType.ToString() == "Renewal")
                //{
                //    // Deactivate the existing active contract
                //    //
                //    var updatedContract = property.UpdateManagementContractStatus(existingContract, false);                

                //    _context.Update(updatedContract);

                //    // save to db aLL tegether at the end
                //    //

                //    //try
                //    //{
                //    //    await _context.SaveChangesAsync();
                //    //}
                //    //catch(Exception ex)
                //    //{
                //    //    //throw ex;
                //    //    Log.Error(ex, "Error occured while renewing management contract to the property {PropertyName}.", property.PropertyName);
                //    //}

                //    //return new ManagementContractDetailsViewModel() { };

                //}
                //else
                //{

                //}
            }

            


            var contract = property.AddManabgementContract(request.PropertyId, request.ManagementContractTitle, request.ManagementContractType,  
                request.StartDate, request.EndDate, request.PlacementFeeScale, request.ManagementFeeScale, request.SolicitingOnly,
                request.ContractSignDate, true, request.Notes);            

            _context.Add(contract);

            var newContract = new ManagementContractDetailsViewModel();

           


            try
            {
                await _context.SaveChangesAsync();

                //property.UpdateManagementContractStatus(existingContract, false); // disable the previous contract, use case: ownership change

                // map the return view model
                newContract.Id = contract.Id;
                newContract.ManagementContractTitle = request.ManagementContractTitle;
                newContract.StartDate = request.StartDate;
                newContract.EndDate = request.EndDate;
                newContract.ContractSignDate = request.StartDate;
                newContract.ManagementFeeScale = request.ManagementFeeScale;
                newContract.PlacementFeeScale = request.PlacementFeeScale;
                newContract.ManagemetnFeeNotes = request.Notes;
                newContract.PropertyName = contract.Property.PropertyName;
                //newContract.PropertyStreet = 
                newContract.CreateDate = DateTime.Now;
                newContract.UpdateDate = DateTime.Now;

                // logging
                Log.Information("A management contract for the property {PorpertyName} has been added successfully", property.PropertyName);

                // Send messages if necessary, e.g send notificaiton to the contract signers, including owners and pms


            }
            catch (Exception ex)
            {
                //throw ex;
                Log.Error(ex, "Error occured while adding management contract to the property {PropertyName}.", property.PropertyName);
            }

            return newContract;

        }
    }
}

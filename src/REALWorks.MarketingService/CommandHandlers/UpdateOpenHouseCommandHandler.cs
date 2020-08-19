using MediatR;
using REALWorks.MarketingData;
using REALWorks.MarketingService.Commands;
using REALWorks.MarketingService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.MarketingService.CommandHandlers
{
    public class UpdateOpenHouseCommandHandler : IRequestHandler<UpdateOpenHouseCommand, UpdateOpenHouseViewModel>
    {
        private readonly AppMarketingDbDataContext _context;        

        public UpdateOpenHouseCommandHandler(AppMarketingDbDataContext context)
        {
            _context = context;            
        }

        public async Task<UpdateOpenHouseViewModel> Handle(UpdateOpenHouseCommand request, CancellationToken cancellationToken)
        {
            var openHouse = _context.OpenHouse.FirstOrDefault(o => o.Id == request.Id);


           var updated = openHouse.Update(openHouse, request.OpenhouseDate, request.IsActive, request.StartTime, request.EndTime, request.Notes);

            _context.OpenHouse.Update(updated);

            var updatedOH = new UpdateOpenHouseViewModel();

            updatedOH.OpenhouseDate = updated.OpenhouseDate;
            updatedOH.StartTime = updated.StartTime;
            updatedOH.EndTime = updated.EndTime;
            updatedOH.IsActive = updated.IsActive;
            updatedOH.Notes = updated.Notes;
            updatedOH.Id = updated.Id;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return updatedOH;

            //throw new NotImplementedException();
        }
    }
}

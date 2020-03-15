using MediatR;
using Microsoft.EntityFrameworkCore;
using REALWorks.MarketingCore.Entities;
using REALWorks.MarketingData;
using REALWorks.MarketingService.Commands;
using REALWorks.MarketingService.ViewModels;
using REALWorks.MessagingServer.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.MarketingService.CommandHandlers
{
    public class CreateOpenHouseCommandHandler : IRequestHandler<CreateOpenHouseCommand, OpenHouseViewModel>
    {
        private readonly AppMarketingDbDataContext _context;

        IMessagePublisher _messagePublisher;

        public CreateOpenHouseCommandHandler(AppMarketingDbDataContext context, IMessagePublisher messagePublisher)
        {
            _context = context;
            _messagePublisher = messagePublisher;
        }

        public async Task<OpenHouseViewModel> Handle(CreateOpenHouseCommand request, CancellationToken cancellationToken)
        {
            var oh = new OpenHouse(request.RentalPropertyId, request.OpenhouseDate, request.StartTime, 
                request.EndTime, request.IsActive, request.Notes, DateTime.Now, DateTime.Now);

            _context.OpenHouse.Add(oh);

            var newOpenHouse = new OpenHouseViewModel();

            newOpenHouse.OpenhouseDate = request.OpenhouseDate;
            newOpenHouse.IsActive = request.IsActive;
            newOpenHouse.StartTime = request.StartTime;
            newOpenHouse.EndTime = request.EndTime;
            newOpenHouse.Notes = request.Notes;

            var openProeprty = _context.RentalProperty.Include(a => a.Address).FirstOrDefault(p => p.Id == request.RentalPropertyId);

            newOpenHouse.PropertyName = openProeprty.PropertyName;
            newOpenHouse.PropertyType = openProeprty.PropertyType;

            newOpenHouse.streetCity = openProeprty.Address.StreetNum;
            newOpenHouse.streetCity = openProeprty.Address.City;
            newOpenHouse.PropertyType = openProeprty.Address.StateProvince;
            newOpenHouse.streetPostZipCode = openProeprty.Address.ZipPostCode;


            try
            {
                await _context.SaveChangesAsync();

                newOpenHouse.Id = oh.Id;

                // Send message to message queue if needed

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return newOpenHouse;

            //throw new NotImplementedException();
        }
    }
}

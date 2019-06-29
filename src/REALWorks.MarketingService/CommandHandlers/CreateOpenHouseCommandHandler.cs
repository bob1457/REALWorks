using MediatR;
using REALWorks.MarketingCore.Entities;
using REALWorks.MarketingData;
using REALWorks.MarketingService.Commands;
using REALWorks.MessagingServer.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.MarketingService.CommandHandlers
{
    public class CreateOpenHouseCommandHandler : IRequestHandler<CreateOpenHouseCommand, bool>
    {
        private readonly AppMarketingDbDataContext _context;

        IMessagePublisher _messagePublisher;

        public CreateOpenHouseCommandHandler(AppMarketingDbDataContext context, IMessagePublisher messagePublisher)
        {
            _context = context;
            _messagePublisher = messagePublisher;
        }

        public async Task<bool> Handle(CreateOpenHouseCommand request, CancellationToken cancellationToken)
        {
            var oh = new OpenHouse(request.RentalPropertyId, request.OpenhouseDate, request.StartTime, 
                request.EndTime, request.IsActive, request.Notes, DateTime.Now, DateTime.Now);

            _context.OpenHouse.Add(oh);

            try
            {
                await _context.SaveChangesAsync();

                // Send message to message queue if needed

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

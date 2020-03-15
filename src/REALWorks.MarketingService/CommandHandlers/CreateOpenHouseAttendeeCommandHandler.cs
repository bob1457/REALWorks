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
    public class CreateOpenHouseAttendeeCommandHandler : IRequestHandler<CreateOpenHouseAttendeeCommand, bool>
    {
        private readonly AppMarketingDbDataContext _context;

        IMessagePublisher _messagePublisher;

        public CreateOpenHouseAttendeeCommandHandler(AppMarketingDbDataContext context, IMessagePublisher messagePublisher)
        {
            _context = context;
            _messagePublisher = messagePublisher;
        }

        public async Task<bool> Handle(CreateOpenHouseAttendeeCommand request, CancellationToken cancellationToken)
        {
            var attendee = new OpenHouseViewer(request.OpenHouseId, request.FirstName, request.LastName, 
                request.ContactTel, request.ContactEmail, request.NumberOfPeople, request.ContactType, DateTime.Now, DateTime.Now);

            _context.OpenHouseViewer.Add(attendee);

            try
            {
                await _context.SaveChangesAsync();

                // Send message to message queue for notification
                //


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

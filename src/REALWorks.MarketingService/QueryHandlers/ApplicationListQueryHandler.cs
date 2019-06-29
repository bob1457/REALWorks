using MediatR;
using REALWorks.MarketingData;
using REALWorks.MarketingService.Queries;
using REALWorks.MarketingService.ViewModels;
using REALWorks.MessagingServer.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.MarketingService.QueryHandlers
{
    public class ApplicationListQueryHandler : IRequestHandler<ApplicationiListQuery, IQueryable<ApplicationListViewModel>>
    {
        private readonly AppMarketingDbDataContext _context;
        
        public ApplicationListQueryHandler(AppMarketingDbDataContext context)
        {
            _context = context;           
        }

        public async Task<IQueryable<ApplicationListViewModel>> Handle(ApplicationiListQuery request, CancellationToken cancellationToken)
        {
            var applicantList = (from a in _context.RentalApplicant
                                 from p in _context.RentalProperty
                                 where p.Id == request.Id
                                 select new ApplicationListViewModel
                                 {
                                     PropertyName = p.PropertyName,
                                     ApplicatnFirstName = a.FirstName,
                                     ApplicatnLastName = a.LastName,
                                     ApplicantContactTel = a.ContactTel,
                                     ApplicantContactEmail = a.ContactEmail,
                                     ApplicantNubmerOfOccupants = a.NumberOfOccupant,
                                     AppliedDate = a.Created
                                     
                                 }).AsQueryable();

            return applicantList;

            //throw new NotImplementedException();
        }
    }
}

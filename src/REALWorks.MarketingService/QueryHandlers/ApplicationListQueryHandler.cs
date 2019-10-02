using MediatR;
using Microsoft.EntityFrameworkCore;
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

            /*
             * THE QUERY NEEDS TO BE RE-WORKED!!!!
             
             */

            //var applicantList = (from a in _context.RentalApplication
            //                     from t in _context.RentalApplicant
            //                     from p in _context.RentalProperty
            //                     where p.Id == request.Id // eliminate this for ALL applications
            //                     select new ApplicationListViewModel
            //                     {
            //                         PropertyName = p.PropertyName,
            //                         ApplicatnFirstName = a.FirstName,
            //                         ApplicatnLastName = a.LastName,
            //                         ApplicantContactTel = a.ContactTel,
            //                         ApplicantContactEmail = a.ContactEmail,
            //                         ApplicantNubmerOfOccupants = a.NumberOfOccupant,
            //                         AppliedDate = a.Created

            //                     }).AsQueryable();

            var applicationList = (from a in _context.RentalApplication
                                  .Include(r => r.RentalProperty)
                                  .Include(p => p.RentalApplicant).ToList()
                                   select new ApplicationListViewModel
                                   {
                                       RentalApplicationId = a.Id,

                                       PropertyName = a.RentalProperty.PropertyName,
                                       ApplicatnFirstName = a.RentalApplicant.FirstName,
                                       ApplicatnLastName = a.RentalApplicant.LastName,
                                       ApplicantContactTel = a.RentalApplicant.ContactTel,
                                       ApplicantContactEmail = a.RentalApplicant.ContactEmail,
                                       ApplicantNubmerOfOccupants = a.RentalApplicant.NumberOfOccupant,
                                       AppliedDate = a.Created
                                   }).AsQueryable();

            return applicationList;

            //throw new NotImplementedException();
        }
    }
}

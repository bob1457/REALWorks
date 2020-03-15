using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using REALWorks.MarketingData;
using REALWorks.MarketingService.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.MarketingService.CommandHandlers
{
    public class RemoveImageToPropertyCommandHandler : IRequestHandler<RemoveImageToPropertyCommand, Unit>
    {
        private readonly AppMarketingDbDataContext _context;        

        public RemoveImageToPropertyCommandHandler(AppMarketingDbDataContext context)
        {
            _context = context;           
        }

        public async Task<Unit> Handle(RemoveImageToPropertyCommand request, CancellationToken cancellationToken)
        {           
            var imgToRemove = _context.PropertyImg.FirstOrDefault(i => i.Id == request.Id);

            _context.PropertyImg.Remove(imgToRemove);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            // Delete image file
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\");

            int start = imgToRemove.PropertyImgUrl.LastIndexOf("/");

            string fName = imgToRemove.PropertyImgUrl.Substring(start + 1);

            string file = path + "\\" + fName;

            File.Delete(file);

            //throw new NotImplementedException();

            return await Unit.Task;
        }
    }
}

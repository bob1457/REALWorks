using MediatR;
using Newtonsoft.Json;
using REALWorks.AssetCore.Entities;
using REALWorks.AssetData;
using REALWorks.AssetServer.Commands;
using REALWorks.AssetServer.Events;
using REALWorks.AuthServer.Events;
using REALWorks.MessagingServer.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.CommandHandlers
{
    public class EnableOnlineAccessCommandHandler : IRequestHandler<EnableOnlineAccessCommand, bool>
    {
        private readonly AppDataBaseContext _context;

        IMessagePublisher _messagePublisher;
       

        public EnableOnlineAccessCommandHandler(AppDataBaseContext context, IMessagePublisher messagePublisher )
        {
            _context = context;
            _messagePublisher = messagePublisher;
            
        }

        public async Task<bool> Handle(EnableOnlineAccessCommand request, CancellationToken cancellationToken)
        {
            var roleId = request.UserRole;

            

            switch (roleId)
            {
                case "owner":
                    var user = _context.PropertyOwner.FirstOrDefault(i => i.Id == request.Id);

                    request.FirstName = user.FirstName;
                    request.LastName = user.LastName;
                    request.Email = user.ContactEmail;
                    
                    
                    if (!request.Enable)
                    {
                        request.UserName = "NotSet";                       
                    }

                    user.ConfigOnlineAccess(request.Enable, request.UserName);

                    //var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8);

                    //var client = _httpClientFactory.CreateClient();
                    //client.BaseAddress = new Uri("");
                    //var result = await client.PostAsync("", content);


                    break;
                case "tenant":

                    break;

                default:
                    break;
            }


            try
            {
                // Persist data
                //
                //await _context.SaveChangesAsync(); // comment out for testing ONLY

                // Call auth API to create user account
                //
                var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

                //var client = _httpClientFactory.CreateClient();
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:58088/api/Account/register");
                var result = await client.PostAsync("http://localhost:58088/api/Account/register", content);

                // Send message to MQ
                //
                //Events.EnableOnlineAccessEvent e = new Events.EnableOnlineAccessEvent(Guid.NewGuid(), request.Email, request.Password,
                //    request.FirstName, request.LastName, request.UserName, request.UserRole, request.Enable);
                

                //await _messagePublisher.PublishMessageAsync(e.MessageType, e, "real");


            }
            catch (Exception ex)
            {
                throw ex;
            }

            //var returnedUser = 

            return true;

            //throw new NotImplementedException();
        }
    }
}

using MediatR;
using Newtonsoft.Json;
using REALWorks.AssetCore.Entities;
using REALWorks.AssetData;
using REALWorks.AssetServer.Commands;
using REALWorks.AssetServer.Events;
using REALWorks.AuthServer.Events;
using REALWorks.MessagingServer.Messages;
using Serilog;
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

            //var user = _context.PropertyOwner.FirstOrDefault(e => e.ContactEmail == request.Email);

            //PropertyOwner user = null;

            switch (roleId)
            {
                case "owner":
                    var user = _context.PropertyOwner.FirstOrDefault(i => i.Id == request.Id);

                    try
                    {
                        //var user = _context.PropertyOwner.FirstOrDefault(e => e.ContactEmail == request.Email);

                        if (!user.OnlineAccess)
                        {
                            user.ConfigOnlineAccess(request.Enable, "Notset");
                        }

                        string subject = "Online Access Enabled";
                        string body = "Dear " + user.FirstName + ": \n Your online access privilage has been enabled, please go to this link to register your account! \n Thanks.";

                        //Construct notification event to Notificaiton message queue
                        Events.EmailNotificationEvent e = new Events.EmailNotificationEvent(new Guid(), user.ContactEmail, subject, body);                        

                        try
                        {
                            await _context.SaveChangesAsync();

                            await _messagePublisher.PublishMessageAsync(e.MessageType, e, "notification");
                            Log.Information("Message  {MessageType} with Id {MessageId} has been published successfully", e.MessageType, e.MessageId);
                        }
                        catch (Exception ex)
                        {
                            //throw ex;
                            Log.Error(ex, "Error while publishing {MessageType} message with id {MessageId}.", e.MessageType, e.MessageId);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    break;
                case "tenant":

                    break;

                default:
                    break;
            }

            

            /*
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
            */
            return true;

            //throw new NotImplementedException();
        }
    }
}

using Microsoft.AspNetCore.SignalR;
using TrackingService.Domain;

namespace TrackingService.Api.Hubs
{
    public class MessagesHub : Hub
    {
        private readonly ILogger<MessagesHub> _logger;

        public MessagesHub(ILogger<MessagesHub> logger)
        {
            _logger = logger;
        }

        public override Task OnConnectedAsync() //przechwytuje podłączenie się każdego pojedynczego klienta pod huba
        {
            //Zła praktyka logowania
            //_logger.LogInformation($"Connection: {this.Context.ConnectionId}");

            //Dobra praktyka
            _logger.LogInformation("ConnectionId {ConnectionId}", Context.ConnectionId);

            
            //Groups.AddToGroupAsync(Context.ConnectionId, "GroupA");

            return base.OnConnectedAsync();
        }


        public async Task SendMessage(Message message)
        {
            //await Clients.All.SendAsync("YouHaveGotMessage", message);
            
            //Lub aby wysłać do wszystkich pozostałych

            await Clients.Others.SendAsync("YouHaveGotMessage", message);
        }
        public async Task SendMessageToGroup(Message message)
        {
            //await Clients.Group("GroupA").SendAsync("YouHaveGotMessage", message);
        }
        public async Task Ping()
        {
            await Clients.Caller.SendAsync("Pong");
        }

    }
}

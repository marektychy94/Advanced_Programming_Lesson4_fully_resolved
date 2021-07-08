using AdvancedProgramming_Lesson4.Data;
using AdvancedProgramming_Lesson4.Models;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace AdvancedProgramming_Lesson4.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ApplicationDbContext _context;

        public ChatHub(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
            var authenticated = Context.User.Identity.IsAuthenticated;

            if (authenticated)
            {
                System.Diagnostics.Debug.WriteLine("tak", Context.User.Identity.Name);
                Messages msg = new Messages();
                msg.UserName = Context.User.Identity.Name;
                msg.Message = message;
                msg.Authenticated = authenticated;
                _context.Messages.Add(msg);
                _context.SaveChanges();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("nie");
                Messages msg = new Messages();
                msg.UserName = user;
                msg.Message = message;
                msg.Authenticated = authenticated;
                _context.Messages.Add(msg);
                _context.SaveChanges();
            }
        }
    }
}

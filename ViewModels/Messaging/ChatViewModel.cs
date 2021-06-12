using Airbnb.Models;
using Airbnb.Models.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.ViewModels.Messaging
{
    public class ChatViewModel
    {
        public Chat Chat { get; set; }
        public AppUser CurrentUser { get; set; }
    }
}

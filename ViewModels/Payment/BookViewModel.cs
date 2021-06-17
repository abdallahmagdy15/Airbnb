using Airbnb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.ViewModels.Payment
{
    public class BookViewModel
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public long Amount { get; set; }
        public Property Property { get; set; }
    }
}

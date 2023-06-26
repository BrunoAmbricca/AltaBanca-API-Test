using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltaBanca_API_Test.Logs
{
    public class CustomerLogError
    {
        public int CustomerLogErrorId { get; set; }
        public string Description { get; set; }
        public int EventType { get; set; }
        public DateTime Logged { get; set; }

        public CustomerLogError(string description, int eventType, DateTime logged)
        {
            this.Description = description;
            this.EventType = eventType;
            this.Logged = logged;
        }
    }
}

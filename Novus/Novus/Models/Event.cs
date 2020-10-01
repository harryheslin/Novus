using System;
using System.Collections.Generic;
using System.Text;

namespace Novus.Models
{
    class Event
    {
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string EventColour { get; set; }
        public bool IsAllDay { set; get; }
        
    }
}

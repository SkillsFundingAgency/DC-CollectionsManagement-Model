using System;
using System.Collections.Generic;
using System.Text;

namespace ESFA.DC.CollectionsManagement.Models
{
    public class ReturnCalendar
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string PeriodName { get; set; }
        public int CalendarMonth { get; set; }
        public int CalendarYear { get; set; }
        public Collection Collection { get; set; }
    }
}

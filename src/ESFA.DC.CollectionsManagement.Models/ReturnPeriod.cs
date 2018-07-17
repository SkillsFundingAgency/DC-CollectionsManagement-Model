using System;

namespace ESFA.DC.CollectionsManagement.Models
{
    public class ReturnPeriod
    {
        public DateTime StartDateTimeUtc { get; set; }
        public DateTime EndDateTimeUtc { get; set; }
        public string PeriodName { get; set; }
        public string CollectionName { get; set; }
        public int CalendarMonth { get; set; }
        public int CalendarYear { get; set; }
    }
}

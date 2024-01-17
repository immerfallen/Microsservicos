using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.SB1.Objects
{
    public class Activities
    {
        public string odataetag { get; set; }

        [Key]
        public int ActivityCode { get; set; }
        public string CardCode { get; set; }
        public string Notes { get; set; }
        public string ActivityDate { get; set; }
        public string ActivityTime { get; set; }
        public string StartDate { get; set; }
        public string Closed { get; set; }
        public string CloseDate { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public int Subject { get; set; }
        public string DocType { get; set; }
        public string DocNum { get; set; }
        public string DocEntry { get; set; }
        public string Priority { get; set; }
        public string Details { get; set; }
        public string Activity { get; set; }
        public int ActivityType { get; set; }
        public int Location { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public double Duration { get; set; }
        public string DurationType { get; set; }
        public int SalesEmployee { get; set; }
        public int ContactPersonCode { get; set; }
        public int HandledBy { get; set; }
        public string Reminder { get; set; }
        public double ReminderPeriod { get; set; }
        public string ReminderType { get; set; }
        public string City { get; set; }
        public string PersonalFlag { get; set; }
        public string Street { get; set; }
        public string ParentstringId { get; set; }
        public string ParentstringType { get; set; }
        public string Room { get; set; }
        public string InactiveFlag { get; set; }
        public string State { get; set; }
        public string PreviousActivity { get; set; }
        public string Country { get; set; }
        public int Status { get; set; }
        public string TentativeFlag { get; set; }
        public string EndDueDate { get; set; }
        public string DocTypeEx { get; set; }
        public int AttachmentEntry { get; set; }
        public string RecurrencePattern { get; set; }
        public string EndType { get; set; }
        public string SeriesStartDate { get; set; }
        public string SeriesEndDate { get; set; }
        public int MaxOccurrence { get; set; }
        public int Interval { get; set; } = 1;
        public string Sunday { get; set; }
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }
        public string Saturday { get; set; }
        public string RepeatOption { get; set; }
        public string BelongedSeriesNum { get; set; }
        public string IsRemoved { get; set; }
        public string AddressName { get; set; }
        public string AddressType { get; set; }
        public string HandledByEmployee { get; set; }
        public string RecurrenceSequenceSpecifier { get; set; }
        public string RecurrenceDayInMonth { get; set; }
        public string RecurrenceMonth { get; set; }
        public string RecurrenceDayOfWeek { get; set; }
        public string SalesOpportunityId { get; set; }
        public string SalesOpportunityLine { get; set; }
        public string HandledByRecipientList { get; set; }
        public string Office365EventId { get; set; }
        public int DataVersion { get; set; }
        public string[] CheckInListParams { get; set; }
        public string[] ActivityMultipleRecipients { get; set; }
    }

}

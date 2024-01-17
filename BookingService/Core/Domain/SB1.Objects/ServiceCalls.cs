using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.SB1.Objects
{
    public class ServiceCalls
    {
        public int ServiceCallID { get; set; }
        public string Subject { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public int ContactCode { get; set; }
        public string ManufacturerSerialNum { get; set; }
        public string internalSerialNum { get; set; }
        public string ContractID { get; set; }
        public string ContractEndDate { get; set; }
        public string ResolutionDate { get; set; }
        public string ResolutionTime { get; set; }
        public int Origin { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public string ItemGroupCode { get; set; }
        public int Status { get; set; }
        public string Priority { get; set; }
        public string CallType { get; set; }
        public string ProblemType { get; set; }
        public int AssigneeCode { get; set; }
        public string Description { get; set; }
        public string TechnicianCode { get; set; }
        public string Resolution { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreationTime { get; set; }
        public int Responder { get; set; }
        public string UpdatedTime { get; set; }
        public string BelongsToAQueue { get; set; }
        public string ResponseByTime { get; set; }
        public string ResponseByDate { get; set; }
        public DateTime? ResolutionOnDate { get; set; }
        public string ResponseOnTime { get; set; }
        public DateTime? ResponseOnDate { get; set; }
        public string ClosingTime { get; set; }
        public DateTime AssignedDate { get; set; }
        public string Queue { get; set; }
        public int ResponseAssignee { get; set; }
        public string EntitledforService { get; set; }
        public string ResolutionOnTime { get; set; }
        public string AssignedTime { get; set; }
        public DateTime? ClosingDate { get; set; }
        public int Series { get; set; }
        public int DocNum { get; set; }
        public string HandWritten { get; set; }
        public string PeriodIndicator { get; set; }
        public DateTime StartDate { get; set; }
        public string StartTime { get; set; }
        public DateTime EndDueDate { get; set; }
        public string EndTime { get; set; }
        public double Duration { get; set; }
        public string DurationType { get; set; }
        public string Reminder { get; set; }
        public double ReminderPeriod { get; set; }
        public string ReminderType { get; set; }
        public int Location { get; set; }
        public string AddressName { get; set; }
        public string AddressType { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Room { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string DisplayInCalendar { get; set; }
        public string CustomerRefNo { get; set; }
        public string ProblemSubType { get; set; }
        public string AttachmentEntry { get; set; }
        public string ServiceBPType { get; set; }
        public string BPContactPerson { get; set; }
        public string BPPhone1 { get; set; }
        public string BPPhone2 { get; set; }
        public string BPCellular { get; set; }
        public string BPFax { get; set; }
        public string BPeMail { get; set; }
        public string BPProjectCode { get; set; }
        public int BPTerritory { get; set; }
        public string BPShipToCode { get; set; }
        public string BPShipToAddress { get; set; }
        public string BPBillToCode { get; set; }
        public string BPBillToAddress { get; set; }
        public string Telephone { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string SupplementaryCode { get; set; }
        public List<Servicecallactivity> ServiceCallActivities { get; set; }
        public List<object> ServiceCallInventoryExpenses { get; set; }
        public List<Servicecallsolution> ServiceCallSolutions { get; set; }
        public List<object> ServiceCallSchedulings { get; set; }
        public List<Servicecallbpaddresscomponent> ServiceCallBPAddressComponents { get; set; }

        public ServiceCalls()
        {
            ServiceCallActivities = new List<Servicecallactivity>();
            ServiceCallInventoryExpenses = new List<object>();
            ServiceCallSolutions = new List<Servicecallsolution>();
            ServiceCallSchedulings = new List<object>();
            ServiceCallBPAddressComponents = new List<Servicecallbpaddresscomponent>();
        }
    }

    public class Servicecallactivity
    {
        public int LineNum { get; set; }
        public int ActivityCode { get; set; }
    }

    public class Servicecallsolution
    {
        public int LineNum { get; set; }
        public int SolutionID { get; set; }
    }

    public class Servicecallbpaddresscomponent
    {
        public string ShipToStreet { get; set; }
        public string ShipToStreetNo { get; set; }
        public string ShipToBlock { get; set; }
        public string ShipToBuilding { get; set; }
        public string ShipToCity { get; set; }
        public string ShipToZipCode { get; set; }
        public string ShipToState { get; set; }
        public string ShipToCounty { get; set; }
        public string ShipToCountry { get; set; }
        public string ShipToAddressType { get; set; }
        public object ShipToAddress2 { get; set; }
        public object ShipToAddress3 { get; set; }
        public object ShipToGlobalLocationNumber { get; set; }
        public string BillToStreet { get; set; }
        public string BillToStreetNo { get; set; }
        public string BillToBlock { get; set; }
        public string BillToBuilding { get; set; }
        public string BillToCity { get; set; }
        public string BillToZipCode { get; set; }
        public string BillToState { get; set; }
        public string BillToCounty { get; set; }
        public string BillToCountry { get; set; }
        public string BillToAddressType { get; set; }
        public object BillToAddress2 { get; set; }
        public object BillToAddress3 { get; set; }
        public object BillToGlobalLocationNumber { get; set; }
    }


}

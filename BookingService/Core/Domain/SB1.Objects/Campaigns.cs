using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.SB1.Objects
{
    public class Campaigns
    {
        [Key]
        public int CampaignNumber { get; set; }
        public string CampaignName { get; set; }
        public string CampaignType { get; set; }
        public string TargetGroup { get; set; }
        public int Owner { get; set; }
        public string Status { get; set; }
        public string StartDate { get; set; }
        public string FinishDate { get; set; }
        public string Remarks { get; set; }
        public string GeneratedByWizard { get; set; }
        public string AttachementsEntry { get; set; }
        public string TargetGroupType { get; set; }
        public List<CampaignBusinessPartner> CampaignBusinessPartners { get; set; }
        public List<CampaignItem> CampaignItems { get; set; }
        public Nullable<int> PO_MkpId { get; set; }

        public Campaigns()
        {
            CampaignBusinessPartners = new List<CampaignBusinessPartner>();
            CampaignItems = new List<CampaignItem>();
        }
    }

    public class CampaignBusinessPartner
    {
        public int CampaignNumber { get; set; }
        public int CampaignLineNumber { get; set; }
        public string BPCode { get; set; }
        public string BPName { get; set; }
        public string BPGroupName { get; set; }
        public string BPIndustryName { get; set; }
        public string BPStatus { get; set; }
        public object ContactCode { get; set; }
        public object ContactTitle { get; set; }
        public object ContactPosition { get; set; }
        public object ContactEmail { get; set; }
        public object ContactTelephone { get; set; }
        public object ContactMobile { get; set; }
        public object ContactFax { get; set; }
        public object ContactAddress { get; set; }
        public string Response { get; set; }
        public object RelatedSalesOpportunity { get; set; }
        public object Street { get; set; }
        public object Block { get; set; }
        public object City { get; set; }
        public object ZipCode { get; set; }
        public object County { get; set; }
        public object State { get; set; }
        public string Country { get; set; }
        public object Building { get; set; }
        public string DocType { get; set; }
        public string IsShowLinkedDoc { get; set; }
        public object DocNumber { get; set; }
        public object DocEntry { get; set; }
        public object FirstName { get; set; }
        public object MiddleName { get; set; }
        public object LastName { get; set; }
        public string AddressID { get; set; }
        public string AddressType { get; set; }
        public string AddressName2 { get; set; }
        public string AddressName3 { get; set; }
        public object FederalTaxID { get; set; }
        public string StreetNo { get; set; }
        public string CreateActivity { get; set; }
        public string AssignTo { get; set; }
        public int AssignName { get; set; }
        public object ResponseType { get; set; }
    }

    public class CampaignItem
    {
        public int CampaignNumber { get; set; }
        public int CampaignLineNumber { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemType { get; set; }
        public string ItemGroup { get; set; }
    }

}

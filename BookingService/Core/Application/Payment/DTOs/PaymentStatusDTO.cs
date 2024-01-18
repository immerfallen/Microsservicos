namespace Application.Payment.DTOs
{
    public enum Status
    {
        Success = 0,
        Failed = 1,
        Error =2,
        Endefined = 3
    }
    public class PaymentStatusDTO
    {
        public Status Status { get; set; }
        public string PaymentId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string  Message { get; set; }
    }
}

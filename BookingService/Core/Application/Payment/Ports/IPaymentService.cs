using Application.Payment.DTOs;
using Application.Payment.Responses;

namespace Application.Payment.Ports
{
    public interface IPaymentService
    {
        Task<PaymentResponse> PaymentStateDTO(string paymentIntention);
        Task<PaymentResponse> PayWithDebitCard(string paymentIntention);
        Task<PaymentResponse> PayBankTransfer(string paymentIntention);
    }                                                  
}                                                      
                                                       
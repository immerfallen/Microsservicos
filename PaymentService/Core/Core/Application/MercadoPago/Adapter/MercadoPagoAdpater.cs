using Application.Payment.DTOs;
using Application.Payment.Ports;
using Application.Payment.Responses;
using Payment.Application.MercadoPago.Exceptions;

namespace Payment.Application.MercadoPago.Adapter
{
    public class MercadoPagoAdpater : IPaymentProcessor
    {      

        public Task<PaymentResponse> CapturePayment(string paymentIntention)
        {
            if (string.IsNullOrEmpty(paymentIntention))
            {
                var dtoError = new PaymentResponse
                {
                    Success = true,
                    Errors = new List<string> {"Erro ao processar o pagamento"},
                    Data = new PaymentStatusDTO(),
                    Message = "Failure while processing payment"
                };                
            }

            var dto = new PaymentStatusDTO
            {
                CreatedDate = DateTime.UtcNow,
                PaymentId = paymentIntention,
                Status = Status.Success,
                Message = "Failure while processing payment"
            };

            var res = new PaymentResponse
            {
                Success = true,
                Errors = new List<string>(),
                Data = dto,
                Message = "Successfully paid"
            };
            return Task.FromResult(res);
        }

        public Task<PaymentResponse> CreatePayment(string paymentIntention)
        {
            throw new NotImplementedException();
        }
    }
}

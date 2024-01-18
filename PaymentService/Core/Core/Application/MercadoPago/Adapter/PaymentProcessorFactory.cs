using Application.Payment.DTOs;
using Application.Payment.Ports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Application.MercadoPago.Adapter
{
    public class PaymentProcessorFactory : IPaymentProcessorFactory
    {
        public IPaymentProcessor CreatePayment(string paymentIntention)
        {
            throw new NotImplementedException();
        }

        public IPaymentProcessor GetPaymentProcessor(SupportedPaymentProviders selectedPaymentProvider)
        {
            switch (selectedPaymentProvider)
            {                   
                case SupportedPaymentProviders.MercadoPago:
                   return new MercadoPagoAdpater();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}

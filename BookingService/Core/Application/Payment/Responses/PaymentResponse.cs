using Application.Payment.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Payment.Responses
{
    public class PaymentResponse : Response
    {
        public PaymentStatusDTO Data { get; set; }
    }
}

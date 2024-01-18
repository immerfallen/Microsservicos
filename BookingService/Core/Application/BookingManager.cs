using Application.Booking.DTOs;
using Application.Booking.Ports;
using Application.Booking.Responses;
using Application.Payment.DTOs;
using Application.Payment.Ports;
using Application.Payment.Responses;
using Domain.Booking.Ports;
using Domain.Guest.Ports;
using Domain.Room.Ports;

namespace Application
{
    public class BookingManager : IBookingManager
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IGuestRepository _guestRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IPaymentProcessorFactory _paymentProcessorFactory;

        public BookingManager(IBookingRepository bookingRepository, IGuestRepository guestRepository, IRoomRepository roomRepository, IPaymentProcessorFactory paymentProcessorFactory)
        {
            _bookingRepository = bookingRepository;
            _guestRepository = guestRepository;
            _roomRepository = roomRepository;
            _paymentProcessorFactory = paymentProcessorFactory;
        }

        public async Task<BookingResponse> CreateBooking(BookingDTO bookingDTO)
        {
            try
            {
                var booking = BookingDTO.MapToEntity(bookingDTO);
                booking.Guest = await _guestRepository.Get(bookingDTO.GuestId);
                booking.Room = await _roomRepository.Get(bookingDTO.RoomId);
                await booking.Save(_bookingRepository);
                bookingDTO.Id = booking.Id;

                return new BookingResponse
                {
                    Data = bookingDTO,
                    Success = true,
                };
            }
            catch (Exception ex)
            {
            // implementação das exceções personalizadas
                throw;
            }            
        }

        public async Task<PaymentResponse> PayForBooking(PaymentRequestDTO payment)
        {
            var paymentProcessor = _paymentProcessorFactory.GetPaymentProcessor(payment.SelectedPaymentProvider);

            var response = await paymentProcessor.CapturePayment(payment.PaymentIntention);

            if (response.Success)
            {
                return new PaymentResponse
                {
                    Success = true,
                    Data = response.Data,
                    Message = "Payment successfully processed"

                };
            }
            return response;
        }

        public Task<BookingResponse> GetBooking(int bookingID)
        {
            throw new NotImplementedException();
        }        
    }
}

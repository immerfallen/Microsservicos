namespace Domain.Booking.Ports
{
    public interface IBookingRepository
    {
        Task<Entities.Booking> GetBookingAsync(int bookingId);
        Task<Entities.Booking> CreateBookingAsync(Entities.Booking booking);
    }
}

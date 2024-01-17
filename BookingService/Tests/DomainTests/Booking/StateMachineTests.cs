using Domain.Booking.Entities;
using Domain.Guest.Entities;
using Domain.Guest.Enums;

namespace DomainTests.Bookings
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldAlwaysStatedWithCreatedStatus()
        {
            var booking = new Booking();
            Assert.AreEqual(booking.CurrentStatus, Status.Created);
        }

        [Test]
        public void ShouldSetstatusToPaidWhenPayingforABookingWithCreatedStatus()
        {
            var booking = new Booking();
            booking.ChangeState(Domain.Guest.Enums.Action.Pay);

            Assert.AreEqual(booking.CurrentStatus, Status.Paid);
        }

        [Test]
        public void ShouldSetstatusToCancelWhenCancelingABookingWithCreatedStatus()
        {
            var booking = new Booking();
            booking.ChangeState(Domain.Guest.Enums.Action.Cancel);

            Assert.AreEqual(booking.CurrentStatus, Status.Canceled);
        }

        [Test]
        public void ShouldSetstatusToFinishWhenFinishinABookingWithPaidBooking()
        {
            var booking = new Booking();
            booking.ChangeState(Domain.Guest.Enums.Action.Pay);
            booking.ChangeState(Domain.Guest.Enums.Action.Finish);

            Assert.AreEqual(booking.CurrentStatus, Status.Finished);
        }


        [Test]
        public void ShouldSetstatusToRefoundedWhenRefoundedABookingWithPaidBooking()
        {
            var booking = new Booking();
            booking.ChangeState(Domain.Guest.Enums.Action.Pay);
            booking.ChangeState(Domain.Guest.Enums.Action.Refound);

            Assert.AreEqual(booking.CurrentStatus, Status.Refounded);
        }

        [Test]
        public void ShouldSetStatusToCreatedWhenReopeningACanceledBooking()
        {
            var booking = new Booking();
            booking.ChangeState(Domain.Guest.Enums.Action.Cancel);
            booking.ChangeState(Domain.Guest.Enums.Action.Reopen);

            Assert.AreEqual(booking.CurrentStatus, Status.Created);
        }


        [Test]
        public void ShouldNotSetStatusWhenRefoundingACreatedBooking()
        {
            var booking = new Booking();           
            booking.ChangeState(Domain.Guest.Enums.Action.Refound);

            Assert.AreEqual(booking.CurrentStatus, Status.Created);
        }

        [Test]
        public void ShouldNotSetStatusWhenRefoundingAFinishedBooking()
        {
            var booking = new Booking();

            booking.ChangeState(Domain.Guest.Enums.Action.Pay);
            booking.ChangeState(Domain.Guest.Enums.Action.Finish);
            booking.ChangeState(Domain.Guest.Enums.Action.Refound);

            Assert.AreEqual(booking.CurrentStatus, Status.Finished);
        }
    }
}
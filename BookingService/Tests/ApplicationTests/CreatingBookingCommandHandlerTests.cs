using Application.Booking.Commands;
using Castle.DynamicProxy.Generators;
using Domain.Booking.Entities;
using Domain.Booking.Ports;
using Domain.Guest.Entities;
using Domain.Guest.Ports;
using Domain.Room.Entities;
using Domain.Room.Ports;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTests
{
    [TestFixture]
    internal class CreatingBookingCommandHandlerTests
    {
        private CreateBookingHandler GetCommandMock(Mock<IRoomRepository> roomRepository = null, Mock<IGuestRepository> guestRepository = null,
            Mock<IBookingRepository> bookingRepository = null)
        {
            var _bookingRepository = bookingRepository ?? new Mock<IBookingRepository>();
            var _roomRepository = roomRepository ?? new Mock<IRoomRepository>();
            var _guestRepository = guestRepository ?? new Mock<IGuestRepository>();

            return new CreateBookingHandler(_bookingRepository.Object, _guestRepository.Object, _roomRepository.Object);
        }

        [Test]
        public async Task ShouldNotCreateBookingIfRoomIsMissing()
        {
            var command = new CreateBookingCommand()
            {
                BookingDTO = new Application.Booking.DTOs.BookingDTO()
                {
                    GuestId = 1,
                    Start = DateTime.Now,
                    End = DateTime.Now.AddDays(2),
                }
            };

            var fakeGuest = new Guest
            {
                Id = command.BookingDTO.GuestId,
                Document = new Domain.Guest.ValueObjects.PersonId
                {
                    DocumentType = Domain.Guest.Enums.DocumentType.Passport,
                    Idnumber = "abc123"
                },
                Email = "a@a.com",
                Name = "Fake Guest",
                SurName = " Fake Surname"
            };

            var guestRepository = new Mock<IGuestRepository>();
            guestRepository.Setup(x => x.Get(command.BookingDTO.GuestId))
                .Returns(Task.FromResult(fakeGuest));

            var fakeRoom = new Room
            {
                Id = command.BookingDTO.RoomId,
                IsMaintenance = false, 
                Price = new Domain.Room.ValueObjects.Price
                {
                    Currency = Domain.Room.Enums.AcceptedCurrencies.Dolar,
                    Value = 100
                },
                Name = "fakeGuest room",
                Level = 1
            };

            var roomRepository = new Mock<IRoomRepository>();
            roomRepository.Setup(x=> x.Get(1))
                .Returns(Task.FromResult(fakeRoom));

            var fakeBooking = new Booking
            {
                Id = 1
            };

            var bookingRepoMock = new Mock<IBookingRepository>();
            bookingRepoMock.Setup(x=>x.CreateBookingAsync(It.IsAny<Booking>()))
                .Returns(Task.FromResult(fakeBooking));

            var handler = GetCommandMock(null, guestRepository, bookingRepoMock);

            var resp = await handler.Handle(command, CancellationToken.None);

            Assert.NotNull(resp);
            Assert.True(resp.Success);
            Assert.Null(resp.Errors);


        }


    }
}

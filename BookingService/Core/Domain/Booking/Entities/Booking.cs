using Domain.Guest.Enums;
using Entities = Domain.Guest.Entities;
using Action = Domain.Guest.Enums.Action;
using Domain.Booking.Ports;
using System.ComponentModel.DataAnnotations;
using Domain.Booking.Exceptions;

namespace Domain.Booking.Entities
{
    public class Booking
    {
        public Booking()
        {
            Status = Status.Created;
        }

        public int Id { get; set; }

        [Required(ErrorMessage ="Data da locação é obrigatória")]
        public DateTime? PlacedAt { get; set; }

        [Required(ErrorMessage = "Data de início da locação é obrigatória")]
        public DateTime Start { get; set; }

        [Required(ErrorMessage = "Data de fim da locação é obrigatória")]
        public DateTime End { get; set; }
        private Status Status { get; set; }
        public Status CurrentStatus { get { return Status; } }

        [Required(ErrorMessage = "Número do quarto da locação é obrigatória")]
        public Room.Entities.Room Room { get; set; }

        [Required(ErrorMessage = "Número do hósopede da locação é obrigatória")]
        public Guest.Entities.Guest Guest { get; set; }
        public void ChangeState(Action action)
        {
            Status = (Status, action) switch
            {
                (Status.Created, Action.Pay) => Status.Paid,
                (Status.Created, Action.Cancel) => Status.Canceled,
                (Status.Paid, Action.Finish) => Status.Finished,
                (Status.Paid, Action.Refound) => Status.Refounded,
                (Status.Canceled, Action.Reopen) => Status.Created,
                _ => Status
            };
        }

        public void ValidateState()
        {           
            if (this.PlacedAt == default(DateTime))
            {
                throw new PlacedAtRequiredInformationException();
            }
            if (this.Start == default(DateTime))
            {
                throw new StartRequiredInformationException();
            }
            if (this.End == default(DateTime))
            {
                throw new EndRequiredInformationException();
            }
        }

        public async Task Save(IBookingRepository bookingRepository)
        {
            ValidateState();
            if(Id == 0)
            {
                var resp = await bookingRepository.CreateBookingAsync(this);
                this.Id = resp.Id;
            }
            else
            {

            }
        }
    }
}

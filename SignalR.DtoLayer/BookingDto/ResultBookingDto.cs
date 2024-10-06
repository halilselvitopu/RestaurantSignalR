using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.BookingDto
{
    public class ResultBookingDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EMail { get; set; }
        public int NumberOfGuests { get; set; }
        public DateTime Date { get; set; }
    }
}

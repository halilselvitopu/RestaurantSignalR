namespace SignalRWebUI.Dtos.BookingDtos
{
    public class CreateBookingDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EMail { get; set; }
        public int NumberOfGuests { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}

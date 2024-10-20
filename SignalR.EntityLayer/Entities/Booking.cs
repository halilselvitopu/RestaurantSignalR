namespace SignalR.EntityLayer.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EMail { get; set; }
        public int NumberOfGuests { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}

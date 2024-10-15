﻿namespace SignalRWebUI.Dtos.ContactDtos
{
    public class CreateContactDto
    {
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public string EMail { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string OpenDays { get; set; }
        public string OpenDaysDescription { get; set; }
        public string OpenHours { get; set; }
    }
}

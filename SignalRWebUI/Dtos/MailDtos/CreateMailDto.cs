namespace SignalRWebUI.Dtos.MailDtos
{
	public class CreateMailDto
	{
        public string Receiver { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}

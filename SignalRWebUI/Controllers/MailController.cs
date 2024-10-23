using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRWebUI.Dtos.MailDtos;
﻿using MailKit.Net.Smtp;

namespace SignalRWebUI.Controllers
{
	public class MailController : Controller
	{

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}


		[HttpPost]
		public IActionResult Index(CreateMailDto createMailDto)
		{
			MimeMessage mimeMessage = new MimeMessage();

			MailboxAddress mailboxAddressFrom = new MailboxAddress("SignalR Rezervasyon", "project.netcore@gmail.com");
			mimeMessage.From.Add(mailboxAddressFrom);

			MailboxAddress mailboxAddressTo = new MailboxAddress("User", createMailDto.Receiver);
			mimeMessage.To.Add(mailboxAddressTo);

			var bodyBuilder = new BodyBuilder();
			bodyBuilder.TextBody = createMailDto.Body;
			mimeMessage.Body = bodyBuilder.ToMessageBody();
			mimeMessage.Subject = createMailDto.Subject;

			SmtpClient client = new SmtpClient();
			client.Connect("smtp.gmail.com",587,false);
			client.Authenticate("project.netcore@gmail.com", "gmhy cfev msvj ptpf");

			client.Send(mimeMessage);
			client.Disconnect(true);

			return RedirectToAction("Index","Dashboard");
		}
	}
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.IdentityDtos;

namespace SignalRWebUI.Controllers
{
	public class SettingController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public SettingController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}


		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			UpdateUserDto updateUserDto = new UpdateUserDto();
			updateUserDto.FirstName = values.FirstName;
			updateUserDto.LastName = values.LastName;
			updateUserDto.Email = values.Email;
			updateUserDto.Username = values.UserName;
			return View(updateUserDto);
		}

		[HttpPost]
		public async Task<IActionResult> Index(UpdateUserDto updateUserDto)
		{
			if (updateUserDto.Password == updateUserDto.ConfirmPassword)
			{
				var user = await _userManager.FindByNameAsync(User.Identity.Name);
				user.FirstName = updateUserDto.FirstName;
				user.LastName = updateUserDto.LastName;
				user.Email = updateUserDto.Email;
				user.UserName = updateUserDto.Username;
				user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, updateUserDto.Password);
			    await _userManager.UpdateAsync(user);
				return RedirectToAction("Index","Category");
			}
			return View();
		}
	}
}

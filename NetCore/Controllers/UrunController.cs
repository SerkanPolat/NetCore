using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore.CustomExtension;
using NetCore.Entities;
using NetCore.Interfaces;

namespace NetCore.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UrunController : ControllerBase
	{
		private readonly IUrunRepository _urunRepository;
		public UrunController(IUrunRepository urunRepository)
		{
			_urunRepository = urunRepository;
		}
		[HttpGet]
		public IActionResult Index()
		{
			AppUser app = new AppUser();
			HttpContext.Session.SetObject("deneme", app);

			var s = HttpContext.Session.GetObject<AppUser>("deneme");
			return Ok(_urunRepository.getAll());
		}
	}
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
			
			return Ok(_urunRepository.getAll());
		}
	}
}

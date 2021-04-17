using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore.Interfaces;
using NetCore.Repositories;
using NetCore.Repositories.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UrunController : ControllerBase
	{
		IUrunRepository _urunRepository;
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

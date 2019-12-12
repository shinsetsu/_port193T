
//using  Excel = Microsoft.Office.Interop.Excel;
//using Word = Microsoft.Office.Interop.Word;



using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace _port19.Controllers
{
	public class HomeController : Controller
	{




		//Interfaces -     


		//Constructor
		public HomeController() { }



		//[Route("DropAllTables")]

		//public IActionResult DropAllTables() {


		//	try {
		//		_context.Database.ExecuteSqlCommand("");// Truncate will reset the primary index.
		//								    //Supposedly Roll-back-able? Verify? 

		//		return Content("Success deleting all data from StockIems");
		//		} catch (Exception) {
		//		return Content("Error deleting data from StockItems");

		//		}

		//	return View("z___Index_____________________.cshtml");
		//	}
		//}




		[Route("")] [Route("mDev")] public IActionResult mDev() { return View("z_____mDev.cshtml"); }
		





	}
}




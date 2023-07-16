using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using NuGet.Protocol;
using WebAppCoreWithAzureDB.Model;

namespace WebAppCoreWithAzureDB.Controllers
{
	public class HomeController : Controller
	{
		private IConfiguration _configuration;
        public HomeController(IConfiguration configuration )
        {
			_configuration = configuration;
        }
		
        public IActionResult Index()
		{
			return View();
		}

		public IActionResult Details()
		{
			IEnumerable<Employee> employees;
			using (var connection = new SqlConnection(_configuration.GetConnectionString("SQLConnection")))
			{
				employees = connection.Query<Employee>("SELECT *  FROM Employee");
			}
			return View(employees);
		}

	}
}

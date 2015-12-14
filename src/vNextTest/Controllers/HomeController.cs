using System;
using Microsoft.AspNet.Mvc;
using System.Data.SqlClient;

namespace vNextTest.Controllers
{
    public class HomeController : Controller
    {
        private bool SqlTest()
        {
            try
            {
                string connectionString = "Data Source = my - data - source; Initial Catalog = mydataBase; MultipleActiveResultSets = False; User Id = myUserName; Password = myPassword; ";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    return conn.State == System.Data.ConnectionState.Open;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = string.Format("The following statement \"sql works here\" is {0}.", SqlTest());

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

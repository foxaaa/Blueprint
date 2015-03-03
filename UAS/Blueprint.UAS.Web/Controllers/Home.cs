using Blueprint.UAS.BLL;
using Blueprint.UAS.Entity;
using Blueprint.UAS.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blueprint.UAS.Web.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
            //IOrgService s = new OrgService();
            //s.test();
			return View();
		}
	}
}
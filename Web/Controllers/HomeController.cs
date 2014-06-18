﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private Dictionary<string, string> stateList = new Dictionary<string, string>()
			{
				{"", "--Select--"},
				{"AL","Alabama"},
				{"AK","Alaska"},
				{"AZ","Arizona"},
				{"AR","Arkansas"},
				{"CA","California"},
				{"CO","Colorado"},
				{"CT","Connecticut"},
				{"DE","Delaware"},
				{"FL","Florida"},
				{"GA","Georgia"},
				{"HI","Hawaii"},
				{"ID","Idaho"},
				{"IL","Illinois"},
				{"IN","Indiana"},
				{"IA","Iowa"},
				{"KS","Kansas"},
				{"KY","Kentucky"},
				{"LA","Louisiana"},
				{"ME","Maine"},
				{"MD","Maryland"},
				{"MA","Massachusetts"},
				{"MI","Michigan"},
				{"MN","Minnesota"},
				{"MS","Mississippi"},
				{"MO","Missouri"},
				{"MT","Montana"},
				{"NE","Nebraska"},
				{"NV","Nevada"},
				{"NH","New Hampshire"},
				{"NJ","New Jersey"},
				{"NM","New Mexico"},
				{"NY","New York"},
				{"NC","North Carolina"},
				{"ND","North Dakota"},
				{"OH","Ohio"},
				{"OK","Oklahoma"},
				{"OR","Oregon"},
				{"PA","Pennsylvania"},
				{"RI","Rhode Island"},
				{"SC","South Carolina"},
				{"SD","South Dakota"},
				{"TN","Tennessee"},
				{"TX","Texas"},
				{"UT","Utah"},
				{"VT","Vermont"},
				{"VA","Virginia"},
				{"WA","Washington"},
				{"WV","West Virginia"},
				{"WI","Wisconsin"},
				{"WY","Wyoming"},
				{"DC","District of Columbia"}
			};

        [HttpGet]
        public ActionResult Index()
        {

            ViewBag.States = stateList;
            return View();
        }

        [HttpPost]
        public ActionResult Index(Person model)
        {

            return View("Results", model);
        }

        [HttpGet]
        public ActionResult Results(Person model)
        {

            return View("Results", model);
        }
    }
}
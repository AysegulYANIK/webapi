﻿using BirthdayApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BirthdayApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DavetiyeFormu()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DavetiyeFormu(Davetiye model)
        {
            if (ModelState.IsValid)
            {
                Veritabanı.Add(model);
                return View("Thanks",model);
            }

            return View(model);
        }

        public ActionResult Katilanlar()
        {
            var katilanlari = Veritabanı.Liste.Where(i => i.KatilmaDurumu == true);
            return PartialView(katilanlari); 
        }

    }
}
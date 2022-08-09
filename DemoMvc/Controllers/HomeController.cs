﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoMvc.Models;
using Database1;
using System.Data.Entity.Infrastructure;

namespace DemoMvc.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Users (int id)
        {
            Garments garment = new Garments();
           Users user = garment.users.Single(usr => usr.UID == id);

            return View(user);
        }

        public ActionResult Index( string DepName)
        {
            Garments garment = new Garments();
           List< Users> userc = garment.users.Where(use => use.Department == DepName).ToList();

            return View(userc);
        }
        public ActionResult Dep()
        {
            Garments garment = new Garments();
            List<Departments> departments = garment.departments.ToList();

            return View(departments);
        }
        public ActionResult Admin()
        {

            LogicDb Admin = new LogicDb();

           List<Db> Dbb = Admin.db.ToList();


            return View(Dbb);
        }
        [HttpGet]
        public ActionResult AdminAdd()
        {
            return View();
        }

        [HttpPost]
        [ActionName("AdminAdd")]
        public ActionResult AdminAddD()
        {
            if(ModelState.IsValid)
            {
                Db AdminDb = new Db();
                UpdateModel(AdminDb);
                LogicDb DbBasee = new LogicDb();
                DbBasee.AdminInsert(AdminDb);

                return RedirectToAction("Admin");
            }

            return View();
        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Day3_MVC_ITI.Models;

namespace Day3_MVC_ITI.Controllers
{
    
    public class EmpsController : Controller
    {
        EMPLOYEESEntities Context = new EMPLOYEESEntities();
        // GET: Emps
        public ActionResult Index()
        {
            List<Emp> Emps = Context.Emps.ToList();

            return View(Emps);
        }

        // GET: Emps/Details/5
        public ActionResult Details(int id)
        {
            Emp E = Context.Emps.Find(id);
            return View(E);
        }

        // GET: Emps/Create
        public ActionResult Create()
        { 
            return View();
        }

        // POST: Emps/Create
        [HttpPost]
        public ActionResult Create(Emp emp)
        {
            try
            {
                Context.Emps.Add(emp);
                Context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Emps/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Emps/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Emp emp)
        {
            try
            {
                Emp E = Context.Emps.Find(id);
                E.EmpFname = emp.EmpFname;
                E.EmpLname = emp.EmpLname;
                E.CtyID = emp.CtyID;
                E.dID = emp.dID;
                E.EmpHDate = emp.EmpHDate;
                E.EmpSalary = emp.EmpSalary;

                Context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Emps/Delete/5
        public ActionResult Delete(int id)
        {
           
            return View((Emp)Context.Emps.Find(id));
        }

        // POST: Emps/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Context.Emps.Remove(Context.Emps.Where(E => E.EmpID == id).FirstOrDefault());
                Context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

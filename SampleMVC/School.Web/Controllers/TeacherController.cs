using School.Data;
using School.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.Web.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            var repo = new TeacherRepository();
            var teacherList = repo.GetTeachers();
            return View(teacherList);
        }
       
        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Teacher/Create
        public ActionResult Create()
        {
            var repo = new TeacherRepository();
            var customer = repo.CreateTeacher();
            return View(customer);
        }

        // POST: Teacher/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "TeacherId, TeacherName")] TeacherEditViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var repo = new TeacherRepository();
                    bool saved = repo.SaveTeacher(model);
                    if (saved)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Teacher/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Teacher/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Teacher/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Teacher/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }

}
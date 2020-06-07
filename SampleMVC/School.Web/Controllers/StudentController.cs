using School.Data;
using School.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace School.Web.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index(string teacherID)
        {
            if (!String.IsNullOrWhiteSpace(teacherID))
            {
                if (Guid.TryParse(teacherID, out Guid teacherId))
                {
                    var repo = new StudentRepository();
                    var model = repo.GetTeacherStudentDisplay(teacherId);
                    return View(model);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(TeacherStudentListViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Students != null)
                {
                    var repo = new StudentRepository();
                    repo.SaveStudents(model.Students);
                }
                return View(model);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}
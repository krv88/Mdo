using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MdoDb.Organization;
using MdoDb.Organization.Model;
using MdoTestKrv.Models.Empl;

namespace MdoTestKrv.Controllers
{
    public class EmplController : Controller
    {
        private OrgContext db;

        public EmplController()
        {
            db = new OrgContext();
        }

        public ActionResult Index(EmplFilter filter = new EmplFilter())
        {
            var result = new EmplSearch()
            {
                Filter = filter,
                Empls = GetEmpls(filter)
            };

            ViewBag.Title = "Index";
            return View(result);
        }

        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Title = "Создание";
            return View("EmplDetails");
        }

        [HttpPost]
        public ActionResult Create(EmplDetails details)
        {
            try
            {
                db.Employees.Add(details.ToEmployee());
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("EmplDetails");
            }
        }
        #endregion

        #region Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var empl = db.Employees.Find(id);
            if (empl == null)
            {
                return HttpNotFound();
            }

            ViewBag.Title = "Редактирование";
            return View("EmplDetails", new EmplDetails(empl));
        }

        [HttpPost]
        public ActionResult Edit(EmplDetails details)
        {
            try
            {
                db.Entry(details.ToEmployee()).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("EmplDetails", details);
            }
        }
        #endregion

        #region Delete
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var empl = db.Employees.Find(id);
            if (empl == null)
            {
                return HttpNotFound();
            }
            ViewBag.Title = "Удаление";
            return View("EmplDelete", new EmplDetails(empl));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(EmplDetails details)
        {
            try
            {
                var empl = db.Employees.Find(details.Id);
                db.Entry(empl).State = EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("EmplDelete");
            }
        }
        #endregion

        private IEnumerable<EmplItem> GetEmpls(EmplFilter filter)
        {
            IQueryable<Employee> query = db.Employees;

            if (!string.IsNullOrWhiteSpace(filter.Name))
                query = query.Where(e => e.FirstName.Contains(filter.Name)
                    || e.LastName.Contains(filter.Name)
                    || e.MiddleName.Contains(filter.Name));

            if (!string.IsNullOrWhiteSpace(filter.Title))
                query = query.Where(e => e.Title.Contains(filter.Title));

            var result = query.AsEnumerable()
                .Select(empl => new EmplItem()
                {
                    Id = empl.Id,
                    Name = $"{empl.LastName} {empl.FirstName} {empl.MiddleName}",
                    BirthYear = empl.BirthYear,
                    Title = empl.Title
                })
                .ToList();

            return result;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {                
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

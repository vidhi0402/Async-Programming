using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AsyncProgramming;

namespace AsyncProgramming.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeEntities db = new EmployeeEntities();
       
        public async Task<ActionResult> Index()
        {
            return View(await db.Async_Employee.ToListAsync());
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Async_Employee async_Employee = await db.Async_Employee.FindAsync(id);
            if (async_Employee == null)
            {
                return HttpNotFound();
            }
            return View(async_Employee);
        }

      
        public ActionResult Create()
        {
            return View();
        }
       
        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,EmailId,City,IsActive")] Async_Employee async_Employee)
        {
            if (ModelState.IsValid)
            {
                db.Async_Employee.Add(async_Employee);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(async_Employee);
        }
        
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Async_Employee async_Employee = await db.Async_Employee.FindAsync(id);
            if (async_Employee == null)
            {
                return HttpNotFound();
            }
            return View(async_Employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken ]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,EmailId,City,IsActive")] Async_Employee async_Employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(async_Employee).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(async_Employee);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Async_Employee async_Employee = await db.Async_Employee.FindAsync(id);
            if (async_Employee == null)
            {
                return HttpNotFound();
            }
            return View(async_Employee);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Async_Employee async_Employee = await db.Async_Employee.FindAsync(id);
            db.Async_Employee.Remove(async_Employee);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrudOperation;
using log4net;

namespace CrudOperation.Controllers
{
    public class BasicCrudeController : Controller
    {
        public ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private CRUDEntities db = new CRUDEntities();

        // GET: BasicCrude

        // Fetch All The Data From Tables And Display It Into Index View.............
        public ActionResult Index()
        {
            try
            {
                return View(db.CRUDs.ToList());
            }
            catch
            {
                throw;
            }
        }

        // GET: BasicCrude/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                CRUD cRUD = db.CRUDs.Find(id);
                if (cRUD == null)
                {
                    return HttpNotFound();
                }
                return View(cRUD);
            }
                catch
                {
                    throw;
                }
        }
        // GET: BasicCrude/Create
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch
            {
                throw;
            }
        }

        // POST: BasicCrude/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.


        //For Create New Records Into The Tables
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,EmailId,ContactNumber,Address")] CRUD cRUD)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    logger.Info("BasicCrude Create Methods Start at " + DateTime.UtcNow);
                    db.CRUDs.Add(cRUD);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(cRUD);
            }
            catch
            {

                throw;
            }
        }

        // GET: BasicCrude/Edit/5

        // For Update/Change Existing records Into The tables
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                CRUD cRUD = db.CRUDs.Find(id);
                if (cRUD == null)
                {
                    return HttpNotFound();
                }

                return View(cRUD);
            }

            catch
            {

                throw;
            }
        }

        // POST: BasicCrude/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,EmailId,ContactNumber,Address")] CRUD cRUD)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    logger.Info("BasicCrude Edit Methods Start at " + DateTime.UtcNow);
                    db.Entry(cRUD).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(cRUD);
            }
            catch
            {

                throw;
            }
        }

        // GET: BasicCrude/Delete/5
        //For Delete Particular Records Into The Tables.........
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                CRUD cRUD = db.CRUDs.Find(id);
                if (cRUD == null)
                {
                    return HttpNotFound();
                }
                return View(cRUD);
            }

            catch
            {
                throw;
            }
        }

        // POST: BasicCrude/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                logger.Info("BasicCrude Delete Methods Start at " + DateTime.UtcNow);
                CRUD cRUD = db.CRUDs.Find(id);
                db.CRUDs.Remove(cRUD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                throw;
            }
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    db.Dispose();
                }
                base.Dispose(disposing);
            }
            catch
            {
                throw;
            }
        }
    }
}

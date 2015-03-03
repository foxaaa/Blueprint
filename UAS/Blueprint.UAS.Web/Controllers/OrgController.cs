using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blueprint.UAS.Entity;
using Blueprint.UAS.BLL;

namespace Blueprint.UAS.Web.Controllers
{
    public class OrgController : Controller
    {
        private OrgService orgService = new OrgService();

        public ActionResult Index()
        {
            return View(orgService.LoadEntities(o => !string.IsNullOrEmpty(o.Code)));
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var org = orgService.FindEntity(id);
            if (org == null)
            {
                return HttpNotFound();
            }
            return View(org);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code,Name,Seq")] Org org)
        {
            if (ModelState.IsValid)
            {
                orgService.AddEntity(org);
                return RedirectToAction("Index");
            }

            return View(org);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var org = orgService.FindEntity(id);
            if (org == null)
            {
                return HttpNotFound();
            }
            return View(org);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Code,Name,Seq")] Org org)
        {
            if (ModelState.IsValid)
            {
                orgService.UpdateEntity(org);
                return RedirectToAction("Index");
            }
            return View(org);
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var org = orgService.FindEntity(id);
            if (org == null)
            {
                return HttpNotFound();
            }
            return View(org);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var org = orgService.FindEntity(id);
            orgService.DeleteEntity(org);
            return RedirectToAction("Index");
        }
    }
}

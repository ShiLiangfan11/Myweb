using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Myweb.Models;

namespace Myweb.Controllers
{
    public class RateAllsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RateAlls
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserName();
            var userRatings = db.RateAlls.Where(r => r.UserId == userId).ToList();

            var hasRatings = db.RateAlls.Any();

            if (hasRatings)
            {
                var averageScoreA = db.RateAlls.Average(r => (double?)r.AScore) ?? 0;
                var averageScoreB = db.RateAlls.Average(r => (double?)r.BScore) ?? 0;
                var averageScoreC = db.RateAlls.Average(r => (double?)r.CScore) ?? 0;

                ViewBag.AverageScoreA = averageScoreA;
                ViewBag.AverageScoreB = averageScoreB;
                ViewBag.AverageScoreC = averageScoreC;
            }
            else
            {
                ViewBag.AverageScoreA = 0;
                ViewBag.AverageScoreB = 0;
                ViewBag.AverageScoreC = 0;
            }

            return View(userRatings);
        }

        // GET: RateAlls/Create
        public ActionResult Create()
        {
            var userId = User.Identity.GetUserName();
            var existingRating = db.RateAlls.FirstOrDefault(r => r.UserId == userId);

            if (existingRating != null)
            {
                return RedirectToAction("Edit", new { id = existingRating.Id });
            }

            var rateAll = new RateAll
            {
                UserId = userId // 设置UserId为当前登录用户的邮箱
            };
            return View(rateAll);
        }

        // POST: RateAlls/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,AScore,BScore,CScore,Comment")] RateAll rateAll)
        {
            if (ModelState.IsValid)
            {
                db.RateAlls.Add(rateAll);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rateAll);
        }

        // GET: RateAlls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RateAll rateAll = db.RateAlls.Find(id);
            if (rateAll == null)
            {
                return HttpNotFound();
            }
            if (rateAll.UserId != User.Identity.GetUserName())
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            return View(rateAll);
        }

        // POST: RateAlls/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,AScore,BScore,CScore,Comment")] RateAll rateAll)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rateAll).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rateAll);
        }

        // GET: RateAlls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RateAll rateAll = db.RateAlls.Find(id);
            if (rateAll == null)
            {
                return HttpNotFound();
            }
            if (rateAll.UserId != User.Identity.GetUserName())
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            return View(rateAll);
        }

        // POST: RateAlls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RateAll rateAll = db.RateAlls.Find(id);
            db.RateAlls.Remove(rateAll);
            db.SaveChanges();
            return RedirectToAction("Index");
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

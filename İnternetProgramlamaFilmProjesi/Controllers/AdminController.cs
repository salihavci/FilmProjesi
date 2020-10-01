using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using İnternetProgramlamaFilmProjesi.Models;
using System.Net;
using System.Web.Helpers;
using System.IO;

namespace İnternetProgramlamaFilmProjesi.Controllers
{
    public class AdminController : Controller
    {
        AllTableForDatabase db = new AllTableForDatabase();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        //Films İşlemleri
        public ActionResult Films()
        {
            return View(db.films.ToList());
        }
        public ActionResult FilmsCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FilmsCreate([Bind(Include = "fragman_width,fragman_height,fragman_iframe,fragman_frameborder,film_width,film_height,film_iframe,film_frameborder,acilklama,resim,film_adi")] film filmler, HttpPostedFileBase resim)
        {
            if (ModelState.IsValid)
            {
                if (resim != null)
                {
                    WebImage img = new WebImage(resim.InputStream);
                    FileInfo fotoinfo = new FileInfo(resim.FileName);
                    string newfoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                    img.Save("~/images/" + newfoto);
                    filmler.resim = newfoto;
                }
                db.films.Add(filmler);
                db.SaveChanges();
                return RedirectToAction("Films");
            }

            return View(filmler);
        }
        public ActionResult FilmsEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            film filmler = db.films.Find(id);
            if (filmler == null)
            {
                return HttpNotFound();
            }
            return View(filmler);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FilmsEdit([Bind(Include = "id,fragman_width,fragman_height,fragman_iframe,fragman_frameborder,film_width,film_height,film_iframe,film_frameborder,acilklama,resim,film_adi")] film filmler,HttpPostedFileBase resim)
        {
            if (ModelState.IsValid)
            {
                if (resim != null)
                {
                    WebImage img = new WebImage(resim.InputStream);
                    FileInfo fotoinfo = new FileInfo(resim.FileName);
                    string newfoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                    img.Save("~/images/" + newfoto);
                    filmler.resim = newfoto;
                }
                db.Entry(filmler).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Films");
            }
            return View(filmler);
        }
        public ActionResult FilmsDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            film filmler = db.films.Find(id);
            if (filmler == null)
            {
                return HttpNotFound();
            }
            return View(filmler);
        }
        [HttpPost, ActionName("FilmsDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult FilmsDeleteConfirmed(int id)
        {
            film filmler = db.films.Find(id);
            db.films.Remove(filmler);
            db.SaveChanges();
            return RedirectToAction("Films");
        }
        public ActionResult FilmDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            film filmler = db.films.Find(id);
            if (filmler == null)
            {
                return HttpNotFound();
            }
            return View(filmler);
        }

        //Members İşlemleri
        public ActionResult Members()
        {
            return View(db.members.ToList());
        }
        public ActionResult MembersCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MembersCreate([Bind(Include = "ad,soyad,email,kullanici,parola")] member uyeler)
        {
            if (ModelState.IsValid)
            {
                db.members.Add(uyeler);
                db.SaveChanges();
                return RedirectToAction("Members");
            }

            return View(uyeler);
        }
        public ActionResult MembersEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            member uyeler = db.members.Find(id);
            if (uyeler == null)
            {
                return HttpNotFound();
            }
            return View(uyeler);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MembersEdit([Bind(Include = "id,ad,soyad,email,kullanici,parola")] member uyeler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uyeler).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Members");
            }
            return View(uyeler);
        }
        public ActionResult MembersDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            member uyeler = db.members.Find(id);
            if (uyeler == null)
            {
                return HttpNotFound();
            }
            return View(uyeler);
        }
        [HttpPost, ActionName("MembersDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult MembersDeleteConfirmed(int id)
        {
            member uyeler = db.members.Find(id);
            db.members.Remove(uyeler);
            db.SaveChanges();
            return RedirectToAction("Members");
        }
        public ActionResult MemberDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            member uyeler = db.members.Find(id);
            if (uyeler == null)
            {
                return HttpNotFound();
            }
            return View(uyeler);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        //Posts İşlemleri
        public ActionResult Posts()
        {
            return View(db.posts.ToList());
        }
        public ActionResult PostsCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostsCreate([Bind(Include = "kullanici,tarih,yorum,onay")] post yorumlar)
        {
            if (ModelState.IsValid)
            {
                db.posts.Add(yorumlar);
                db.SaveChanges();
                return RedirectToAction("Posts");
            }

            return View(yorumlar);
        }
        public ActionResult PostsEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            post yorumlar = db.posts.Find(id);
            if (yorumlar == null)
            {
                return HttpNotFound();
            }
            return View(yorumlar);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostsEdit([Bind(Include = "id,kullanici,tarih,yorum,onay")] post yorumlar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yorumlar).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Posts");
            }
            return View(yorumlar);
        }
        public ActionResult PostsDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            post yorumlar = db.posts.Find(id);
            if (yorumlar == null)
            {
                return HttpNotFound();
            }
            return View(yorumlar);
        }
        [HttpPost, ActionName("PostsDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult PostsDeleteConfirmed(int id)
        {
            post yorumlar = db.posts.Find(id);
            db.posts.Remove(yorumlar);
            db.SaveChanges();
            return RedirectToAction("Posts");
        }
        public ActionResult PostDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            post yorumlar = db.posts.Find(id);
            if (yorumlar == null)
            {
                return HttpNotFound();
            }
            return View(yorumlar);
        }
    }
}
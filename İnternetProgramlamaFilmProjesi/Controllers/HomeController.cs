using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using İnternetProgramlamaFilmProjesi.Models;
using System.Net;

namespace İnternetProgramlamaFilmProjesi.Controllers
{
    public class HomeController : Controller
    {
        AllTableForDatabase db = new AllTableForDatabase();
        // GET: Home
        public ActionResult Index()
        {
            if (Session["oturum"] != null)
                return View();
            else
                return RedirectToAction("Login");
        }
        public ActionResult About()
        {
            if (Session["oturum"] != null)
                return View();
            else
                return RedirectToAction("Login");
        }
        public ActionResult Films()
        {
            if (Session["oturum"] != null)
                return View(db.films.ToList());
            else
                return RedirectToAction("Login");
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
        public ActionResult FilmFragmans(int? id)
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
        public ActionResult FilmViews(int? id)
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
        public ActionResult Posting()
        {
            if (Session["oturum"] != null)
                return View();
            else
                return RedirectToAction("Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Posting([Bind(Include = "kullanici,tarih,yorum,onay")] post yorumlar)
        {
            if (ModelState.IsValid)
            {
                yorumlar.onay = 0;
                db.posts.Add(yorumlar);
                db.SaveChanges();
                return RedirectToAction("PostRead");

            }

            return View(yorumlar);
        }
        public ActionResult PostRead()
        {
            return View(db.posts.ToList());
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(member uyeler)
        {
            using (AllTableForDatabase db = new AllTableForDatabase())
            {
                var usr = db.members.Where(u => u.kullanici == uyeler.kullanici && u.parola == uyeler.parola).FirstOrDefault();
                if (usr != null)
                {
                    Session["oturum"] = usr.id.ToString();
                    Session["kullanici"] = usr.kullanici.ToString();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("","Kullanıcı adı ya da parola yanlış.");
                }
            }
                return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "ad,soyad,email,kullanici,parola")] member uyeler)
        {
            if (ModelState.IsValid)
            {
                db.members.Add(uyeler);
                db.SaveChanges();
                return RedirectToAction("Index");
                
            }

            return View(uyeler);
        }
        public ActionResult Logout()
        {
            Session["oturum"] = null;
            Session["kullanici"] = null;
            return RedirectToAction("Login");
        }
    }
}
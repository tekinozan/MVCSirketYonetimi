using MVCSirketYonetimi.Business.Repository.GenericRepositoryManager;
using MVCSirketYonetimi.Data.Models.Context;
using MVCSirketYonetimi.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSirketYonetimi.Controllers
{
    public class DepartmanController : Controller
    {
        GenericRepository<Departman> repo = new GenericRepository<Departman>();
        SirketDbContext db = new SirketDbContext();
        // GET: Departman
        public ActionResult Index()
        {
            var departmanlar = repo.HepsiniGetir();
            return View(departmanlar);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View("Ekle");
        }

        [HttpPost]

        public ActionResult Ekle(Departman departman)
        {
            repo.Ekle(departman);
            return RedirectToAction("Index", "Departman");
        }

        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            var departman = db.Departmanlar.Find(id);
            if (departman == null)
            {
                return HttpNotFound();
            }
            return View("Guncelle", departman);
        }

        [HttpPost]
        public ActionResult Guncelle(Departman departman)
        {
            repo.Guncelle(departman);
            return RedirectToAction("Index", "Departman");
        }

        [HttpGet]
        public ActionResult Sil(int id)
        {
            var departman = db.Departmanlar.Find(id);
            if (departman == null)
            {
                return HttpNotFound();
            }

            repo.Sil(id);
            return RedirectToAction("Index", "Departman");
        }

    }
}
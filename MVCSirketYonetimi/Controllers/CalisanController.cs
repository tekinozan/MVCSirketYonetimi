using MVCSirketYonetimi.Business.Managers;
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
    public class CalisanController : Controller
    {
        GenericRepository<Calisan> repo = new GenericRepository<Calisan>();
        SirketDbContext db = new SirketDbContext();



        // GET: Calisan
        [HttpGet]
        public ActionResult Index()
        {
            var calisanlar = repo.HepsiniGetir();
            return View(calisanlar);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View("Ekle");
        }

        [HttpPost]

        public ActionResult Ekle(Calisan calisan)
        {
            repo.Ekle(calisan);
            return RedirectToAction("Index", "Calisan"); 
        }

        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            var calisan = db.Calisanlar.Find(id);
            if (calisan == null)
            {
                return HttpNotFound();
            }
            return View("Guncelle", calisan);
        }

        [HttpPost]
        public ActionResult Guncelle(Calisan calisan)
        {
            repo.Guncelle(calisan);
            return RedirectToAction("Index", "Calisan");
        }

        [HttpGet]
        public ActionResult Sil(int id)
        {
            var calisan = db.Calisanlar.Find(id);
            if (calisan == null)
            {
                return HttpNotFound();
            }

            repo.Sil(id);
            return RedirectToAction("Index", "Calisan");
        }






    }
}
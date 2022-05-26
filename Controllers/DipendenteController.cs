using AgenziaConsulenzaAMM.Core.BusinessLayer;
using AgenziaConsulenzaAMM.Core.Models;
using AgenziaConsulenzaAMM.MVC.Helpers;
using AgenziaConsulenzaAMM.MVC.Models;
using AgenziaConsulenzaAMM.MVC.Models.Dipendente;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace AgenziaConsulenzaAMM.MVC.Controllers
{
    
    public class DipendenteController : Controller
    {
        private IBusinessLayer layer;

        public DipendenteController(IBusinessLayer layer)
        {
            this.layer = layer;
        }
        
        //[ValidateAntiForgeryToken]
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Index()
        {
            var dipendenti = layer.FetchAllDipendenti();
            var models = dipendenti.ToListViewModel();
            return View(models);
        }

        //get/create
        [HttpGet]
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Create()
        {

            

            ViewBag.Mansioni = MappingExtension.EnumToSelectList<MansioneEnum>();

            return View();
        }

        [HttpPost]
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Create(Dipendente dip)
        {
            try
            {
                if (dip == null)
                    return View("Error");

                bool result = layer.AddNewDipendente(dip.ToDipendente());

                if (!result)
                    return View("Error");

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        //get /edit 
        [HttpGet]
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Edit(string id)
        {

            if (id == null)
                return View("Error");

            var list = layer.FetchAllDipendenti();
            var model=list.Single(x=> x.Id == id);

            

            ViewBag.mansioni = MappingExtension.EnumToSelectList<MansioneEnum>();
            

            return View(model.ToDipendenteViewModel());
        }

        [HttpPost]
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Edit(Dipendente itemToEdit)
        {
            if (itemToEdit == null)
            {
                return View("Error", new ErrorViewModel());
            }
            var success = layer.UpdateDipendente(itemToEdit.ToDipendente());
            if (success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //get/delete
        [HttpGet]
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Delete(string id)
        {
            //if (deleteDipendente == null)
            //    return View("Error");
            
            //layer.DeleteDipendente(deleteDipendente);
            var li=layer.FetchAllDipendenti();
            var model=li.FirstOrDefault(x=>x.Id==id);

            return View(model);
        }
        [HttpPost]
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Delete(Dipendente itemToDelete)
        {
            if (itemToDelete == null)
            {
                return View("Error", new ErrorViewModel());
            }
            var success = layer.DeleteDipendente(itemToDelete);
            if (success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //[HttpGet]
        //[Authorize(Policy = "AdminPolicy")]
        //public IActionResult RecapAttività()
        //{

          


        //    return View();
        //}

        //[HttpPost]
        //[Authorize(Policy = "AdminPolicy")]
        //public IActionResult RecapAttività(Attivita a,Dipendente d)
        //{
        //    return View();
            
                
               
            
        //}
    }
}

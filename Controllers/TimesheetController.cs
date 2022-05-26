using AgenziaConsulenzaAMM.Core.BusinessLayer;
using AgenziaConsulenzaAMM.Core.Models;
using AgenziaConsulenzaAMM.MVC.Helpers;
using AgenziaConsulenzaAMM.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace AgenziaConsulenzaAMM.MVC.Controllers
{

   
    public class TimesheetController : Controller
    {
        private IBusinessLayer layer;

        public TimesheetController(IBusinessLayer layer)
        {
            this.layer = layer;
        }

        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Index()
        {
            var timesheets = layer.FetchAllTimesheet();
            var models = timesheets.ToListViewModel();
            return View(models);
        }

        [HttpGet]
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Create()
        {
            ViewBag.Attivities = layer.FetchAllAttivities()

               .Select(c => new SelectListItem

               {

                   Text = c.Nome,

                   Value = c.Id

               }).ToList();

            ViewBag.Dipendenti = layer.FetchAllDipendenti()

         .Select(c => new SelectListItem

         {

             Text = c.Nome,

             Value = c.Id

         }).ToList();

            return View();
        }

        [HttpPost]
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Create(Timesheet ts)
        {
            try
            {
                if (ts == null)
                    return View("Error");

                bool result = layer.AddNewTimesheet(ts.ToTimesheet());

                if (!result)
                    return View("Error");

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Edit(string id)
        {

            if(id==null)
                    return View("Error");

            var ts = layer.FetchAllTimesheet();

            var model=ts.Single(t=>t.Id==id);

            ViewBag.Attivities = layer.FetchAllAttivities()

               .Select(c => new SelectListItem

               {
                   Text = c.Nome,

                   Value = c.Id

               }).ToList();


            ViewBag.Dipendenti = layer.FetchAllDipendenti()

               .Select(c => new SelectListItem

               {
                   Text = c.Nome,

                   Value = c.Id

               }).ToList();

            return View(model.ToListViewModel());

            
        }

        [HttpPost]
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Edit(Timesheet itemToEdit)
        {
            if (itemToEdit == null)
            {
                return View("Error", new ErrorViewModel());
            }
            var success = layer.UpdateTimesheet(itemToEdit.ToTimesheet());
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
            var li = layer.FetchAllTimesheet();
            var model = li.FirstOrDefault(x => x.Id == id);

            return View(model);
        }
        [HttpPost]
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Delete(Timesheet itemToDelete)
        {
            if (itemToDelete == null)
            {
                return View("Error", new ErrorViewModel());
            }
            var success = layer.DeleteTimesheet(itemToDelete);
            if (success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}


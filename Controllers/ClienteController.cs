using AgenziaConsulenzaAMM.Core.BusinessLayer;
using AgenziaConsulenzaAMM.Core.Models;
using AgenziaConsulenzaAMM.MVC.Helpers;
using AgenziaConsulenzaAMM.MVC.Models;
using AgenziaConsulenzaAMM.MVC.Models.Cliente;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using static AgenziaConsulenzaAMM.Core.Models.Cliente;

namespace AgenziaConsulenzaAMM.MVC.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ClienteController : Controller
    {
        private readonly IBusinessLayer bl;

        public ClienteController(IBusinessLayer bl)
        {
            this.bl = bl;
        }

        //[ValidateAntiForgeryToken]
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Index()
        {
            var clienti = bl.FetchAllClienti();
            var models = clienti.ToListViewModel();
            return View(models);
      
        }




        //GET/Create
       [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Dimensioni = MappingExtension.EnumToSelectList<DimensioneEnum>();
            return View();
        }

        //POST/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cliente newcliente)
        {
            try
            {
                if (newcliente == null)
                    return View("Error");

                bool result = bl.CreateCliente(newcliente);

                if (!result)
                    return View("Error");

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }




        //GET/edit 
        [HttpGet]
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Edit(int ID)
        {
           
            //var clienti = bl.FetchAllClienti();
           
            //var model = clienti.FirstOrDefault(x => x.ID == ID);

            ViewBag.Dimensioni = MappingExtension.EnumToSelectList<DimensioneEnum>();

            return View();
        }
        //POST/edit
        [HttpPost]
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Edit(Cliente itemToEdit)
        {
            if (itemToEdit == null)
            {
                return View("Error", new ErrorViewModel());
            }
            var success = bl.UpdateCliente(itemToEdit.ToEditViewModel());
            if (success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }




        //GET7delete
        [HttpGet]
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Delete(int id)
        {
           var li = bl.FetchAllClienti();
            var model = li.FirstOrDefault(x => x.ID == id);



            return View(model);
        }
        //POST/delete
        [HttpPost]
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Delete(Cliente itemToDelete)
        {
            if (itemToDelete == null)
            {
                return View("Error", new ErrorViewModel());
            }
            var success = bl.DeleteCliente(itemToDelete);
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

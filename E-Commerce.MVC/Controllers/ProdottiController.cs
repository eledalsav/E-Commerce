using E_Commerce.Core;
using E_Commerce.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.MVC.Controllers
{
    public class ProdottiController : Controller
    {
        private readonly IBusinessLayer BL;

        public ProdottiController(IBusinessLayer bl)
        {
            BL = bl;
        }

        //CRUD su Prodotto


        //url: https...../Prodotti
        [HttpGet]
        public IActionResult Index()
        {
            var Prodotti = BL.GetAllProdotti();

            List<ProdottoViewModel> ProdottiViewModel = new List<ProdottoViewModel>();

            foreach (var item in Prodotti)
            {
                ProdottiViewModel.Add(item.ToProdottoViewModel());
            }

            return View(ProdottiViewModel);
        }


        //url: https...../Prodotti/Details/C-01

        [HttpGet("Prodotti/Details/{codice}")]
        //[HttpGet] // [HttpGet ("Prodotti/Details/{id}")]
        public IActionResult Details(string codice)
        {
            var Prodotto = BL.GetAllProdotti().FirstOrDefault(p => p.Codice == codice);

            var ProdottoViewModel = Prodotto.ToProdottoViewModel();

            return View(ProdottoViewModel);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProdottoViewModel ProdottoViewModel)
        {
            if (ModelState.IsValid)
            {
                var Prodotto = ProdottoViewModel.ToProdotto();
                BL.InserisciNuovoProdotto(Prodotto);
                return RedirectToAction(nameof(Index));
            }
            return View(ProdottoViewModel);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var Prodotto = BL.GetAllProdotti().FirstOrDefault(p=>p.Codice == id);
            var ProdottoViewModel = Prodotto.ToProdottoViewModel();
            return View(ProdottoViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ProdottoViewModel ProdottoViewModel)
        {
            if (ModelState.IsValid)
            {
                var Prodotto = ProdottoViewModel.ToProdotto();
                BL.ModificaProdotto(Prodotto.Codice, Prodotto.Tipologia, Prodotto.Descrizione, Prodotto.PrezzoFornitore, Prodotto.PrezzoPubblico);
                return RedirectToAction(nameof(Index));
            }
            return View(ProdottoViewModel);
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var Prodotto = BL.GetAllProdotti().FirstOrDefault(p=>p.Codice == id);
            var ProdottoViewModel = Prodotto.ToProdottoViewModel();
            return View(ProdottoViewModel);
        }

        [HttpPost]
        public IActionResult Delete(ProdottoViewModel ProdottoViewModel)
        {
            if (ModelState.IsValid)
            {

                var Prodotto = ProdottoViewModel.ToProdotto();
                BL.EliminaProdotto(Prodotto.Codice);
                return RedirectToAction(nameof(Index));

            }
            return View(ProdottoViewModel);
        }
    }
}

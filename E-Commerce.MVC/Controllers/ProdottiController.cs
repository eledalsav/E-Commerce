using E_Commerce.Core;
using E_Commerce.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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


        public IActionResult Index()
        {
            var prodotti = BL.GetAllProdotti();

            List<ProdottoViewModel> prodottiViewModel = new List<ProdottoViewModel>();

            foreach (var item in prodotti)
            {
                prodottiViewModel.Add(item.ToProdottoViewModel());
            }
            return View(prodottiViewModel);
        }

        public IActionResult Details(string id)
        {
            var prodotto = BL.GetAllProdotti().FirstOrDefault(p => p.Codice == id);
            var prodottoViewModel = prodotto.ToProdottoViewModel();

            return View(prodottoViewModel);
        }

        //add
        [Authorize(Policy = "Adm")] 
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Policy = "Adm")]
        public IActionResult Create(ProdottoViewModel prodottoViewModel)
        {
            if (ModelState.IsValid)
            {
                BL.InserisciNuovoProdotto(prodottoViewModel.ToProdotto());
                return RedirectToAction(nameof(Index)); 
            }
            LoadViewBag();
            return View(prodottoViewModel); 
        }

        //Edit
        [Authorize(Policy = "Adm")] 
        [HttpGet]
        public IActionResult Edit(string id)
        {
            var prodotto = BL.GetAllProdotti().FirstOrDefault(p => p.Codice == id);
            var prodottoViewModel = prodotto.ToProdottoViewModel();
            return View(prodottoViewModel);
        }

        [HttpPost]
        [Authorize(Policy = "Adm")]
        public IActionResult Edit(ProdottoViewModel prodottoViewModel)
        {
            var prodotto = prodottoViewModel.ToProdotto();

            if (ModelState.IsValid) 
            {
                BL.ModificaProdotto(prodotto.Codice, prodotto.Tipologia, prodotto.Descrizione, prodotto.PrezzoFornitore, prodotto.PrezzoPubblico);
                return RedirectToAction(nameof(Index));
            }
            LoadViewBag();
            return View(prodottoViewModel); 
        }

        //Delete
        [Authorize(Policy = "Adm")]
        public IActionResult Delete(string id)
        {
            var prodotto = BL.GetAllProdotti().FirstOrDefault(p => p.Codice == id);
            var prodottoViewModel = prodotto.ToProdottoViewModel();
            return View(prodottoViewModel);
        }

        [HttpPost]
        [Authorize(Policy = "Adm")] 
        public IActionResult Delete(ProdottoViewModel prodottoViewModel)
        {
            var prodotto = prodottoViewModel.ToProdotto();

            if (ModelState.IsValid)
            {
                BL.EliminaProdotto(prodottoViewModel.Codice);
                return RedirectToAction(nameof(Index));
            }
            return View(prodottoViewModel);
        }


        private void LoadViewBag()
        {
            ViewBag.Tipologia = new SelectList(new[]{
                new { Value="1", Text="Elettronica"},
                new { Value="2", Text="Abbigliamento"},
                new { Value="3", Text="Casalinghi"} }.OrderBy(x => x.Text), "Value", "Text");
        }
    }
}

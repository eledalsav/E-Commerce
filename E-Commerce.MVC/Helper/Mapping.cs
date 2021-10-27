using E_Commerce.Core;
using E_Commerce.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.MVC
{
    public static class Mapping
    {
        public static ProdottoViewModel ToProdottoViewModel(this Prodotto prodotto)
        {

            return new ProdottoViewModel
            {
                Codice = prodotto.Codice,
                Tipologia = prodotto.Tipologia,
                Descrizione = prodotto.Descrizione,
                PrezzoFornitore=prodotto.PrezzoFornitore,
                PrezzoPubblico=prodotto.PrezzoPubblico
            };
        }

        public static Prodotto ToProdotto(this ProdottoViewModel prodottoViewModel)
        {

            return new Prodotto
            {
                Codice = prodottoViewModel.Codice,
                Tipologia = prodottoViewModel.Tipologia,
                Descrizione = prodottoViewModel.Descrizione,
                PrezzoFornitore=prodottoViewModel.PrezzoFornitore,
                PrezzoPubblico=prodottoViewModel.PrezzoPubblico
                
            };
        }
    }
}

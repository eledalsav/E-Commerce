using E_Commerce.Core.Entities;
using E_Commerce.Core.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core
{
    public class MainBusinessLayer : IBusinessLayer
    {
        private readonly IRepositoryProdotto prodottiRepo;
        private readonly IRepositoryUtente utentiRepo;
        public MainBusinessLayer(IRepositoryProdotto prodotti)
        {
            prodottiRepo = prodotti;
        }

        public string EliminaProdotto(string codiceProdottoDaEliminare)
        {
            Prodotto ProdottoEsistente = prodottiRepo.GetByCode(codiceProdottoDaEliminare);
            if (ProdottoEsistente == null)
            {
                return "Errore: Codice errato.";
            }
            prodottiRepo.Delete(ProdottoEsistente);
            return "Prodotto eliminato correttamente";
        }

        public List<Prodotto> GetAllProdotti()
        {
           return prodottiRepo.GetAll();
        }

        public string InserisciNuovoProdotto(Prodotto newProdotto)
        {
            Prodotto prodottoEsistente = prodottiRepo.GetByCode(newProdotto.Codice);
            if (newProdotto != null)
            {
                return "Errore: Codice Prodotto già presente";
            }
            prodottiRepo.Add(newProdotto);
            return "Prodotto aggiunto correttamente";
        }

        public string ModificaProdotto(string codiceProdottoDaModificare, EnumTipologia nuovaTipologia, string nuovaDescrizione, decimal nuovoPrezzoFornitore, decimal nuovoPrezzoPubblico)
        {
            Prodotto ProdottoEsistente = prodottiRepo.GetByCode(codiceProdottoDaModificare);
            if (ProdottoEsistente == null)
            {
                return "Errore: Codice errato.";
            }
            ProdottoEsistente.Tipologia = nuovaTipologia;
            ProdottoEsistente.Descrizione = nuovaDescrizione;
            ProdottoEsistente.PrezzoFornitore = nuovoPrezzoFornitore;
            ProdottoEsistente.PrezzoPubblico = nuovoPrezzoPubblico;
            prodottiRepo.Update(ProdottoEsistente);
            return "Il Prodotto è stato modificato con successo";
        }

        public Utente GetAccount(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return null;
            }
            return utentiRepo.GetByUsername(username);
        }
    }
}

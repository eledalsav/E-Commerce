using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core
{
    public interface IBusinessLayer
    {
        public List<Prodotto> GetAllProdotti();

        //Inserire un nuovo Prodotto
        public string InserisciNuovoProdotto(Prodotto newProdotto);

        //Modifica Prodotto
        public string ModificaProdotto(string codiceProdottoDaModificare, EnumTipologia nuovaTipologia, string nuovaDescrizione, decimal nuovoPrezzoFornitore, decimal nuovoPrezzoPubblico);
        //Elimina Prodotto
        public string EliminaProdotto(string codiceProdottoDaEliminare);

    }
}

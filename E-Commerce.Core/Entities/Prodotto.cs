using System;

namespace E_Commerce.Core
{
//    Codice(string), Descrizione(string),
//Tipologia(del tipo ‘Elettronica’, ‘Abbigliamento’, ‘Casalinghi’), Prezzo al pubblico(decimal),
//Prezzo dal Fornitore(decimal)
    public class Prodotto
    {
        public string Codice { get; set; }
        public string Descrizione { get; set; }
        public EnumTipologia Tipologia { get; set; }
        public decimal PrezzoPubblico { get; set; }
        public decimal PrezzoFornitore { get; set; }
    }
    public enum EnumTipologia
    {
        Elettronica,
        Abbigliamento,
        Casalinghi
    }
}

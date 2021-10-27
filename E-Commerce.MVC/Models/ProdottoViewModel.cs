using E_Commerce.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.MVC.Models
{
    //public string Codice { get; set; }
    //public string Descrizione { get; set; }
    //public EnumTipologia Tipologia { get; set; }
    //public decimal PrezzoPubblico { get; set; }
    //public decimal PrezzoFornitore { get; set; }
    public class ProdottoViewModel
    {
        [Required]
        [DisplayName("Codice Prodotto")]
        public string Codice { get; set; }

        [Required]
        [DisplayName("Descrizione Prodotto")]
        public string Descrizione { get; set; }

        [Required]
        [DisplayName("Tipologia Prodotto")]
        public EnumTipologia Tipologia { get; set; }
        [Required]
        [DisplayName("Prezzo al pubblico")]
        public decimal PrezzoPubblico { get; set; }
        [Required]
        [DisplayName("Prezzo al fornitore")]
        public decimal PrezzoFornitore { get; set; }
    }
}

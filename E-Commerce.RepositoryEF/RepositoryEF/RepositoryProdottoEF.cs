using E_Commerce.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.RepositoryEF
{
    public class RepositoryProdottoEF : IRepositoryProdotto
    {
        public Prodotto Add(Prodotto item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Prodotti.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(Prodotto item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Prodotti.Remove(item);
                ctx.SaveChanges();
            }
            return true; ;
        }

        public List<Prodotto> GetAll()
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Prodotti.ToList();
            }
        }

        public Prodotto GetByCode(string code)
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Prodotti.FirstOrDefault(p=>p.Codice == code);
            }
        }

        public Prodotto Update(Prodotto item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Prodotti.Update(item);
                ctx.SaveChanges();
            }
            return item;
        }
    }
}

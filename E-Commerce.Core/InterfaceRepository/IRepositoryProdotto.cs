using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core
{
    public interface IRepositoryProdotto: IRepository<Prodotto>
    {
        public Prodotto GetByCode(string code);
    }
}

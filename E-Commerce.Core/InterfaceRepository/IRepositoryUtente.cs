using E_Commerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.InterfaceRepository
{
   public interface IRepositoryUtente:IRepository<Utente>
    {
        Utente GetByUsername(string username);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCrm.Data
{
    //Repositoryler arası transaction yönetimi için kullanılır.
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext db;
        public UnitOfWork(ApplicationDbContext context)
        {
            this.db = context;
        }
        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}

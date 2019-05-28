using MyCrm.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCrm.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext db;
        private readonly DbSet<T> entities;
        public Repository(ApplicationDbContext context)
        {
            this.db = context;
            this.entities = context.Set<T>();
        }

        public void Delete(T entity)
        {
            entities.Remove(entity);
        }

        public T Find(Guid id)
        {
            return entities.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.ToList();
        }

        public void Insert(T entitiy)
        {
            entitiy.Id = Guid.NewGuid();
            entities.Add(entitiy);
        }

        public void Update(T entitiy)
        {
            db.Entry(entitiy).State = EntityState.Modified;
        }
    }
}

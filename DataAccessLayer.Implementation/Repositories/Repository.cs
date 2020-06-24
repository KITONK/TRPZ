using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Abstract;

namespace DataAccessLayer.Implementation.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        protected readonly HeadOfOSBBContext appContext;
        protected readonly DbSet<TEntity> entities; // коллекция сущностей взятая из БД с помощью контекста

        public Repository(HeadOfOSBBContext appContext)
        {
            this.appContext = appContext;
            entities = appContext.Set<TEntity>();
        }

        //методы, работаем не с БД, а с контекстом
        public virtual void Create(TEntity entity)
        {
            entities.Add(entity);
        }

        public virtual void Delete(TKey id)
        {
            entities.Remove(appContext.Set<TEntity>().Find(id));
        }

        public virtual TEntity Read(TKey id)
        {
            return entities.Find(id);
        }

        public virtual void Update(TEntity entity)
        {
            entities.Update(entity);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return entities.AsNoTracking().ToList();
        }
    }
}

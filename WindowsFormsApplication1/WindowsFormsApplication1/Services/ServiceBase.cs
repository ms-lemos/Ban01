using System;

namespace WindowsFormsApplication1.Services
{
    public abstract class ServiceBase<TEntity> where TEntity : class
    {
        public abstract TEntity GetById(int id);
        public abstract TEntity GetAll(int id);
        public abstract TEntity GetAllBetweenDates(DateTime from, DateTime to);
        public abstract void Insert(TEntity entity);
        public abstract void Update(TEntity entity);
        public abstract void Delete(TEntity entity);
    }
}

using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {

        #region Implementation of IEntityRepository<Car>

        public List<Car> FindAll(Expression<Func<Car, bool>> filter = null)
        {
            using (MsDbContext context = new MsDbContext())
            {
                return filter == null
                    ? context.Set<Car>().ToList()
                    : context.Set<Car>().Where(filter).ToList();
            }
        }

        public Car Find(Expression<Func<Car, bool>> filter)
        {
            using (MsDbContext context = new MsDbContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }


        public void Add(Car entity)
        {
            using (MsDbContext context = new MsDbContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update(Car entity)
        {
            using (MsDbContext context = new MsDbContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (MsDbContext context = new MsDbContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        #endregion
    }
}

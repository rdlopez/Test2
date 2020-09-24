using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class Repository<Entity> : IRepository<Entity> where Entity : BaseEntity
    {
        private readonly TestContext context;
        public Repository(TestContext context)
        {
            this.context = context;
        }

        public Type ElementType => throw new NotImplementedException();

        public Expression Expression => throw new NotImplementedException();

        public IQueryProvider Provider => throw new NotImplementedException();

        public Task Delete(Entity entity)
        {
            throw new NotImplementedException();
        }

        public IList<Entity> GetAll(bool useCache = true, bool IncludeDisabled = false)
        {
            return context.Set<Entity>().ToList();
        }

        public IEnumerator<Entity> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public Task Put(IEnumerable<Entity> entities)
        {
            throw new NotImplementedException();
        }

        public Task Put(Entity entity)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Entity entity, Func<Entity, Entity, bool> mergeNewEntity = null)
        {
            await Execute(async () =>
            {
                context.Update(entity);
                await context.SaveChangesAsync();
            });
        }

        private async Task Execute(Func<Task> action)
        {
            try
            {
                await action();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public Task Update(IEnumerable<Entity> entities, Func<Entity, Entity, bool> mergeNewEntity = null)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}

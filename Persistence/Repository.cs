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

        public async Task<IList<Entity>> GetAll(bool useCache = true, bool IncludeDisabled = false)
        {
            return await context.Set<Entity>().ToListAsync();
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
                //try
                //{
                //    context.Update(entity);
                //    await context.SaveChangesAsync();
                //}
                //catch (DbUpdateConcurrencyException ex)
                //{
                //    Console.WriteLine(ex);
                //    foreach (var entry in ex.Entries)
                //    {
                //        if (entry.Entity is UploadFile)
                //        {
                //            var proposedValues = entry.CurrentValues;
                //            var databaseValues = entry.GetDatabaseValues();

                //            foreach (var property in proposedValues.Properties)
                //            {
                //                Console.WriteLine(property);
                //                var proposedValue = proposedValues[property];
                //                var databaseValue = databaseValues[property];

                //                // TODO: decide which value should be written to database
                //                // proposedValues[property] = <value to be saved>;
                //            }

                //            // Refresh original values to bypass next concurrency check
                //            entry.OriginalValues.SetValues(databaseValues);
                //        }
                //        else
                //        {
                //        }
                //    }
                //}
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

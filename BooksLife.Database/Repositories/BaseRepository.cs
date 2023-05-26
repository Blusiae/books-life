﻿using BooksLife.Core;
using Microsoft.EntityFrameworkCore;

namespace BooksLife.Database
{
    public abstract class BaseRepository<Entity> : IBaseRepository<Entity> where Entity : BaseEntity
    {
        protected ApplicationDbContext _context;
        protected abstract DbSet<Entity> DbSet { get; }

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public bool Add(Entity entity)
        {
            DbSet.Add(entity);
            return _context.SaveChanges() > 0;
        }

        public Entity Get(int id)
        {
            return DbSet.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Entity> GetAll()
        {
            return DbSet.Select(x => x);
        }

        public bool Remove(int id)
        {
            var entityToDelete = DbSet.FirstOrDefault(x =>x.Id == id);
            if (entityToDelete != null) //Check if entity has been found in database.
            {
                DbSet.Remove(entityToDelete);
                return _context.SaveChanges() > 0;
            }

            return false; //Entity not found, so it's not been deleted.
        }
    }
}

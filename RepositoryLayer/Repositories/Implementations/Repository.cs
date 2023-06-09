﻿using DomainLayer.Common;
using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Data;
using RepositoryLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _entities;

        public Repository(AppDbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException();

            await _entities.AddAsync(entity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            if (_entities == null) throw new ArgumentNullException();

            _entities.Remove(entity);

            await _context.SaveChangesAsync();  
        }

        public async Task<T> GetAsync(int id)
        {
            return await _entities.FindAsync(id) ?? throw new NotImplementedException();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            if (!_entities.Contains(entity)) throw new NotImplementedException();

            _entities.Update(entity);

            await _context.SaveChangesAsync();
        }


        public async Task<List<T>> FindAllByExpression(Expression<Func<T, bool>> expression)
        {
            return await _entities.Where(m => !m.SoftDeleted).Where(expression).AsNoTracking().ToListAsync();
        }


        public async Task<bool> IsExsist(Expression<Func<T, bool>> expression)
        {
            return await _entities.AnyAsync(expression);

        }



        public async Task DeleteList(List<T> entity)
        {
            foreach (var courseAuthor in entity)
            {
                _entities.Remove(courseAuthor);

                await _context.SaveChangesAsync();
            }
        }

        public async Task SoftDelete(T entity)
        {
            T? model = await _entities.FirstOrDefaultAsync(e => e.Id == entity.Id) ?? throw new NullReferenceException();

            model.SoftDeleted = true;

            await _context.SaveChangesAsync();
        }
    }


}

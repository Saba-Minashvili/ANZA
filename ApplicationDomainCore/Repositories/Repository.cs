﻿using ApplicationDomainCore.Repositories.Abstraction;
using ApplicationDomainEntity;
using ApplicationDomainModels.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationDomainCore.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _db = default;
        private readonly DbSet<T> _entity = default;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            _entity = _db.Set<T>();
        }
        public async Task<bool> CreateAsync(T item)
        {
            _entity.Add(item);
            return await SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(T item)
        {
            _entity.Remove(item);
            return await SaveChangesAsync();
        }

        public DbSet<T> Get()
        {
            return _entity;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _entity.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<T>> ReadAsync()
        {
            return await _entity.ToListAsync();
        }

        public async Task<bool> UpdateAsync(int id, T item)
        {
            item.Id = id;
            _entity.Update(item);
            return await SaveChangesAsync();
        }

        private async Task<bool> SaveChangesAsync()
        {
            try
            {
                return (await _db.SaveChangesAsync()) >= 0;
            }
            catch
            {
                return false;
            }
        }
    }
}

﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Berger.Extensions.Repository.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> IgnoreQueryFilters();
        IQueryable<T> Get();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        T GetByID(Guid id);
        T FirstOrDefault(Expression<Func<T, bool>> predicate);
        T Add(T element, bool detach = false);
        void Add(IQueryable<T> elements, bool detach = false);
        T Update(T element);
        void Delete(Guid id);
        void Delete(IQueryable<T> elements);
        Task<T> AddAsync(T element);
        Task<T> UpdateAsync(T element);
        Task UpdateAsync(Func<T, string> field, string value);
        Task DeleteAsync(Guid id);
    }
}
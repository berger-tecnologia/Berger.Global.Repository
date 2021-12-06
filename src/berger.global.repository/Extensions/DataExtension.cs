﻿using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Berger.Global.Repository.Extensions
{
    public static class DataExtension
    {
        public static void SoftDelete<T>(this DbContext context, T entity) where T : class
        {
            context.Entry(entity).CurrentValues["Deleted"] = true;
            context.Entry(entity).Property("Deleted").IsModified = true;
        }
        public static void Detach<T>(this DbContext context, T element)
        {
            context.Entry(element).State = EntityState.Detached;
        }

        public static void Detach<T>(this DbContext context, IQueryable<T> elements)
        {
            //var entries = context.ChangeTracker
            //    .Entries()
            //    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted)
            //    .ToList();

            foreach (var element in elements)
            {
                context.Entry(element).State = EntityState.Detached;
            }
        }
    }
}
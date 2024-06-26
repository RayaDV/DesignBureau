﻿namespace DesignBureau.Infrastructure.Common
{
    public interface IRepository
    {
        IQueryable<T> All<T>() where T : class;

        IQueryable<T> AllReadOnly<T>() where T : class;

        Task AddAsync<T>(T entity) where T : class;

        Task AddRangeAsync<T>(List<T> entity) where T : class;

        Task<int> SaveChangesAsync();   // return the count of changed entities

        Task<T?> GetByIdAsync<T>(object id) where T : class;

        Task DeleteAsync<T>(object id) where T : class;


    }
}

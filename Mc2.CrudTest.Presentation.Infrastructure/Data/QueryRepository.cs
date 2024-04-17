// <copyright file="QueryRepository.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System.Linq.Expressions;
using EFCoreSecondLevelCacheInterceptor;
using Mc2.CrudTest.Presentation.Application.Common.Interfaces;
using Mc2.CrudTest.Presentation.Application.Common.Models;
using Mc2.CrudTest.Presentation.Domain.Common;
using Mc2.CrudTest.Presentation.Infrastructure.Data.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Mc2.CrudTest.Presentation.Infrastructure.Data
{
    public class QueryRepository : IQueryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public QueryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IQueryable<T> Table<T>() where T : class => _dbContext.Set<T>();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheable"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<List<T>> GetListAsync<T>(bool cacheable = false, CancellationToken cancellationToken = default)
            where T : class
        {
            return GetListAsync<T>(asNoTracking: false, cacheable: cacheable, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="asNoTracking"></param>
        /// <param name="cacheable"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<List<T>> GetListAsync<T>(bool asNoTracking, bool cacheable = false, CancellationToken cancellationToken = default)
            where T : class
        {
            Func<IQueryable<T>, IIncludableQueryable<T, object>> nullValue = null;
            return GetListAsync(nullValue, asNoTracking, cacheable: cacheable, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="includes"></param>
        /// <param name="cacheable"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<List<T>> GetListAsync<T>(
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes,
             bool cacheable = false,
            CancellationToken cancellationToken = default)
            where T : class
        {
            return GetListAsync(includes, false, cacheable: cacheable, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="includes"></param>
        /// <param name="asNoTracking"></param>
        /// <param name="cacheable"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<T>> GetListAsync<T>(
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes,
            bool asNoTracking,
            bool cacheable = false,
            CancellationToken cancellationToken = default)
            where T : class
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (includes != null)
            {
                query = includes(query);
            }

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            if (cacheable)
            {
                query = query.Cacheable();
            }

            List<T> items = await query.ToListAsync(cancellationToken).ConfigureAwait(false);

            return items;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <param name="cacheable"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<List<T>> GetListAsync<T>(
            Expression<Func<T, bool>> condition,
            bool cacheable = false,
            CancellationToken cancellationToken = default)
             where T : class
        {
            return GetListAsync(condition, false, cacheable, cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <param name="asNoTracking"></param>
        /// <param name="cacheable"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<List<T>> GetListAsync<T>(
            Expression<Func<T, bool>> condition,
            bool asNoTracking,
            bool cacheable = false,
            CancellationToken cancellationToken = default)
             where T : class
        {
            return GetListAsync(condition, null, asNoTracking, cacheable, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <param name="includes"></param>
        /// <param name="asNoTracking"></param>
        /// <param name="cacheable"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<T>> GetListAsync<T>(
            Expression<Func<T, bool>> condition,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes,
            bool asNoTracking,
            bool cacheable = false,
            CancellationToken cancellationToken = default)
             where T : class
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (condition != null)
            {
                query = query.Where(condition);
            }

            if (includes != null)
            {
                query = includes(query);
            }

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            if (cacheable)
            {
                query = query.Cacheable();
            }

            List<T> items = await query.ToListAsync(cancellationToken).ConfigureAwait(false);

            return items;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="specification"></param>
        /// <param name="cacheable"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<List<T>> GetListAsync<T>(Specification<T> specification, bool cacheable = false, CancellationToken cancellationToken = default)
           where T : class
        {
            return GetListAsync(specification, false, cacheable, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="specification"></param>
        /// <param name="asNoTracking"></param>
        /// <param name="cacheable"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<T>> GetListAsync<T>(
            Specification<T> specification,
            bool asNoTracking,
            bool cacheable = false,
            CancellationToken cancellationToken = default)
           where T : class
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (specification != null)
            {
                query = query.GetSpecifiedQuery(specification);
            }

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            if (cacheable)
            {
                query = query.Cacheable();
            }

            return await query.ToListAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TProjectedType"></typeparam>
        /// <param name="selectExpression"></param>
        /// <param name="cacheable"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<List<TProjectedType>> GetListAsync<T, TProjectedType>(
            Expression<Func<T, TProjectedType>> selectExpression,
            bool cacheable = false,
            CancellationToken cancellationToken = default)
            where T : class
        {
            if (selectExpression == null)
            {
                throw new ArgumentNullException(nameof(selectExpression));
            }
            IQueryable<T> query = _dbContext.Set<T>();

            if (cacheable)
            {
                query = query.Cacheable();
            }

            List<TProjectedType> entities = await query
                .Select(selectExpression).ToListAsync(cancellationToken).ConfigureAwait(false);

            return entities;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TProjectedType"></typeparam>
        /// <param name="condition"></param>
        /// <param name="selectExpression"></param>
        /// <param name="cacheable"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<List<TProjectedType>> GetListAsync<T, TProjectedType>(
            Expression<Func<T, bool>> condition,
            Expression<Func<T, TProjectedType>> selectExpression,
            bool cacheable = false,
            CancellationToken cancellationToken = default)
            where T : class
        {
            if (selectExpression == null)
            {
                throw new ArgumentNullException(nameof(selectExpression));
            }

            IQueryable<T> query = _dbContext.Set<T>();

            if (condition != null)
            {
                query = query.Where(condition);
            }
            if (cacheable)
            {
                query = query.Cacheable();
            }


            List<TProjectedType> projectedEntites = await query.Select(selectExpression)
                .ToListAsync(cancellationToken).ConfigureAwait(false);

            return projectedEntites;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TProjectedType"></typeparam>
        /// <param name="specification"></param>
        /// <param name="selectExpression"></param>
        /// <param name="cacheable"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<List<TProjectedType>> GetListAsync<T, TProjectedType>(
            Specification<T> specification,
            Expression<Func<T, TProjectedType>> selectExpression,
            bool cacheable = false,
            CancellationToken cancellationToken = default)
            where T : class
        {
            if (selectExpression == null)
            {
                throw new ArgumentNullException(nameof(selectExpression));
            }

            IQueryable<T> query = _dbContext.Set<T>();

            if (specification != null)
            {
                query = query.GetSpecifiedQuery(specification);
            }
            if (cacheable)
            {
                query = query.Cacheable();
            }

            return await query.Select(selectExpression)
                .ToListAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="specification"></param>
        /// <param name="cacheable"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<PaginatedList<T>> GetListAsync<T>(
            PaginationSpecification<T> specification,
            bool cacheable = false,
            CancellationToken cancellationToken = default)
            where T : class
        {
            if (specification == null)
            {
                throw new ArgumentNullException(nameof(specification));
            }

            IQueryable<T> query = _dbContext.Set<T>();

            if (cacheable)
            {
                query = query.Cacheable();
            }

            PaginatedList<T> paginatedList = await query.ToPaginatedListAsync(specification, cancellationToken);
            return paginatedList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TProjectedType"></typeparam>
        /// <param name="specification"></param>
        /// <param name="selectExpression"></param>
        /// <param name="cacheable"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<PaginatedList<TProjectedType>> GetListAsync<T, TProjectedType>(
            PaginationSpecification<T> specification,
            Expression<Func<T, TProjectedType>> selectExpression,
            bool cacheable = false,
            CancellationToken cancellationToken = default)
            where T : class
            where TProjectedType : class
        {
            if (specification == null)
            {
                throw new ArgumentNullException(nameof(specification));
            }

            if (selectExpression == null)
            {
                throw new ArgumentNullException(nameof(selectExpression));
            }

            IQueryable<T> query = _dbContext.Set<T>().GetSpecifiedQuery((SpecificationBase<T>)specification);

            if (cacheable)
            {
                query = query.Cacheable();
            }

            PaginatedList<TProjectedType> paginatedList = await query.Select(selectExpression)
                .ToPaginatedListAsync(specification.PageIndex, specification.PageSize, cancellationToken);
            return paginatedList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="cacheable"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<T> GetByIdAsync<T>(int id, bool cacheable = false, CancellationToken cancellationToken = default)
                  where T : BaseEntity<int>
        {
            return GetByIdAsync<T>(id, asNoTracking: false, cacheable: cacheable, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="asNoTracking"></param>
        /// <param name="cacheable"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<T> GetByIdAsync<T>(int id,
            bool asNoTracking = false,
            bool cacheable = false,
            CancellationToken cancellationToken = default)
            where T : BaseEntity<int>
        {
            return GetByIdAsync<T>(id, null, asNoTracking, cacheable: cacheable, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="includes"></param>
        /// <param name="cacheable"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<T> GetByIdAsync<T>(
            int id,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes,
            bool cacheable = false,
            CancellationToken cancellationToken = default)
            where T : BaseEntity<int>
        {
            return GetByIdAsync(id, includes, asNoTracking: false, cacheable: cacheable, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="includes"></param>
        /// <param name="asNoTracking"></param>
        /// <param name="cacheable"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<T> GetByIdAsync<T>(
            int id,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes,
            bool asNoTracking = false,
            bool cacheable = false,
            CancellationToken cancellationToken = default)
            where T : BaseEntity<int>
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (includes != null)
            {
                query = includes(query);
            }

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }
            if (cacheable)
            {
                query = query.Cacheable();
            }
            T? enity = await query.FirstOrDefaultAsync(x => x.Id == id, cancellationToken).ConfigureAwait(false);
            if (enity == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            return enity;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TProjectedType"></typeparam>
        /// <param name="id"></param>
        /// <param name="selectExpression"></param>
        /// <param name="cacheable"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<TProjectedType> GetByIdAsync<T, TProjectedType>(
            int id,
            Expression<Func<T, TProjectedType>> selectExpression,
            bool cacheable = false,
            CancellationToken cancellationToken = default)
            where T : BaseEntity<int>
        {
            if (selectExpression == null)
            {
                throw new ArgumentNullException(nameof(selectExpression));
            }
            IQueryable<T> query = _dbContext.Set<T>();


            if (cacheable)
            {
                query = query.Cacheable();
            }
            TProjectedType? enity = await query.Where(x => x.Id == id).Select(selectExpression)
                .FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);
            if (enity == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            return enity;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="cacheable"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<T> GetByIdAsync<T>(long id, bool cacheable = false, CancellationToken cancellationToken = default)
                  where T : BaseEntity<long>
        {
            return GetByIdAsync<T>(id, asNoTracking: false, cacheable: cacheable, cancellationToken);
        }

        public Task<T> GetByIdAsync<T>(long id,
            bool asNoTracking = false,
            bool cacheable = false,
            CancellationToken cancellationToken = default)
            where T : BaseEntity<long>
        {
            return GetByIdAsync<T>(id, null, asNoTracking, cacheable, cancellationToken);
        }

        public Task<T> GetByIdAsync<T>(
            long id,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes,
            bool cacheable = false,
            CancellationToken cancellationToken = default)
            where T : BaseEntity<long>
        {
            return GetByIdAsync(id, includes, asNoTracking: false, cacheable, cancellationToken);
        }

        public async Task<T> GetByIdAsync<T>(
            long id,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes,
            bool asNoTracking = false,
            bool cacheable = false,
            CancellationToken cancellationToken = default)
            where T : BaseEntity<long>
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (includes != null)
            {
                query = includes(query);
            }

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }
            if (cacheable)
            {
                query = query.Cacheable();
            }
            T? enity = await query.FirstOrDefaultAsync(x => x.Id == id, cancellationToken).ConfigureAwait(false);
            if (enity == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            return enity;
        }

        public async Task<TProjectedType> GetByIdAsync<T, TProjectedType>(
            long id,
            Expression<Func<T, TProjectedType>> selectExpression,
            bool cacheable = false,
            CancellationToken cancellationToken = default)
            where T : BaseEntity<long>
        {
            if (selectExpression == null)
            {
                throw new ArgumentNullException(nameof(selectExpression));
            }
            IQueryable<T> query = _dbContext.Set<T>();


            if (cacheable)
            {
                query = query.Cacheable();
            }
            TProjectedType? enity = await query.Where(x => x.Id == id).Select(selectExpression)
                .FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);
            if (enity == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            return enity;
        }





        public Task<T> GetByIdAsync<T>(Guid id, bool cacheable = false, CancellationToken cancellationToken = default)
                  where T : BaseEntity<Guid>
        {
            return GetByIdAsync<T>(id, asNoTracking: false, cacheable: cacheable, cancellationToken);
        }

        public Task<T> GetByIdAsync<T>(Guid id,
            bool asNoTracking = false,
            bool cacheable = false,
            CancellationToken cancellationToken = default)
            where T : BaseEntity<Guid>
        {
            return GetByIdAsync<T>(id, null, asNoTracking, cacheable: cacheable, cancellationToken);
        }

        public Task<T> GetByIdAsync<T>(
            Guid id,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes,
            bool cacheable = false,
            CancellationToken cancellationToken = default)
            where T : BaseEntity<Guid>
        {
            return GetByIdAsync(id, includes, asNoTracking: false, cacheable: cacheable, cancellationToken);
        }

        public async Task<T> GetByIdAsync<T>(
            Guid id,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes,
            bool asNoTracking = false,
            bool cacheable = false,
            CancellationToken cancellationToken = default)
            where T : BaseEntity<Guid>
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (includes != null)
            {
                query = includes(query);
            }

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }
            if (cacheable)
            {
                query = query.Cacheable();
            }
            T? enity = await query.FirstOrDefaultAsync(x => x.Id == id, cancellationToken).ConfigureAwait(false);
            if (enity == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            return enity;
        }

        public async Task<TProjectedType> GetByIdAsync<T, TProjectedType>(
            Guid id,
            Expression<Func<T, TProjectedType>> selectExpression,
            bool cacheable = false,
            CancellationToken cancellationToken = default)
            where T : BaseEntity<Guid>
        {
            if (selectExpression == null)
            {
                throw new ArgumentNullException(nameof(selectExpression));
            }
            IQueryable<T> query = _dbContext.Set<T>();


            if (cacheable)
            {
                query = query.Cacheable();
            }
            TProjectedType? enity = await query.Where(x => x.Id == id).Select(selectExpression)
                .FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);
            if (enity == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            return enity;
        }


        public Task<T> GetAsync<T>(
            Expression<Func<T, bool>> condition,
            bool cacheable = false,
            CancellationToken cancellationToken = default)
           where T : class
        {
            return GetAsync(condition, null, false, cancellationToken);
        }

        public Task<T> GetAsync<T>(
            Expression<Func<T, bool>> condition,
            bool asNoTracking,
            bool cacheable = false,
            CancellationToken cancellationToken = default)
           where T : class
        {
            return GetAsync(condition, null, asNoTracking, cacheable, cancellationToken);
        }

        public Task<T> GetAsync<T>(
            Expression<Func<T, bool>> condition,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes,
            bool cacheable = false,
            CancellationToken cancellationToken = default)
           where T : class
        {
            return GetAsync(condition, includes, false, cacheable, cancellationToken);
        }

        public async Task<T> GetAsync<T>(
            Expression<Func<T, bool>> condition,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes,
            bool asNoTracking,
            bool cacheable = false,
            CancellationToken cancellationToken = default)
           where T : class
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (condition != null)
            {
                query = query.Where(condition);
            }

            if (includes != null)
            {
                query = includes(query);
            }

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);
        }

        public Task<T> GetAsync<T>(Specification<T> specification,
            bool cacheable = false, CancellationToken cancellationToken = default)
            where T : class
        {
            return GetAsync(specification, false, cacheable, cancellationToken);
        }

        public async Task<T> GetAsync<T>(Specification<T> specification, bool asNoTracking, bool cacheable = false, CancellationToken cancellationToken = default)
            where T : class
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (specification != null)
            {
                query = query.GetSpecifiedQuery(specification);
            }

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }
            if (cacheable)
            {
                query = query.Cacheable();
            }
            var result = await query.FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);
            return result;
        }

        public async Task<TProjectedType> GetAsync<T, TProjectedType>(
            Expression<Func<T, bool>> condition,
            Expression<Func<T, TProjectedType>> selectExpression,
            bool cacheable = false,
            CancellationToken cancellationToken = default)
            where T : class
        {
            if (selectExpression == null)
            {
                throw new ArgumentNullException(nameof(selectExpression));
            }

            IQueryable<T> query = _dbContext.Set<T>();

            if (condition != null)
            {
                query = query.Where(condition);
            }
            if (cacheable)
            {
                query = query.Cacheable();
            }
            var result = await query.Select(selectExpression).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);
            return result;
        }

        public async Task<TProjectedType> GetAsync<T, TProjectedType>(
            Specification<T> specification,
            Expression<Func<T, TProjectedType>> selectExpression,
            bool cacheable = false,
            CancellationToken cancellationToken = default)
            where T : class
        {
            if (selectExpression == null)
            {
                throw new ArgumentNullException(nameof(selectExpression));
            }

            IQueryable<T> query = _dbContext.Set<T>();

            if (specification != null)
            {
                query = query.GetSpecifiedQuery(specification);
            }

            if (cacheable)
            {
                query = query.Cacheable();
            }
            return await query.Select(selectExpression).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);
        }

        public Task<bool> ExistsAsync<T>(CancellationToken cancellationToken = default)
           where T : class
        {
            return ExistsAsync<T>(null, cancellationToken);
        }

        public async Task<bool> ExistsAsync<T>(Expression<Func<T, bool>> condition, CancellationToken cancellationToken = default)
           where T : class
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (condition == null)
            {
                return await query.AnyAsync(cancellationToken);
            }

            bool isExists = await query.AnyAsync(condition, cancellationToken).ConfigureAwait(false);
            return isExists;
        }

        public async Task<bool> ExistsByIdAsync<T>(int id, CancellationToken cancellationToken = default)
           where T : BaseEntity<int>
        {
            IQueryable<T> query = _dbContext.Set<T>();

            bool isExistent = await query.AnyAsync(x => x.Id == id, cancellationToken).ConfigureAwait(false);
            return isExistent;
        }

        public async Task<bool> ExistsByIdAsync<T>(long id, CancellationToken cancellationToken = default)
           where T : BaseEntity<long>
        {
            IQueryable<T> query = _dbContext.Set<T>();

            bool isExistent = await query.AnyAsync(x => x.Id == id, cancellationToken).ConfigureAwait(false);
            return isExistent;
        }

        public async Task<bool> ExistsByIdAsync<T>(Guid id, CancellationToken cancellationToken = default)
           where T : BaseEntity<Guid>
        {
            IQueryable<T> query = _dbContext.Set<T>();

            bool isExistent = await query.AnyAsync(x => x.Id == id, cancellationToken).ConfigureAwait(false);
            return isExistent;
        }

        public async Task<int> GetCountAsync<T>(CancellationToken cancellationToken = default)
            where T : class
        {
            int count = await _dbContext.Set<T>().CountAsync(cancellationToken).ConfigureAwait(false);
            return count;
        }

        public async Task<int> GetCountAsync<T>(Expression<Func<T, bool>> condition, CancellationToken cancellationToken = default)
            where T : class
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (condition != null)
            {
                query = query.Where(condition);
            }

            return await query.CountAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<int> GetCountAsync<T>(IEnumerable<Expression<Func<T, bool>>> conditions, CancellationToken cancellationToken = default)
            where T : class
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (conditions != null)
            {
                foreach (Expression<Func<T, bool>> expression in conditions)
                {
                    query = query.Where(expression);
                }
            }

            return await query.CountAsync(cancellationToken).ConfigureAwait(false);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

    }
}
using AutoMapper;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class Repository<T> where T : class
    {

        protected readonly CrudDbContext _DbContext;
        protected DbSet<T> _Entities { get; }
        public virtual IQueryable<T> Table => _Entities;
        public virtual IQueryable<T> TableNoTracking => _Entities.AsNoTracking();

        public readonly IMapper _mapper;

        public Repository(CrudDbContext context, IMapper mapper)
        {
            _DbContext = context;
            _Entities = _DbContext.Set<T>();
            _mapper = mapper;
        }
    }
}

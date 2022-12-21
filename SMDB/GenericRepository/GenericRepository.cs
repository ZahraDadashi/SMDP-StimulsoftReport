using SMDP.SMDPModels;
using Microsoft.EntityFrameworkCore;
namespace SMDP.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal SmdpContext _context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(SmdpContext context)
        {
            _context = context;
            dbSet = context.Set<TEntity>();
        }

      
        public void Register(TEntity obj)
        {

            dbSet.Add(obj);
            _context.SaveChanges();

        }

    }
}

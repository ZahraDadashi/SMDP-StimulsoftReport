namespace SMDP.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Register(TEntity obj);
    }
}

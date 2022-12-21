using SMDP.SMDPModels;
using SMDP.GenericRepository;
namespace SMDP.Repository
{
    public interface IUserRepository : IGenericRepository<User>,IDisposable
    {
        dynamic Login(Userr request);
    }
}

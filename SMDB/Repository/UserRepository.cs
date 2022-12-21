using SMDP.SMDPModels;
using SMDP.Controllers;
using SMDP.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace SMDP.Repository
{
    public class UserRepository : GenericRepository<User>,IUserRepository
    {
        private readonly SmdpContext _db;

        public UserRepository(SmdpContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public dynamic Login(Userr userlogin)
        {
            var usertable = _db.Users.Where(i =>
               i.UserName == userlogin.UserName).FirstOrDefault();
            return usertable;
        }

    }
}

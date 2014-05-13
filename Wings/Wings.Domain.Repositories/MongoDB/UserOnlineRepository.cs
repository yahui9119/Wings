using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;

namespace Wings.Domain.Repositories.MongoDB
{
    public class UserOnlineRepository : MongoDBRepository<UserOnline>, IUserOnlineRepository
    {
        public UserOnlineRepository(IRepositoryContext Context)
            : base(Context)
        {

        }
    }
}

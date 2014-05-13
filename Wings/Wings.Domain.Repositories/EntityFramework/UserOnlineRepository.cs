using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;

namespace Wings.Domain.Repositories.EntityFramework
{
    public class UserOnlineRepository: EntityFrameworkRepository<UserOnline>, IUserOnlineRepository
    {
        public UserOnlineRepository(IRepositoryContext Context)
            : base(Context)
        {

        }
    }
}

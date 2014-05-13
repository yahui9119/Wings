using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;

namespace Wings.Domain.Repositories.MongoDB
{
    public class RoleRepository : MongoDBRepository<Role>, IRoleRepository
    {
        public RoleRepository(IRepositoryContext Context)
            : base(Context) { }

       
    }
}

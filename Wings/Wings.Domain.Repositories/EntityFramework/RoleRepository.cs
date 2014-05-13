using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;

namespace Wings.Domain.Repositories.EntityFramework
{
    public class RoleRepository : EntityFrameworkRepository<Role>, IRoleRepository
    {
        public RoleRepository(IRepositoryContext Context)
            : base(Context) { }

       
    }
}

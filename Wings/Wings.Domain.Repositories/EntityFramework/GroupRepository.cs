using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Domain.Repositories.EntityFramework
{
    public class GroupRepository: EntityFrameworkRepository<Model.Group> ,IGroupRepository
    {
        public GroupRepository(IRepositoryContext Context): base(Context)
        {
 
        }
    }
}

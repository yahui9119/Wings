using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Domain.Repositories.MongoDB
{
    public class GroupRepository : MongoDBRepository<Model.Group>, IGroupRepository
    {
        public GroupRepository(IRepositoryContext Context): base(Context)
        {
 
        }
    }
}

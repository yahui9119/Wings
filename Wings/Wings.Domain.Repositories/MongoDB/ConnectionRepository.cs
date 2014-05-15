using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Domain.Repositories.MongoDB
{
    public class ConnectionRepository : MongoDBRepository<Model.Connection>, IConnectionRepository
    {
        public ConnectionRepository(IRepositoryContext Context)
            : base(Context)
        {
 
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Domain.Repositories.EntityFramework
{
    public class ConnectionRepository:EntityFrameworkRepository<Model.Connection> ,IConnectionRepository
    {
        public ConnectionRepository(IRepositoryContext Context)
            : base(Context)
        {
 
        }
    }
}

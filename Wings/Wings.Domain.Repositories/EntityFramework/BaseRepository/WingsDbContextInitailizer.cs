using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Domain.Repositories.EntityFramework
{
    public sealed class WingsDbContextInitailizer :System.Data.Entity.DropCreateDatabaseIfModelChanges<WingsDbContext>
    {
        public static void Initailizer()
        {
            Database.SetInitializer<WingsDbContext>(null);
        }
    }
}

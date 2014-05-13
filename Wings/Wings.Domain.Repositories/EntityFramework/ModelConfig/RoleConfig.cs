using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;

namespace Wings.Domain.Repositories.EntityFramework.ModelConfig
{
    internal class RoleConfig:BaseConfig<Role>
    {
        public RoleConfig()
            : base()
        {
            Property(r => r.Name).IsRequired().HasMaxLength(50);
            Property(r => r.Description).IsRequired().HasMaxLength(200);
          
            HasMany(r => r.Modules).WithMany(m => m.Roles).Map(r => 
            {
                r.MapLeftKey("RoleID");
                r.MapRightKey("ModuleID");
                r.ToTable("RolePermission");
            });
        }
    }
}

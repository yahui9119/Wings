using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;

namespace Wings.Domain.Repositories.EntityFramework.ModelConfig
{
    internal class GroupConfig : BaseConfig<Group>
    {
        public GroupConfig()
            : base()
        {
            Property(g => g.Name).IsRequired().HasMaxLength(50);
            Property(g => g.Description).IsRequired().HasMaxLength(200);
            HasMany(g => g.ChildGroup).WithOptional(g => g.ParentGroup).Map(g => g.MapKey("ParentID"));//自关联 
           
            //HasOptional(g => g.Permission).WithOptionalDependent().Map(g => { g.MapKey("PermissionID"); });
            HasMany(g => g.Modules).WithMany(m => m.Groups).Map(g => 
            {
                g.MapLeftKey("GroupID");
                g.MapRightKey("ModuleID");
                g.ToTable("GroupPermission");
            });
        }
    }
}

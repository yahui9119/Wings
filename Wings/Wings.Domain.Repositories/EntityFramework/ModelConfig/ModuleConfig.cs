using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;

namespace Wings.Domain.Repositories.EntityFramework.ModelConfig
{
    internal class ModuleConfig : BaseConfig<Module>
    {
        public ModuleConfig()
            : base()
        {
            Property(m => m.Name).IsRequired().HasMaxLength(50);
            Property(m => m.Description).IsRequired().HasMaxLength(200);
            Property(m => m.ICON).IsRequired().HasMaxLength(100);
            Property(m => m.ControllerName).IsOptional().HasMaxLength(100);
            Property(m => m.ActionName).IsOptional().HasMaxLength(100);
            Property(m => m.Target).IsOptional().HasMaxLength(100);
            Property(m => m.Url).IsOptional().HasMaxLength(100);
            Property(m => m.Target).IsOptional().HasMaxLength(100);
            Property(m => m.IsPost).IsRequired();
            Property(m => m.Index).IsRequired();
            Property(m => m.IsMenus).IsRequired();

            HasMany(m => m.ChildModule).WithOptional(m => m.ParentModule).Map(m => m.MapKey("ParentID"));//自关联 
        }

    }
}

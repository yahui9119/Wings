using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Wings.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wings.Domain.Repositories.EntityFramework.ModelConfig
{
    internal class UserConfig : BaseConfig<User>
    {
        public UserConfig()
            : base()
        {
            Property(u => u.Account).IsRequired().HasMaxLength(50);
            Property(u => u.Email).IsRequired().HasMaxLength(50);
            Property(u => u.Password).IsRequired().HasMaxLength(50);
            Property(u => u.Email).IsRequired().HasMaxLength(50);
            Property(u => u.PhoneNum).IsRequired().HasMaxLength(11);
            Property(u => u.Zip).IsRequired().HasMaxLength(20);
            Property(u => u.QQ).HasMaxLength(50);
            Property(u => u.ALiWangWang).HasMaxLength(50);
            Property(u => u.Address).IsRequired().HasMaxLength(200);
            Property(u => u.LastloginTime).IsRequired();
            //多对多关联
            HasMany(g => g.Groups).WithMany(u => u.Users).Map(g =>
            {
                g.ToTable("UserGroup");
                g.MapLeftKey("UserId");
                g.MapRightKey("GroupID"); 
            });

            HasMany(r => r.Roles).WithMany(u => u.Users).Map(ur =>
            {
                ur.ToTable("UserRole");
                ur.MapLeftKey("UserID");
                ur.MapRightKey("RoleID");
            });
            HasMany(u => u.Webs).WithMany(w => w.Users).Map(uw =>
            {
                uw.ToTable("UserWeb");
                uw.MapLeftKey("UserID");
                uw.MapRightKey("WebID");
               
            });
            HasMany(u => u.ModuleAllow).WithMany(m => m.UserAllow).Map(u =>
            {
                u.ToTable("UserAllowPermission");
                u.MapLeftKey("UserID");
                u.MapRightKey("ModuleID");
            });
            HasMany(u => u.ModuleBan).WithMany(m => m.UserBan).Map(u =>
            {
                u.ToTable("UserBanPermission");
                u.MapLeftKey("UserID");
                u.MapRightKey("ModuleID");
            });
            Ignore(u => u.HaveGroups);
            Ignore(u => u.HaveRoles);
            Ignore(u => u.HaveWebs);
            Ignore(u => u.WebIDS);
            Ignore(u => u.GroupIDS);
            Ignore(u => u.RoleIDS);
        }
    }
}

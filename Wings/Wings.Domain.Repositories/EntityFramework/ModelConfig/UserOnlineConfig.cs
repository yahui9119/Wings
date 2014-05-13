using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;

namespace Wings.Domain.Repositories.EntityFramework.ModelConfig
{
    internal class UserOnlineConfig:BaseConfig<UserOnline>
    {
        public UserOnlineConfig()
            : base()
        {
            Property(u => u.IsOnline).IsRequired();

            HasOptional(uo => uo.user).WithOptionalDependent().Map(u => u.MapKey("UserID"));
            HasOptional(w => w.web).WithOptionalDependent().Map(w => w.MapKey("WebID"));
        }
    }
}

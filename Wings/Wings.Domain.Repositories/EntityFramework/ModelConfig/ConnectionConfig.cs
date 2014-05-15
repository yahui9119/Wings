using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Domain.Repositories.EntityFramework.ModelConfig
{
     internal class ConnectionConfig: BaseConfig<Model.Connection>
    {
         public ConnectionConfig()
            : base()
        {
            Property(m => m.Name).IsRequired().HasMaxLength(50);
            Property(m => m.Description).IsRequired().HasMaxLength(200);
            Property(m => m.Key).IsOptional().HasMaxLength(200);
            Property(m => m.Offset).IsOptional().HasMaxLength(200);
            Property(m => m.Value).IsOptional().HasMaxLength(1000);
            Property(m => m.EncryType).IsOptional().HasMaxLength(50);
            HasMany(m => m.Webs).WithMany(m => m.Connections).Map(m =>
                {
                    m.MapLeftKey("WebID");
                    m.MapRightKey("ConnectID");
                    m.ToTable("WebConnects");
                }); 
        }

    }
}

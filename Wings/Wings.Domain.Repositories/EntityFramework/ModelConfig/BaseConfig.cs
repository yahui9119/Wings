using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;

namespace Wings.Domain.Repositories.EntityFramework.ModelConfig
{
    public class BaseConfig<T> : EntityTypeConfiguration<T> where T : AggregateRoot
    {
        public BaseConfig()
        {
            HasKey<Guid>(a => a.ID);
            Property(a => a.ID).IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(a => a.CreateDate).IsRequired();
            Property(a => a.Creator).IsOptional();
            Property(a => a.Status).IsOptional();
            Property(a => a.EditDate).IsRequired();
            Property(a => a.Version).IsRequired().HasMaxLength(32).IsRowVersion();
        }
    }
}

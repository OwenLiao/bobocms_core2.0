
using bobo.entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bobo.orm.efcore.Config
{
    public class ManagerLogConfig : IEntityTypeConfiguration<ManagerLog>
    {
        public void Configure(EntityTypeBuilder<ManagerLog> builder)
        {
            builder.ToTable("ManagerLog").HasKey(e=>e.Id);
        }
    }
}

using bobo.entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bobo.orm.efcore.Config
{
    public class ManagerSysChannelConfig : IEntityTypeConfiguration<ManagerSysChannel>
    {
        public void Configure(EntityTypeBuilder<ManagerSysChannel> builder)
        {
            builder.ToTable("ManagerSysChannel").HasKey(e=>e.Id);
        }
    }
}

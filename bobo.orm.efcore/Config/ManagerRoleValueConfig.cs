


using bobo.entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bobo.orm.efcore.Config
{
    public class ManagerRoleValueConfig : IEntityTypeConfiguration<ManagerRoleValue>
    {
        public void Configure(EntityTypeBuilder<ManagerRoleValue> builder)
        {
            builder.ToTable("ManagerRoleValue").HasKey(e=>e.Id);
            builder.HasKey(e=>new { e.roleId,e.channelId});
        }
    }
}

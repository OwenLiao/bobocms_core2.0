
using bobo.entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bobo.orm.efcore.Config
{
    public class ManagerRoleConfig : IEntityTypeConfiguration<ManagerRole>
    {
        public void Configure(EntityTypeBuilder<ManagerRole> builder)
        {
            builder.ToTable("ManagerRole").HasKey(e=>e.Id);
        }
    }
}
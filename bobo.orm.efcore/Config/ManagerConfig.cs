using bobo.entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bobo.orm.efcore.Config
{
    public class ManagerConfig : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.ToTable("Manager").HasKey(e=>e.Id);
            builder.HasOne(q => q.ManagerRole).WithMany(e=>e.Managers).HasForeignKey(e=>e.roleId);
        }
    }
}


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using bobo.entity;

namespace bobo.orm.efcore.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category")
                .HasOne(q => q.Parent).WithMany(q => q.Childs).HasForeignKey(q => q.ParentId); ;

        }
    }
}

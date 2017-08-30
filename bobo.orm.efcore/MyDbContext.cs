﻿
using Microsoft.EntityFrameworkCore;
using bobo.entity;


namespace bobo.orm.efcore
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Article> Article { get; set; }
        public DbSet<Manager> Manager { get; set; }
        public DbSet<ManagerLog> ManagerLog { get; set; }

        public DbSet<ManagerRole> ManagerRole { get; set; }
        public DbSet<ManagerRoleValue> ManagerRoleValue { get; set; }
        public DbSet<SysChannel> SysChannel { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().ToTable("Category").HasOne(q => q.Parent).WithMany(q => q.Childs).HasForeignKey(q => q.ParentId);
            modelBuilder.Entity<Article>().ToTable("Article");
            modelBuilder.Entity<Manager>().HasOne(q => q.ManagerRole).WithMany(q => q.Managers).HasForeignKey(q => q.roleId);

            //文章详情标签多对多关系
            modelBuilder.Entity<ArticleCategory>().HasKey(q => new { q.ArticleId, q.CategoryId });
            modelBuilder.Entity<ArticleCategory>().HasOne(q => q.Article).WithMany(q => q.ArticleCategories).HasForeignKey(q => q.ArticleId);
            modelBuilder.Entity<ArticleCategory>().HasOne(q => q.Category).WithMany(q => q.ArticleCategories).HasForeignKey(q => q.CategoryId);

            ////列表文章标签多对多关系
            //modelBuilder.Entity<ListArticleCategory>().HasKey(q => new { q.ArticleId, q.CategoryId });
            //modelBuilder.Entity<ListArticleCategory>().HasOne(q => q.Article).WithMany(q => q.ListCategories).HasForeignKey(q => q.ArticleId);
            //modelBuilder.Entity<ListArticleCategory>().HasOne(q => q.Category).WithMany(q => q.ListArticles).HasForeignKey(q => q.CategoryId);
        }
    }
}

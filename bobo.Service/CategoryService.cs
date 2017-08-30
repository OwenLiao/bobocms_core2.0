using bobo.entity;
using bobo.orm.efcore;
using IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class CategoryService : BaseRepository<Category>,ICategoryService
    {
        public CategoryService(MyDbContext context)
            : base(context)
       { }
    }
}

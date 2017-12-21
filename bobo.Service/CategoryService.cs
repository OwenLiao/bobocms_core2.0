using bobo.entity;
using bobo.orm.efcore;
using bobo.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace bobo.Service
{
    public class CategoryService : BaseRepository<Category>,ICategoryService,IDependency
    {
        public CategoryService(MyDbContext context)
            : base(context)
        { }
    }
}

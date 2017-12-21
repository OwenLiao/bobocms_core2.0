using bobo.entity;
using bobo.orm.efcore;
using bobo.IService;
using System;
using System.Collections.Generic;
using System.Text;


namespace bobo.Service
{
    public class ArticleService : BaseRepository<Article>, IArticleService
    {
        public ArticleService(MyDbContext context)
            : base(context)
       { }

    }


}

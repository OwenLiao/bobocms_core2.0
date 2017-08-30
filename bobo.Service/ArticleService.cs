using bobo.entity;
using bobo.orm.efcore;
using IService;
using System;
using System.Collections.Generic;
using System.Text;


namespace DAL
{
    public class ArticleService : BaseRepository<Article>, IArticleService
    {
        public ArticleService(MyDbContext context)
            : base(context)
       { }

    }


}

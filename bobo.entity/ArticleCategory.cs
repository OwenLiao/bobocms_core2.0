﻿namespace bobo.entity
{
    public class ArticleCategory
    {
        public int Id
        {
            set;
            get;
        }
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

    //public class DetailArticleCategory : ArticleCategory { }
    // public class ListArticleCategory : ArticleCategory { }
}

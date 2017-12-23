using System;
using System.Collections.Generic;
using System.Text;

namespace bobo.orm.efcore
{
   public class BaseRepositoryFactory<T> where T:class
    {
        public static BaseRepository<T> GetCurrentBaseRepository()
        {

            BaseRepository<T> baseRepository= ContextFactory.CallContext.GetData("MyBaseRepository") as BaseRepository<T>;
            if (baseRepository == null)
            {
              //  baseRepository = new BaseRepository<T>();
                ContextFactory.CallContext.SetData("MyBaseRepository", baseRepository);
            }
            return baseRepository;


        }
    }
}

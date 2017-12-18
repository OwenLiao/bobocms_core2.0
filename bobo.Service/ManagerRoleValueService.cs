
using bobo.entity;
using IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
   public class ManagerRoleValueService : BaseRepository<ManagerRoleValue>, IManagerRoleValueService
    {
        public ManagerRoleValueService(MyDbContext context)
            : base(context)
       { }
    }
}

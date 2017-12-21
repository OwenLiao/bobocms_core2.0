using System;
using System.Collections.Generic;
using System.Text;
using bobo.entity;
using bobo.orm.efcore;
using bobo.IService;

namespace DAL
{
    public class SysChannelService : BaseRepository<SysChannel>, ISysChannelService
    {
        public SysChannelService(MyDbContext context)
            : base(context)
       { }
    }
}

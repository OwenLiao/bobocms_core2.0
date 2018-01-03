
using System;
using System.Collections.Generic;

namespace bobo.entity
{

    public partial class ManagerRoleValue
    {

        /// <summary>
        ///
        /// </summary>
     
        public int Id { get; set; }

        /// <summary>
        ///
        /// </summary>
     
        public Nullable<int> roleId { get; set; }

        /// <summary>
        ///
        /// </summary>
     
        public string ChannelName { get; set; }

        /// <summary>
        ///
        /// </summary>
     
        public Nullable<int> channelId { get; set; }

        /// <summary>
        ///
        /// </summary>
     
        public string ActionType { get; set; }
        
        public virtual ManagerRole ManagerRole { get; set; }
     
        
        public virtual ManagerSysChannel SysChannel { get; set; }
    }
}

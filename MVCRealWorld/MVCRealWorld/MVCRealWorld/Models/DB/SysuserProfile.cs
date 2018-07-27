using System;
using System.Collections.Generic;

namespace MVCRealWorld.Models.DB
{
    public partial class SysuserProfile
    {
        public int SysuserProfileId { get; set; }
        public int SysuserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int RowCreatedSysuserId { get; set; }
        public DateTime? RowCreatedDateTime { get; set; }
        public int RowModifiedSysuserId { get; set; }
        public DateTime? RowModifiedDateTime { get; set; }

        public Sysuser Sysuser { get; set; }
    }
}

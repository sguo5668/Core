using System;
using System.Collections.Generic;

namespace MVCRealWorld.Models.DB
{
    public partial class SysuserRole
    {
        public int SysuserRoleId { get; set; }
        public int SysuserId { get; set; }
        public int LookuproleId { get; set; }
        public bool? IsActive { get; set; }
        public int RowCreatedSysuserId { get; set; }
        public DateTime? RowCreatedDateTime { get; set; }
        public int RowModifiedSysuserId { get; set; }
        public DateTime? RowModifiedDateTime { get; set; }

        public Lookuprole Lookuprole { get; set; }
        public Sysuser Sysuser { get; set; }
    }
}

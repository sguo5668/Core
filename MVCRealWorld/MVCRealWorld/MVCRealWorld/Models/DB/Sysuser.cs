using System;
using System.Collections.Generic;

namespace MVCRealWorld.Models.DB
{
    public partial class Sysuser
    {
        public Sysuser()
        {
            SysuserProfile = new HashSet<SysuserProfile>();
            SysuserRole = new HashSet<SysuserRole>();
        }

        public int SysuserId { get; set; }
        public string LoginName { get; set; }
        public string PasswordEncryptedText { get; set; }
        public int RowCreatedSysuserId { get; set; }
        public DateTime? RowCreatedDateTime { get; set; }
        public int RowModifiedSysuserId { get; set; }
        public DateTime? RowModifiedDateTime { get; set; }

        public ICollection<SysuserProfile> SysuserProfile { get; set; }
        public ICollection<SysuserRole> SysuserRole { get; set; }
    }
}

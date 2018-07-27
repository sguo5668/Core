using System;
using System.Linq;
using MVCRealWorld.Models.DB;
 
using MVCRealWorld.Models.ViewModel;
using System.Collections.Generic;

namespace MVCRealWorld.Models.EntityManager
{
    public class UserManager
    {
        public void AddUserAccount(UserSignUpView user) {

            using (DemoDBContext db = new DemoDBContext()) {

                Sysuser SU = new Sysuser();
                SU.LoginName = user.LoginName;
                SU.PasswordEncryptedText = user.Password;
                SU.RowCreatedSysuserId = user.SYSUserID > 0 ? user.SYSUserID : 1;
                SU.RowModifiedSysuserId = user.SYSUserID > 0 ? user.SYSUserID : 1; ;
                SU.RowCreatedDateTime = DateTime.Now;
                SU.RowModifiedDateTime = DateTime.Now;

                db.Sysuser.Add(SU);
                db.SaveChanges();

                SysuserProfile SUP = new SysuserProfile();
                SUP.SysuserId = SU.SysuserId;
                SUP.FirstName = user.FirstName;
                SUP.LastName = user.LastName;
                SUP.Gender = user.Gender;
                SUP.RowCreatedSysuserId = user.SYSUserID > 0 ? user.SYSUserID : 1;
                SUP.RowModifiedSysuserId = user.SYSUserID > 0 ? user.SYSUserID : 1;
                SUP.RowCreatedDateTime = DateTime.Now;
                SUP.RowModifiedDateTime = DateTime.Now;

                db.SysuserProfile.Add(SUP);
                db.SaveChanges();


                if (user.LOOKUPRoleID > 0) {
                    SysuserRole SUR = new SysuserRole();
                    SUR.LookuproleId = user.LOOKUPRoleID;
                    SUR.SysuserId = user.SYSUserID;
                    SUR.IsActive = true;
                    SUR.RowCreatedSysuserId = user.SYSUserID > 0 ? user.SYSUserID : 1;
                    SUR.RowModifiedSysuserId = user.SYSUserID > 0 ? user.SYSUserID : 1;
                    SUR.RowCreatedDateTime = DateTime.Now;
                    SUR.RowModifiedDateTime = DateTime.Now;

                    db.SysuserRole.Add(SUR);
                    db.SaveChanges();
                }
            }
        }

        public void UpdateUserAccount(UserProfileView user) {

            using (DemoDBContext db = new DemoDBContext()) {
                using (var dbContextTransaction = db.Database.BeginTransaction()) {
                    try {

                        Sysuser SU = db.Sysuser.Find(user.SYSUserID);
                        SU.LoginName = user.LoginName;
                        SU.PasswordEncryptedText = user.Password;
                        SU.RowCreatedSysuserId = user.SYSUserID;
                        SU.RowModifiedSysuserId = user.SYSUserID;
                        SU.RowCreatedDateTime = DateTime.Now;
                        SU.RowModifiedDateTime = DateTime.Now;

                        db.SaveChanges();

                        var userProfile = db.SysuserProfile.Where(o => o.SysuserId == user.SYSUserID);
                        if (userProfile.Any()) {
                            SysuserProfile SUP = userProfile.FirstOrDefault();
                            SUP.SysuserId = SU.SysuserId;
                            SUP.FirstName = user.FirstName;
                            SUP.LastName = user.LastName;
                            SUP.Gender = user.Gender;
                            SUP.RowCreatedSysuserId = user.SYSUserID;
                            SUP.RowModifiedSysuserId = user.SYSUserID;
                            SUP.RowCreatedDateTime = DateTime.Now;
                            SUP.RowModifiedDateTime = DateTime.Now;

                            db.SaveChanges();
                        }

                        if (user.LOOKUPRoleID > 0) {
                            var userRole = db.SysuserRole.Where(o => o.SysuserId == user.SYSUserID);
                            SysuserRole SUR = null;
                            if (userRole.Any()) {
                                SUR = userRole.FirstOrDefault();
                                SUR.LookuproleId = user.LOOKUPRoleID;
                                SUR.SysuserId = user.SYSUserID;
                                SUR.IsActive = true;
                                SUR.RowCreatedSysuserId = user.SYSUserID;
                                SUR.RowModifiedSysuserId = user.SYSUserID;
                                SUR.RowCreatedDateTime = DateTime.Now;
                                SUR.RowModifiedDateTime = DateTime.Now;
                            }
                            else {
                                SUR = new SysuserRole();
                                SUR.LookuproleId = user.LOOKUPRoleID;
                                SUR.SysuserId = user.SYSUserID;
                                SUR.IsActive = true;
                                SUR.RowCreatedSysuserId = user.SYSUserID;
                                SUR.RowModifiedSysuserId = user.SYSUserID;
                                SUR.RowCreatedDateTime = DateTime.Now;
                                SUR.RowModifiedDateTime = DateTime.Now;
                                db.SysuserRole.Add(SUR);
                            }

                            db.SaveChanges();
                        }
                        dbContextTransaction.Commit();
                    }
                    catch {
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }
        public bool IsLoginNameExist(string loginName) {
            using (DemoDBContext db = new DemoDBContext()) {
                return db.Sysuser.Where(o => o.LoginName.Equals(loginName)).Any();
            }
        }

        public string GetUserPassword(string loginName) {
            using (DemoDBContext db = new DemoDBContext()) {
                var user = db.Sysuser.Where(o => o.LoginName.ToLower().Equals(loginName));
                if (user.Any())
                    return user.FirstOrDefault().PasswordEncryptedText;
                else
                    return string.Empty;
            }
        }

        public string[] GetRolesForUser(string loginName) {
            using (DemoDBContext db = new DemoDBContext()) {
                Sysuser SU = db.Sysuser.Where(o => o.LoginName.ToLower().Equals(loginName))?.FirstOrDefault();
                if (SU != null) {
                    var roles = from q in db.SysuserRole
                                join r in db.Lookuprole on q.LookuproleId equals r.LookuproleId
                                select r.RoleName;

                    if (roles != null) {
                        return roles.ToArray();
                    }
                }

                return new string[] { };
            }
        }
        public bool IsUserInRole(string loginName, string roleName) {
            using (DemoDBContext db = new DemoDBContext()) {
                Sysuser SU = db.Sysuser.Where(o => o.LoginName.ToLower().Equals(loginName))?.FirstOrDefault();
                if (SU != null) {
                    var roles = from q in db.SysuserRole
                                join r in db.Lookuprole on q.LookuproleId equals r.LookuproleId
                                where r.RoleName.Equals(roleName) && q.SysuserId.Equals(SU.SysuserId)
                                select r.RoleName;

                    if (roles != null) {
                        return roles.Any();
                    }
                }

                return false;
            }
        }

        public List<LOOKUPAvailableRole> GetAllRoles() {
            using (DemoDBContext db = new DemoDBContext()) {
                var roles = db.Lookuprole.Select(o => new LOOKUPAvailableRole {
                    LOOKUPRoleID = o.LookuproleId,
                    RoleName = o.RoleName,
                    RoleDescription = o.RoleDescription
                }).ToList();

                return roles;
            }
        }

        public int GetUserID(string loginName) {
            using (DemoDBContext db = new DemoDBContext()) {
                var user = db.Sysuser.Where(o => o.LoginName.Equals(loginName));
                if (user.Any())
                    return user.FirstOrDefault().SysuserId;
            }
            return 0;
        }
        public List<UserProfileView> GetAllUserProfiles() {
            List<UserProfileView> profiles = new List<UserProfileView>();
            using(DemoDBContext db = new DemoDBContext()) {
                UserProfileView UPV;
                var users = db.Sysuser.ToList();

                foreach(Sysuser u in db.Sysuser) {
                    UPV = new UserProfileView();
                    UPV.SYSUserID = u.SysuserId;
                    UPV.LoginName = u.LoginName;
                    UPV.Password = u.PasswordEncryptedText;

                    var SUP = db.SysuserProfile.Find(u.SysuserId);
                    if(SUP != null) {
                        UPV.FirstName = SUP.FirstName;
                        UPV.LastName = SUP.LastName;
                        UPV.Gender = SUP.Gender;
                    }

                    var SUR = db.SysuserRole.Where(o => o.SysuserId.Equals(u.SysuserId));
                    if (SUR.Any()) {
                        var userRole = SUR.FirstOrDefault();
                        UPV.LOOKUPRoleID = userRole.LookuproleId;
                        UPV.RoleName = userRole.Lookuprole.RoleName;
                        UPV.IsRoleActive = userRole.IsActive;
                    }                    

                    profiles.Add(UPV);
                }
            }

            return profiles;
        }

        public UserDataView GetUserDataView(string loginName) {
            UserDataView UDV = new UserDataView();
            List<UserProfileView> profiles = GetAllUserProfiles();
            List<LOOKUPAvailableRole> roles = GetAllRoles();

            int? userAssignedRoleID = 0, userID = 0;
            string userGender = string.Empty;

            userID = GetUserID(loginName);
            using (DemoDBContext db = new DemoDBContext()) {
                userAssignedRoleID = db.SysuserRole.Where(o => o.SysuserId == userID)?.FirstOrDefault().LookuproleId;
                userGender = db.SysuserProfile.Where(o => o.SysuserId == userID)?.FirstOrDefault().Gender;
            }

            List<Gender> genders = new List<Gender>();
            genders.Add(new Gender { Text = "Male", Value = "M" });
            genders.Add(new Gender { Text = "Female", Value = "F" });

            UDV.UserProfile = profiles;
            UDV.UserRoles = new UserRoles { SelectedRoleID = userAssignedRoleID, UserRoleList = roles };
            UDV.UserGender = new UserGender { SelectedGender = userGender, Gender = genders };
            return UDV;
        }

        public UserProfileView GetUserProfile(int userID) {
            UserProfileView UPV = new UserProfileView();
            using (DemoDBContext db = new DemoDBContext()) {
                var user = db.Sysuser.Find(userID);
                if (user != null) {
                    UPV.SYSUserID = user.SysuserId;
                    UPV.LoginName = user.LoginName;
                    UPV.Password = user.PasswordEncryptedText;

                    var SUP = db.SysuserProfile.Find(userID);
                    if (SUP != null) {
                        UPV.FirstName = SUP.FirstName;
                        UPV.LastName = SUP.LastName;
                        UPV.Gender = SUP.Gender;
                    }

                    var SUR = db.SysuserRole.Find(userID);
                    if (SUR != null) {
                        UPV.LOOKUPRoleID = SUR.LookuproleId;
                        UPV.RoleName = SUR.Lookuprole.RoleName;
                        UPV.IsRoleActive = SUR.IsActive;
                    }
                }
            }
            return UPV;
        }

        public void DeleteUser(int userID) {
            using (DemoDBContext db = new DemoDBContext()) {
                using (var dbContextTransaction = db.Database.BeginTransaction()) {
                    try {

                        var SUR = db.SysuserRole.Where(o => o.SysuserId == userID);
                        if (SUR.Any()) {
                            db.SysuserRole.Remove(SUR.FirstOrDefault());
                            db.SaveChanges();
                        }

                        var SUP = db.SysuserProfile.Where(o => o.SysuserId == userID);
                        if (SUP.Any()) {
                            db.SysuserProfile.Remove(SUP.FirstOrDefault());
                            db.SaveChanges();
                        }

                        var SU = db.Sysuser.Where(o => o.SysuserId == userID);
                        if (SU.Any()) {
                            db.Sysuser.Remove(SU.FirstOrDefault());
                            db.SaveChanges();
                        }

                        dbContextTransaction.Commit();
                    }
                    catch {
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }
    }
}
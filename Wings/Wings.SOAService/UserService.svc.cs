using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using Wings.Contracts;
using Wings.Core;
using Wings.DataObjects;
using Wings.Framework;

namespace Wings.SOAService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“UserService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 UserService.svc 或 UserService.svc.cs，然后开始调试。\

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class UserService : IUserService
    {
        private readonly IUserService userServiceImpl = ServiceLocator.Instance.GetService<IUserService>();
        public bool CheckPassword(string UserName, string Password)
        {
            try
            {
                return userServiceImpl.CheckPassword(UserName, Password);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }

        public bool IsExistsAccount(string Account)
        {
            try
            {
                return userServiceImpl.IsExistsAccount(Account);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }

        public DataObjects.UserDTOList CreateUser(DataObjects.UserDTOList user)
        {
            try
            {
                return userServiceImpl.CreateUser(user);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }

        public DataObjects.UserDTOList EditUsers(DataObjects.UserDTOList user)
        {
            try
            {
                return userServiceImpl.EditUsers(user);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public void EditUser(UserDTO uto)
        {
            try
            {
                userServiceImpl.EditUser(uto);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public void DeleteUser(DataObjects.IDList UserIDs)
        {
            try
            {
                userServiceImpl.DeleteUser(UserIDs);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }

        public DataObjects.UserDTO GetUserByID(Guid UserID)
        {
            try
            {
                return userServiceImpl.GetUserByID(UserID);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public UserDTOList GetUsersByGroupID(Guid GroupID)
        {
            try
            {
                return userServiceImpl.GetUsersByGroupID(GroupID);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public UserDTOList GetAllUsers()
        {
            try
            {
                return userServiceImpl.GetAllUsers();
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public DataObjects.DataObjectListWithPagination<DataObjects.UserDTOList> GetUsersByPage(DataObjects.Pagination pagination)
        {
            try
            {
                return userServiceImpl.GetUsersByPage(pagination);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }

        public List<Guid> GetUserPermission(Guid UserID,Guid WebID,bool IsBan)
        {
            try
            {
                return userServiceImpl.GetUserPermission(UserID, WebID,IsBan);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }

        public void AssignUserPermission(Guid userid,Guid webid, List<Guid> moduleids, bool IsBan)
        {
            try
            {
                userServiceImpl.AssignUserPermission(userid,webid, moduleids, IsBan);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }

        public DataObjects.RoleDTOList CreateRole(DataObjects.RoleDTOList role)
        {
            try
            {
                return userServiceImpl.CreateRole(role);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }

        public DataObjects.RoleDTOList EditRole(DataObjects.RoleDTOList role)
        {
            try
            {
                return userServiceImpl.EditRole(role);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }

        public void DeleteRole(DataObjects.IDList roleid)
        {
            try
            {
                userServiceImpl.DeleteRole(roleid);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }

        public DataObjects.UserDTOList GetUserListByRole(Guid roleid)
        {
            try
            {
                return userServiceImpl.GetUserListByRole(roleid);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }

        public void AssignRolePermission(Guid roleid, Guid webid, List<Guid> moduleids)
        {
            try
            {
                userServiceImpl.AssignRolePermission(roleid, webid, moduleids);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public List<Guid> GetRolePermissionIDS(Guid roleid, Guid webid)
        {
            try
            {
                return userServiceImpl.GetRolePermissionIDS(roleid, webid);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public DataObjects.DataObjectListWithPagination<DataObjects.RoleDTOList> GetRolesByPage(DataObjects.Pagination pagination)
        {
            try
            {
                return userServiceImpl.GetRolesByPage(pagination);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }

        public DataObjects.UserDTO AssignUserRole(Guid userid, DataObjects.IDList roleids)
        {
            try
            {
                return userServiceImpl.AssignUserRole(userid, roleids);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }

        public DataObjects.RoleDTO GetRoleByID(Guid roleid)
        {
            try
            {
                return userServiceImpl.GetRoleByID(roleid);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }

        public DataObjects.RoleDTOList GetAllRoles()
        {
            try
            {
                return userServiceImpl.GetAllRoles();
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }

        public DataObjects.UserDTO AssignUserGroup(Guid userid, DataObjects.IDList groupids)
        {
            try
            {
                return userServiceImpl.AssignUserGroup(userid, groupids);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }

        public DataObjects.GroupDTOList CreateGroup(DataObjects.GroupDTOList group)
        {
            try
            {
                return userServiceImpl.CreateGroup(group).ToViewModel();
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }

        public DataObjects.GroupDTOList EditGroup(DataObjects.GroupDTOList group)
        {
            try
            {
                return userServiceImpl.EditGroup(group);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }

        public void DeleteGroup(DataObjects.GroupDTOList groups)
        {
            try
            {
                userServiceImpl.DeleteGroup(groups);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }

        public DataObjects.GroupDTOList GetGroupParentID(Guid? id)
        {
            try
            {

                return userServiceImpl.GetGroupParentID(id);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }

        public DataObjects.GroupDTO GetGroupByID(Guid id)
        {
            try
            {

                return userServiceImpl.GetGroupByID(id);

            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }

        public DataObjects.GroupDTOList GetAllGroups()
        {
            try
            {
                return userServiceImpl.GetAllGroups();
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public void AssignGroupPermission(Guid groupid, Guid webid, List<Guid> moduleids)
        {
            try
            {
                userServiceImpl.AssignGroupPermission(groupid, webid, moduleids);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public List<Guid> GetGroupPermissionIDS(Guid groupid, Guid webid)
        {
            List<Guid> ids = null;
            try
            {
                return userServiceImpl.GetGroupPermissionIDS(groupid, webid);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public void Dispose()
        {
            userServiceImpl.Dispose();
        }


       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wings.Domain.Model;

namespace Wings.Domain.Services
{
    /// <summary>
    ///   领域相关处理
    /// </summary>
    public interface IDomainService
    {
        ///// <summary>
        ///// 给用户授予角色
        ///// </summary>
        ///// <param name="user"></param>
        ///// <param name="role"></param>
        //UserRole AssignUserRole(User user, List<Role> role);
        ///// <summary>
        ///// 守约用户站点
        ///// </summary>
        ///// <param name="user"></param>
        ///// <param name="web"></param>
        ///// <returns></returns>
        //WebUser AssignUserWeb(User user, List<Web> web);
        ///// <summary>
        ///// 为用户分配到相应的组里面去
        ///// </summary>
        ///// <param name="user"></param>
        ///// <param name="group"></param>
        ///// <returns></returns>
        //UserGroup AssignUserGroup(User user, List<Group> group);
        ///// <summary>
        ///// 为站点添加模块
        ///// </summary>
        ///// <param name="web"></param>
        ///// <param name="module"></param>
        ///// <returns></returns>
        //WebModule AssignWebModule(Web web, List<Module> module);

        ///// <summary>
        ///// 给角色指定模块
        ///// </summary>
        ///// <param name="role"></param>
        ///// <param name="modules"></param>
        ///// <returns></returns>
        //Permission GrantRolePermission(Role role, List<Module> modules);
        ///// <summary>
        ///// 用户组权限授权
        ///// </summary>
        ///// <param name="group"></param>
        ///// <param name="modules"></param>
        ///// <returns></returns>
        //Permission GrantGroupPermission(Group group, List<Module> modules);
        ///// <summary>
        ///// 用户可拥有指定的模块
        ///// </summary>
        ///// <param name="user"></param>
        ///// <param name="modules"></param>
        ///// <returns></returns>
        //Permission AssignUserAllowPermission(User user, List<Module> modules);
        ///// <summary>
        ///// 用户禁止拥有指定的模块
        ///// </summary>
        ///// <param name="user"></param>
        ///// <param name="modules"></param>
        ///// <returns></returns>
        //Permission AssignUserBanPermission(User user, List<Module> modules);
    }
}

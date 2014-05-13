using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wings.Domain.Model;
using Wings.Domain.Repositories;
using Wings.Domain.Specifications;

namespace Wings.Domain.Services
{
    public class DomainService : IDomainService
    {
        //private readonly IRepositoryContext repositoryContext;
        //private readonly IUserGroupRepository usergroupRepository;
        //private readonly IUserRoleRepository userroleRepository;
        //private readonly IUserRepository userRepository;
        //private readonly IWebRepository webRepository;
        //private readonly IWebUserRepository webuserRepository;
        //private readonly IGroupRepository groupRepository;
        //private readonly IModuleRepository moduleRepository;
        //private readonly IRoleRepository roleRepository;
        //private readonly IWebModuleRepositoty webmoduleRepository;
        //private readonly IPermissionRepository permissionRepository;
          
        //public DomainService(IRepositoryContext repositoryContext,
        //  IUserGroupRepository iusergroupRepository,
        //IUserRoleRepository iuserroleRepository,
        //    IRoleRepository roleRepository,
        //IUserRepository iuserRepository,
        //IWebRepository iwebRepository,
        //IWebUserRepository iwebuserRepository,
        //IGroupRepository igroupRepository,
        //IModuleRepository imoduleRepository,
        //    IWebModuleRepositoty webmoduleRepository,
        //    IPermissionRepository permissionRepository)
        //{
        //    this.groupRepository = igroupRepository;
        //    this.moduleRepository = imoduleRepository;
        //    this.usergroupRepository = iusergroupRepository;
        //    this.userRepository = iuserRepository;
        //    this.userroleRepository = iuserroleRepository;
        //    this.webRepository = iwebRepository;
        //    this.webuserRepository = iwebuserRepository;
        //    this.repositoryContext = repositoryContext;
        //    this.roleRepository = roleRepository;
        //    this.webmoduleRepository = webmoduleRepository;
        //    this.permissionRepository = permissionRepository;
        //}

        //public Model.UserRole AssignUserRole(Model.User user, List<Role> roles)
        //{
        //    if (user == null)
        //    {
        //        throw new ArgumentNullException("user");
        //    }
        //    if (roles == null)
        //    {
        //        throw new ArgumentNullException("roles");
        //    }
        //    var userroles = userroleRepository.Find(Specification<UserRole>.Eval(ur => ur.user.ID.Equals(user.ID)));
        //    //数据修正
        //    roles = roleRepository.FindAll(Specification<Role>.Eval(r => roles.Contains(r))).ToList();
        //    user = userRepository.Find(Specification<User>.Eval(u => u.ID.Equals(user.ID)));
        //    UserRole entity = new UserRole();
        //    if (userroles != null)
        //    {
        //        userroleRepository.Remove(userroles);
        //    }
        //    entity.user = user;
        //    entity.role = roles;
        //    entity.CreateDate = DateTime.Now;
        //    entity.EditDate = DateTime.Now;
            
        //    userroleRepository.Add(entity);
        //    repositoryContext.Commit();
        //    return entity;
        //}

        //public Model.WebUser AssignUserWeb(Model.User user, List<Model.Web> webs)
        //{
        //    if (user == null)
        //    {
        //        throw new ArgumentNullException("user");
        //    }
        //    if (webs == null)
        //    {
        //        throw new ArgumentNullException("webs");
        //    }
        //    var userwebs = webuserRepository.Find(Specification<WebUser>.Eval(ur => ur.user.ID.Equals(user.ID)));
        //    //数据修正
        //    webs = webRepository.FindAll(Specification<Web>.Eval(r => webs.Contains(r))).ToList();
        //    user = userRepository.Find(Specification<User>.Eval(u => u.ID.Equals(user.ID)));
        //    WebUser entity = new WebUser();
        //    if (userwebs != null)
        //    {
        //        webuserRepository.Remove(userwebs);
        //    }

        //    entity.user = user;
        //    entity.web = webs;
        //    entity.CreateDate = DateTime.Now;
        //    entity.EditDate = DateTime.Now;
        //    webuserRepository.Add(entity);
        //    repositoryContext.Commit();
        //    return entity;
        //}

        //public Model.UserGroup AssignUserGroup(Model.User user, List<Model.Group> groups)
        //{
        //    if (user == null)
        //    {
        //        throw new ArgumentNullException("user");
        //    }
        //    if (groups == null)
        //    {
        //        throw new ArgumentNullException("groups");
        //    }
        //    var usergroups = usergroupRepository.Find(Specification<UserGroup>.Eval(ur => ur.user.ID.Equals(user.ID)));
        //    //数据修正
        //    groups = groupRepository.FindAll(Specification<Group>.Eval(r => groups.Contains(r))).ToList();
        //    user = userRepository.Find(Specification<User>.Eval(u => u.ID.Equals(user.ID)));
        //    UserGroup entity = new UserGroup();
        //    if (usergroups != null)
        //    {
        //        usergroupRepository.Remove(usergroups);
        //    }
        //    entity.user = user;
        //    entity.group = groups;
        //    entity.CreateDate = DateTime.Now;
        //    entity.EditDate = DateTime.Now;
        //    usergroupRepository.Add(entity);
        //    repositoryContext.Commit();
        //    return entity;
        //}

        //public Model.WebModule AssignWebModule(Model.Web web, List<Model.Module> modules)
        //{
        //    if (web == null)
        //    {
        //        throw new ArgumentNullException("web");
        //    }
        //    if (modules == null)
        //    {
        //        throw new ArgumentNullException("modules");
        //    }
            
        //    var webmodules = webmoduleRepository .Find(Specification<WebModule>.Eval(ur => ur.web.ID.Equals(web.ID)));
        //    //数据修正
        //    modules = moduleRepository.FindAll(Specification<Module>.Eval(r => modules.Contains(r))).ToList();
        //    web = webRepository.Find(Specification<Web>.Eval(u => u.ID.Equals(web.ID)));
        //    WebModule entity = new WebModule();
        //    if (webmodules != null)
        //    {
        //        webmoduleRepository.Remove(webmodules);
        //    }
        //    entity.web = web;
        //    entity.Modules = modules;
        //    entity.CreateDate = DateTime.Now;
        //    entity.EditDate = DateTime.Now;
        //    webmoduleRepository.Add(entity);
        //    repositoryContext.Commit();
        //    return entity;
        //}


        //public Permission GrantRolePermission(Role role, List<Module> modules)
        //{
        //    if (role == null)
        //    {
        //        throw new ArgumentNullException("role");
        //    }
        //    if (modules == null)
        //    {
        //        throw new ArgumentNullException("modules");
        //    }
        //    role = roleRepository.Find(Specification<Role>.Eval(r => r.ID.Equals(role.ID)));
        //    modules = moduleRepository.GetAll(Specification<Module>.Eval(m => modules.Contains(m))).ToList();
        //    var permission = permissionRepository.Find(Specification<Permission>.Eval(p => p.OwnID == role.ID && p.Type == PermissionType.Role));
        //    if (permission != null)
        //    {
        //        permissionRepository.Remove(permission);
        //    }
        //    permission = new Permission();
        //    permission.IsAuthorization = true;
        //    permission.Modules = modules;
        //    permission.OwnID = role.ID;
        //    permission.Type = PermissionType.Role;
        //    permission.CreateDate = DateTime.Now;
        //    permission.EditDate=DateTime.Now;
        //    permissionRepository.Add(permission);
        //    repositoryContext.Commit();
        //    return permission;
        //}

        //public Permission GrantGroupPermission(Group group, List<Module> modules)
        //{
        //    if (group == null)
        //    {
        //        throw new ArgumentNullException("group");
        //    }
        //    if (modules == null)
        //    {
        //        throw new ArgumentNullException("modules");
        //    }
        //    group = groupRepository.Find(Specification<Group>.Eval(r => r.ID.Equals(group.ID)));
        //    modules = moduleRepository.GetAll(Specification<Module>.Eval(m => modules.Contains(m))).ToList();
        //    var permission = permissionRepository.Find(Specification<Permission>.Eval(p => p.OwnID == group.ID && p.Type == PermissionType.Group));
        //    if (permission != null)
        //    {
        //        permissionRepository.Remove(permission);
        //    }
        //    permission = new Permission();
        //    permission.IsAuthorization = true;
        //    permission.Modules = modules;
        //    permission.OwnID = group.ID;
        //    permission.Type = PermissionType.Group;
        //    permission.CreateDate = DateTime.Now;
        //    permission.EditDate = DateTime.Now;
        //    permissionRepository.Add(permission);
        //    repositoryContext.Commit();
        //    return permission;
        //}

        //public Permission AssignUserAllowPermission(User user, List<Module> modules)
        //{
        //    if (user == null)
        //    {
        //        throw new ArgumentNullException("user");
        //    }
        //    if (modules == null)
        //    {
        //        throw new ArgumentNullException("modules");
        //    }
        //    user = userRepository.Find(Specification<User>.Eval(r => r.ID.Equals(user.ID)));
        //    modules = moduleRepository.GetAll(Specification<Module>.Eval(m => modules.Contains(m))).ToList();
        //    var permission = permissionRepository.Find(Specification<Permission>.Eval(p => p.OwnID == user.ID && p.Type == PermissionType.User));
        //    if (permission != null)
        //    {
        //        permissionRepository.Remove(permission);
        //    }
        //    permission = new Permission();
        //    permission.IsAuthorization = true;
        //    permission.Modules = modules;
        //    permission.OwnID = user.ID;
        //    permission.Type = PermissionType.User;
        //    permission.CreateDate = DateTime.Now;
        //    permission.EditDate = DateTime.Now;
        //    permission.IsAuthorization = true;
        //    permissionRepository.Add(permission);
        //    repositoryContext.Commit();
        //    return permission;
        //}

        //public Permission AssignUserBanPermission(User user, List<Module> modules)
        //{
        //    if (user == null)
        //    {
        //        throw new ArgumentNullException("user");
        //    }
        //    if (modules == null)
        //    {
        //        throw new ArgumentNullException("modules");
        //    }
        //    user = userRepository.Find(Specification<User>.Eval(r => r.ID.Equals(user.ID)));
        //    modules = moduleRepository.GetAll(Specification<Module>.Eval(m => modules.Contains(m))).ToList();
        //    var permission = permissionRepository.Find(Specification<Permission>.Eval(p => p.OwnID == user.ID && p.Type == PermissionType.User));
        //    if (permission != null)
        //    {
        //        permissionRepository.Remove(permission);
        //    }
        //    permission = new Permission();
        //    permission.IsAuthorization = true;
        //    permission.Modules = modules;
        //    permission.OwnID = user.ID;
        //    permission.Type = PermissionType.User;
        //    permission.CreateDate = DateTime.Now;
        //    permission.EditDate = DateTime.Now;
        //    permission.IsAuthorization = false;
        //    permissionRepository.Add(permission);
        //    repositoryContext.Commit();
        //    return permission;
        //}
    }
}

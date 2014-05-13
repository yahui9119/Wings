using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Contracts;
using Wings.Domain.Repositories;
using Wings.DataObjects;
using Wings.Domain.Model;
using AutoMapper;
using Wings.Domain.Specifications;
using Wings.Framework;
using Wings.Framework.Transactions;
using Wings.Framework.Events.Bus;
using System.Linq.Expressions;

namespace Wings.Core.Implementation
{
    public class UserServiceImpl : CoreService, IUserService
    {

        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IGroupRepository groupRespository;
        private readonly IModuleRepository moduleRepository;
        private readonly IWebRepository webRepository;
        private readonly IEventBus bus;
        public UserServiceImpl(IRepositoryContext context,
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IGroupRepository groupRespository,
            IModuleRepository moduleReposiroty,
            IWebRepository webRepository,
            IEventBus bus)
            : base(context)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            this.groupRespository = groupRespository;
            this.moduleRepository = moduleReposiroty;
            this.webRepository = webRepository;
            this.bus = bus;
        }


        public bool CheckPassword(string UserName, string Password)
        {
            return userRepository.CheckPassword(UserName, Password);
        }

        public bool IsExistsAccount(string Account)
        {
            return userRepository.IsExistsAccount(Account);
        }

        public UserDTOList CreateUser(UserDTOList user)
        {
            user.ForEach(u =>
            {

            });
            return PerformCreateObjects<UserDTOList, UserDTO, User>(user, userRepository, udto =>
            {

            }, u =>
            {
                if (u.GroupIDS != null)
                {
                    List<Guid> groupids = new List<Guid>();
                    u.GroupIDS.ToList().ForEach(i =>
                    {
                        if (!string.IsNullOrEmpty(i))
                        {
                            Guid swap = Guid.Empty;
                            if (Guid.TryParse(i, out swap))
                            {
                                groupids.Add(swap);
                            }
                        }
                    });
                    List<GroupDTO> groups = new List<GroupDTO>();
                    u.Groups = groupRespository.GetAll(Specification<Group>.Eval(g => groupids.Contains(g.ID))).ToList();

                }

                // 角色保存
                //u.Roles = new List<Role>();
                if (u.RoleIDS != null)
                {
                    List<Guid> roleids = new List<Guid>();
                    u.RoleIDS.ToList().ForEach(i =>
                    {
                        if (!string.IsNullOrEmpty(i))
                        {
                            Guid swap = Guid.Empty;
                            if (Guid.TryParse(i, out swap))
                            {
                                roleids.Add(swap);
                            }
                        }
                    });
                    List<RoleDTO> roles = new List<RoleDTO>();

                    u.Roles = roleRepository.GetAll(Specification<Role>.Eval(g => roleids.Contains(g.ID))).ToList();
                }
                //u.Webs = new List<Web>();
                // 站点保存
                if (u.WebIDS != null)
                {
                    List<Guid> webids = new List<Guid>();
                    u.WebIDS.ToList().ForEach(i =>
                    {
                        if (!string.IsNullOrEmpty(i))
                        {
                            Guid swap = Guid.Empty;
                            if (Guid.TryParse(i, out swap))
                            {
                                webids.Add(swap);
                            }
                        }
                    });
                    List<WebDTO> webs = new List<WebDTO>();
                    u.Webs = webRepository.GetAll(Specification<Web>.Eval(g => webids.Contains(g.ID))).ToList();

                }
            }).ToViewModel();
            //return PerformUpdateObjects<UserDTOList, UserDTO, User>(, userRepository, uto => uto.ID, (u, uto) =>
            //{
            //    //u.Groups = new List<Group>();
            //    // 部门保存

            //}).ToViewModel();

        }
        /// <summary>
        /// 修改用户的个人信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserDTOList EditUsers(UserDTOList user)
        {
            return PerformUpdateObjects<UserDTOList, UserDTO, User>(user, userRepository, uto => uto.ID, (u, uto) =>
            {

            }).ToViewModel();
        }

        public void EditUser(UserDTO uto)
        {
            Guid id = Guid.Parse(uto.ID);
            var u = userRepository.Find(Specification<User>.Eval(uu=>uu.ID.Equals(id)));
            if (!string.IsNullOrEmpty(uto.Account))
            {
                u.Account = uto.Account;
            }
            if (!string.IsNullOrEmpty(uto.Address))
            {
                u.Address = uto.Address;
            }
            if (!string.IsNullOrEmpty(uto.ALiWangWang))
            {
                u.ALiWangWang = uto.ALiWangWang;
            }
            if (uto.Birthday != null)
            {

                u.Birthday = uto.Birthday;

            }
            u.EditDate = DateTime.Now;
            if (!string.IsNullOrEmpty(uto.Email))
            {
                u.Email = uto.Email;
            }
            if (!uto.IsMan)
            {
                u.IsMan = uto.IsMan;
            }
            if (!string.IsNullOrEmpty(uto.Password))
            {
                u.Password = uto.Password;
            }
            if (!string.IsNullOrEmpty(uto.PhoneNum))
            {
                u.PhoneNum = uto.PhoneNum;
            }
            if (!string.IsNullOrEmpty(uto.QQ))
            {
                u.QQ = uto.QQ;
            }
            if (!string.IsNullOrEmpty(uto.RealName))
            {
                u.RealName = uto.RealName;
            }
            if (uto.Version != null)
            {
                u.Version = uto.Version;
            }
            if (!string.IsNullOrEmpty(uto.Zip))
            {
                u.Zip = uto.Zip;
            }
            u.Status = (Domain.Model.Status)uto.Status;
            
            // 部门保存
            if (uto.GroupIDS != null)
            {
                u.Groups.Clear() ;
                List<Guid> groupids = new List<Guid>();
                uto.GroupIDS.ToList().ForEach(i =>
                {
                    if (!string.IsNullOrEmpty(i))
                    {
                        Guid swap = Guid.Empty;
                        if (Guid.TryParse(i, out swap))
                        {
                            groupids.Add(swap);
                        }
                    }
                });
                u.Groups = groupRespository.GetAll(Specification<Group>.Eval(g => groupids.Contains(g.ID))).ToList();
            }

            // 角色保存

            if (uto.RoleIDS != null)
            {
                u.Roles.Clear();
                List<Guid> roleids = new List<Guid>();
                uto.RoleIDS.ToList().ForEach(i =>
                {
                    if (!string.IsNullOrEmpty(i))
                    {
                        Guid swap = Guid.Empty;
                        if (Guid.TryParse(i, out swap))
                        {
                            roleids.Add(swap);
                        }
                    }
                });
                u.Roles = roleRepository.GetAll(Specification<Role>.Eval(g => roleids.Contains(g.ID))).ToList();
            }

            // 站点保存
            if (uto.WebIDS != null)
            {
                u.Webs.Clear();
                List<Guid> webids = new List<Guid>();
                uto.WebIDS.ToList().ForEach(i =>
                {
                    if (!string.IsNullOrEmpty(i))
                    {
                        Guid swap = Guid.Empty;
                        if (Guid.TryParse(i, out swap))
                        {
                            webids.Add(swap);
                        }
                    }
                });
                u.Webs = webRepository.GetAll(Specification<Web>.Eval(g => webids.Contains(g.ID))).ToList();
            }

            userRepository.Update(u);
            Context.Commit();
        }
        /// <summary>
        /// 批量删除用户
        /// </summary>
        /// <param name="UserIDs"></param>
        public void DeleteUser(UserDTOList Users)
        {
            PerformUpdateObjects<UserDTOList, UserDTO, User>(Users, userRepository, uto => uto.ID, (u, uto) =>
            {
                u.Status = Wings.Domain.Model.Status.Deleted;
            });
        }
        /// <summary>
        /// 通过id获取单个用户
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public UserDTO GetUserByID(Guid UserID)
        {
            return Mapper.Map<User, UserDTO>(userRepository.GetByKey(UserID)).ToViewModel();
        }
        /// <summary>
        /// 通过分组id获取用户列表
        /// </summary>
        /// <param name="GroupID"></param>
        /// <returns></returns>
        public UserDTOList GetUsersByGroupID(Guid GroupID)
        {
            UserDTOList userlist = new UserDTOList();
            var group = groupRespository.Get(Specification<Group>.Eval(g => g.ID.Equals(GroupID)));
            if (group != null && group.Users != null && group.Users.Count > 0)
            {
                group.Users.ForEach(u =>
                {
                    userlist.Add(Mapper.Map<User, UserDTO>(u));
                });

            }
            return userlist.ToViewModel();

        }
        /// <summary>
        /// 获取所有的用户
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public UserDTOList GetAllUsers()
        {
            UserDTOList userdtolist = new UserDTOList();
            var users = userRepository.GetAll(Specification<User>.Eval(u => u.Status.Equals(Wings.Domain.Model.Status.Active)));
            foreach (var item in users)
            {
                userdtolist.Add(Mapper.Map<User, UserDTO>(item));
            }
            return userdtolist.ToViewModel();
        }
        /// <summary>
        /// 根据分页获取用户信息
        /// </summary>
        /// <param name="pagination">用户的创建时间筛选</param>
        /// <returns></returns>
        public DataObjectListWithPagination<UserDTOList> GetUsersByPage(Pagination pagination)
        {

            Specification<User> starttime = Specification<User>.Eval(u => pagination.StartTime != null ? u.CreateDate > pagination.StartTime : true);
            Specification<User> endtime = Specification<User>.Eval(u => pagination.EndTime != null ? u.CreateDate < pagination.EndTime : true);
            Specification<User> likeword = Specification<User>.Eval(u => (!string.IsNullOrEmpty(pagination.LikeWord) ? u.RealName.Contains(pagination.LikeWord) : true));
            Expression<Func<User, dynamic>> sortPredicate;
            var property = typeof(User).GetProperty(pagination.sort);
            if (property != null)
            {
                sortPredicate = r => property.Name;
            }
            else
            {
                sortPredicate = r => r.CreateDate;
            }
            PagedResult<User> rolepages = userRepository.GetAll(starttime.And(endtime).And(likeword), sortPredicate
            , pagination.order.ToLower() == "desc" ? SortOrder.Descending : SortOrder.Ascending, pagination.page, pagination.rows);
            DataObjectListWithPagination<UserDTOList> result = new DataObjectListWithPagination<UserDTOList>();
            if (rolepages == null)
            {
                return result;
            }
            if (rolepages.Data != null)
            {
                rolepages.Data.ForEach(u =>
                {
                    result.DataObjectList.Add(Mapper.Map<User, UserDTO>(u));
                });
            }
            else { result.DataObjectList = new UserDTOList(); }
            result.DataObjectList = result.DataObjectList.ToViewModel();
            result.pagination.page = rolepages.PageNumber;
            result.pagination.rows = rolepages.PageSize;
            result.pagination.TotalPages = rolepages.TotalPages;
            result.pagination.TotalRecords = rolepages.TotalRecords;
            return result;
        }
        /// <summary>
        /// 获取用户选择已经拥有的权限
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public ModuleDTOList GetUserPermission(Guid UserID)
        {
            ModuleDTOList mdtolist = new ModuleDTOList();
            var user = userRepository.Find(Specification<User>.Eval(u => u.Status == Wings.Domain.Model.Status.Active).And(Specification<User>.Eval(u => u.ID.Equals(UserID))));
            if (user == null)
            {
                return null;
            }
            //添加用户组模块
            user.Groups.ForEach(g =>
            {
                if (g.Status.Equals(Wings.Domain.Model.Status.Active))
                {
                    g.Modules.ForEach(
                        m =>
                        {
                            mdtolist.Add(Mapper.Map<Module, ModuleDTO>(m));
                        });
                }
            });
            user.Roles.FindAll(t => t.Status == Wings.Domain.Model.Status.Active).ForEach(r =>
            {
                r.Modules.FindAll(m => m.Status == Wings.Domain.Model.Status.Active).ForEach(m =>
                {
                    mdtolist.Add(Mapper.Map<Module, ModuleDTO>(m));
                });
            });
            user.ModuleAllow.FindAll(m => m.Status == Wings.Domain.Model.Status.Active).ForEach(m =>
            {
                mdtolist.Add(Mapper.Map<Module, ModuleDTO>(m));
            });
            //去除重复项
            ModuleDTOList resultmdtolist = new ModuleDTOList();
            mdtolist.GroupBy(m => m.ID).ToList().ForEach(m =>
            {
                resultmdtolist.Add(mdtolist.Find(mt => mt.ID == m.Key));
            });
            //去除禁用的
            user.ModuleBan.FindAll(m => m.Status == Wings.Domain.Model.Status.Active).ForEach(m =>
            {
                if (resultmdtolist.Contains(Mapper.Map<Module, ModuleDTO>(m)))
                {
                    resultmdtolist.Remove(Mapper.Map<Module, ModuleDTO>(m));
                }
            });
            return resultmdtolist.ToViewModel();
        }
        /// <summary>
        /// 授予用户权限
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="moduleids"></param>
        /// <param name="IsBan">是否禁用</param>
        /// <returns></returns>
        public void AssignUserPermission(Guid userid, Guid webid, List<Guid> moduleids, bool IsBan)
        {

            List<Module> modules = moduleRepository.FindAll(Specification<Module>.Eval(m => moduleids.Contains(m.ID)).And(Specification<Module>.Eval(m => m.Web.ID.Equals(webid)))).ToList();
            var user = userRepository.Find(Specification<User>.Eval(u => u.ID.Equals(userid)));
            if (IsBan)//是否是禁用
            {
                var tempBanmodules = user.ModuleBan;
                var tempAllowmodules = user.ModuleAllow;
                user.ModuleAllow = null;
                user.ModuleBan = null;
                if (tempBanmodules != null)
                {
                    tempBanmodules.RemoveAll(t => t.Web.ID.Equals(webid));
                }
                //去除特设允许
                if (tempAllowmodules != null)
                {
                    tempAllowmodules.RemoveAll(t => moduleids.Contains(t.ID));
                }
                tempBanmodules.AddRange(modules);
                user.ModuleBan = tempBanmodules;
                user.ModuleAllow = tempAllowmodules;
            }
            else
            {
                var tempmodules = user.ModuleAllow;

                user.ModuleAllow = null;
                if (tempmodules != null)
                {
                    tempmodules.RemoveAll(t => t.Web.ID.Equals(webid));
                }
                List<Guid> HaveYet = new List<Guid>();
                if (user.Roles != null)
                {
                    user.Roles.ForEach(r =>
                    {
                        //if (r.Status == Wings.Domain.Model.Status.Active)
                        {
                            if (r.Modules != null)
                            {
                                r.Modules.ForEach(m =>
                                {
                                    if (m.Web.ID.Equals(webid))
                                    {
                                        HaveYet.Add(m.ID);
                                    }
                                });
                            }
                        }
                    }
                    );
                }
                if (user.Groups != null)
                {
                    user.Groups.ForEach(g =>
                    {
                        //if (g.Status == Wings.Domain.Model.Status.Active)
                        {
                            if (g.Modules != null)
                            {
                                g.Modules.ForEach(m =>
                                {
                                    if (m.Web.ID.Equals(webid))
                                    {
                                        HaveYet.Add(m.ID);
                                    }
                                });
                            }
                        }
                    });
                }
                if (modules != null)
                {
                    modules.RemoveAll(m => HaveYet.Contains(m.ID));
                    tempmodules.AddRange(modules);
                }
                user.ModuleAllow = tempmodules;
            }
            userRepository.Update(user);
            //调用用户权限跟新
            user.UpdatePermission(webid);
            Context.Commit();//提交当前事务单元
            bus.Commit();
        }
        /// <summary>
        /// 获取用户权限
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="webid"></param>
        /// <returns></returns>
        /// 

        public List<Guid> GetUserPermission(Guid userid, Guid webid, bool IsBan)
        {
            List<Guid> moduleids = new List<Guid>();
            var user = userRepository.Find(Specification<User>.Eval(u => u.ID.Equals(userid)));



            if (user == null)
            {
                return moduleids;
            }
            if (IsBan)
            {
                if (user.ModuleBan != null)
                {
                    user.ModuleBan.ForEach(m =>
                    {
                        moduleids.Add(m.ID);
                    });
                }
            }
            else
            {
                if (user.ModuleAllow != null)
                {
                    user.ModuleAllow.ForEach(m =>
                    {
                        moduleids.Add(m.ID);
                    }
                    );
                }
                if (user.Roles != null)
                {
                    user.Roles.ForEach(r =>
                    {
                        //if (r.Status == Wings.Domain.Model.Status.Active)
                        {
                            if (r.Modules != null)
                            {
                                r.Modules.ForEach(m =>
                                {
                                    if (m.Web.ID.Equals(webid))
                                    {
                                        moduleids.Add(m.ID);
                                    }
                                });
                            }
                        }
                    }
                    );
                }
                if (user.Groups != null)
                {
                    user.Groups.ForEach(g =>
                    {
                        //if (g.Status == Wings.Domain.Model.Status.Active)
                        {
                            if (g.Modules != null)
                            {
                                g.Modules.ForEach(m =>
                                {
                                    if (m.Web.ID.Equals(webid))
                                    {
                                        moduleids.Add(m.ID);
                                    }
                                });
                            }
                        }
                    });
                }
            }
            return moduleids;
        }
        public RoleDTOList CreateRole(RoleDTOList roles)
        {
            return PerformCreateObjects<RoleDTOList, RoleDTO, Role>(roles, roleRepository).ToViewModel();
        }

        public RoleDTOList EditRole(RoleDTOList roles)
        {
            return PerformUpdateObjects<RoleDTOList, RoleDTO, Role>(roles, roleRepository, r => r.ID, (r, rdto) =>
            {
                r.Name = rdto.Name;
                r.Description = rdto.Description;
                r.EditDate = DateTime.Now;
                r.Status = (Domain.Model.Status)rdto.Status;
            }).ToViewModel();
        }

        public void DeleteRole(RoleDTOList roles)
        {
            PerformUpdateObjects<RoleDTOList, RoleDTO, Role>(roles, roleRepository, r => r.ID, (r, rdto) =>
            {
                r.Status = Wings.Domain.Model.Status.Deleted;
            });
        }
        /// <summary>
        /// 获取此角色下的所有用户
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public UserDTOList GetUserListByRole(Guid roleid)
        {
            var role = roleRepository.Find(Specification<Role>.Eval(r => r.ID.Equals(roleid)));
            if (role == null)
            {
                return null;
            }
            List<User> users = role.Users;
            UserDTOList udtoList = new UserDTOList();
            users.ForEach(u =>
            {
                if (u.Status == Wings.Domain.Model.Status.Active)//只获取有效数据
                {
                    udtoList.Add(Mapper.Map<User, UserDTO>(u));
                }
            });
            return udtoList.ToViewModel();
        }
        /// <summary>
        /// 赋予角色权限
        /// </summary>
        /// <param name="roleid"></param>
        /// <param name="moduleids"></param>
        /// <returns></returns>
        public void AssignRolePermission(Guid roleid, Guid webid, List<Guid> moduleids)
        {
            List<Guid> mids = moduleids;
            var role = roleRepository.Find(Specification<Role>.Eval(r => r.ID.Equals(roleid)));
            var oldmodule = role.Modules;
            role.Modules = null;
            oldmodule.RemoveAll(m => m.Web.ID.Equals(webid));

            var newmodules = moduleRepository.GetAll(Specification<Module>.Eval(m => (mids.Contains(m.ID)))
                .And(Specification<Module>.Eval(m => m.Web.ID.Equals(webid)))).ToList();
            oldmodule.AddRange(newmodules);
            role.Modules = oldmodule;
            roleRepository.Update(role);
            Context.Commit();
        }
        public List<Guid> GetRolePermissionIDS(Guid roleid, Guid webid)
        {
            List<Guid> ids = null;
            var role = roleRepository.Get(Specification<Role>.Eval(r => r.ID.Equals(roleid)));
            var permission = moduleRepository.FindAll((Specification<Module>.Eval(m => m.Web.ID.Equals(webid))));

            if (permission != null)
            {
                permission = permission.Where(p => p.Roles.Contains(role));
                ids = new List<Guid>();
                permission.ToList().ForEach(p =>
                {
                    ids.Add(p.ID);
                });
            }
            return ids;
        }
        public DataObjectListWithPagination<RoleDTOList> GetRolesByPage(Pagination pagination)
        {
            Specification<Role> starttime = Specification<Role>.Eval(u => pagination.StartTime != null ? u.CreateDate > pagination.StartTime : true);
            Specification<Role> endtime = Specification<Role>.Eval(u => pagination.EndTime != null ? u.CreateDate < pagination.EndTime : true);
            Specification<Role> likeword = Specification<Role>.Eval(u => (!string.IsNullOrEmpty(pagination.LikeWord) ? u.Name.Contains(pagination.LikeWord) : true));
            Expression<Func<Role, dynamic>> sortPredicate;
            var property = typeof(Role).GetProperty(pagination.sort);
            if (property != null)
            {
                sortPredicate = r => property.Name;
            }
            else
            {
                sortPredicate = r => r.CreateDate;
            }
            PagedResult<Role> rolepages = roleRepository.GetAll(starttime.And(endtime).And(likeword), sortPredicate
            , pagination.order.ToLower() == "desc" ? SortOrder.Descending : SortOrder.Ascending, pagination.page, pagination.rows);
            DataObjectListWithPagination<RoleDTOList> result = new DataObjectListWithPagination<RoleDTOList>();
            if (rolepages == null)
            {
                return result;
            }
            if (rolepages.Data != null)
            {
                rolepages.Data.ForEach(u =>
                {
                    result.DataObjectList.Add(Mapper.Map<Role, RoleDTO>(u));
                });
            }
            else { result.DataObjectList = new RoleDTOList(); }
            result.DataObjectList = result.DataObjectList.ToViewModel();
            result.pagination.page = rolepages.PageNumber;
            result.pagination.rows = rolepages.PageSize;
            result.pagination.TotalPages = rolepages.TotalPages;
            result.pagination.TotalRecords = rolepages.TotalRecords;
            return result;
        }

        public UserDTO AssignUserRole(Guid userid, IDList roleids)
        {
            List<Guid> rids = new List<Guid>();
            roleids.ForEach(m =>
            {
                Guid id = new Guid();
                if (Guid.TryParse(m, out id))
                {
                    rids.Add(id);
                }

            });
            var user = userRepository.Find(Specification<User>.Eval(u => u.ID.Equals(userid)));
            using (ITransactionCoordinator coordinator = TransactionCoordinatorFactory.Create(Context, bus))
            {

                if (user == null)
                {
                    throw new NullReferenceException("无法找指定的用户");
                }
                var roles = roleRepository.GetAll((Specification<Role>.Eval(r => rids.Contains(r.ID)))).ToList(); ;
                user.Roles = roles;
                userRepository.Update(user);
                user.UpdateRole();
                coordinator.Commit();
            }
            return Mapper.Map<User, UserDTO>(user).ToViewModel();
        }

        /// <summary>
        /// 通过id获取单个角色
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public RoleDTO GetRoleByID(Guid roleid)
        {
            return Mapper.Map<Role, RoleDTO>(roleRepository.Get(Specification<Role>.Eval(r => r.ID.Equals(roleid)))).ToViewModule();
        }
        /// <summary>
        /// 获取所有的角色
        /// </summary>
        /// <returns></returns>
        public RoleDTOList GetAllRoles()
        {
            RoleDTOList roledtolist = new RoleDTOList();
            var roles = roleRepository.GetAll();
            roles.ToList().ForEach(r =>
            {
                roledtolist.Add(Mapper.Map<Role, RoleDTO>(r));
            });
            return roledtolist.ToViewModel();
        }

        public UserDTO AssignUserGroup(Guid userid, IDList groupids)
        {

            List<Guid> gids = new List<Guid>();
            groupids.ForEach(m =>
            {
                Guid id = new Guid();
                if (Guid.TryParse(m, out id))
                {
                    gids.Add(id);
                }

            });
            var user = userRepository.Find(Specification<User>.Eval(u => u.ID.Equals(userid)));
            using (ITransactionCoordinator coordinator = TransactionCoordinatorFactory.Create(Context, bus))
            {

                if (user == null)
                {
                    throw new NullReferenceException("无法找指定的用户");
                }

                var groups = groupRespository.GetAll((Specification<Group>.Eval(g => gids.Contains(g.ID)))).ToList();
                user.Groups = groups;
                userRepository.Update(user);
                user.UpdateGroup();
                coordinator.Commit();
            }
            return Mapper.Map<User, UserDTO>(user);
        }

        public GroupDTOList CreateGroup(GroupDTOList groups)
        {
            GroupDTOList result = PerformCreateObjects<GroupDTOList, GroupDTO, Group>(groups, groupRespository);
            return PerformUpdateObjects<GroupDTOList, GroupDTO, Group>(result, groupRespository, g => g.ID, (g, gdto) =>
            {
                var thisdto = groups[result.IndexOf(gdto)];
                g.ParentGroup = !thisdto._parentId.HasValue ? null : groupRespository.Find(Specification<Group>.Eval(gg => gg.ID.Equals(thisdto._parentId.Value)));
            }).ToViewModel();
        }

        public GroupDTOList EditGroup(GroupDTOList groups)
        {
            return PerformUpdateObjects<GroupDTOList, GroupDTO, Group>(groups, groupRespository, g => g.ID, (g, gdto) =>
            {
                g.Index = gdto.Index;
                g.Name = gdto.Name;
                g.Description = gdto.Description;
                g.EditDate = DateTime.Now;
                g.ParentGroup = !gdto._parentId.HasValue ? null : groupRespository.Find(Specification<Group>.Eval(gg => gg.ID.Equals(gdto._parentId.Value)));
            }).ToViewModel();
        }

        public void DeleteGroup(GroupDTOList groups)
        {
            PerformUpdateObjects<GroupDTOList, GroupDTO, Group>(groups, groupRespository, g => g.ID, (g, gdto) =>
            {
                g.Status = Wings.Domain.Model.Status.Deleted;
            });
        }



        /// <summary>
        /// 根据父id获取分组
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public GroupDTOList GetGroupParentID(Guid? id)
        {

            var groups = groupRespository.FindAll(Specification<Group>.Eval(g => g.ParentGroup.ID.Equals(id))).ToList();
            GroupDTOList gdtolist = GetGroupChild(groups);
            return gdtolist;
        }
        /// <summary>
        /// 获取所有分组 树形结构
        /// </summary>
        /// <param name="groups"></param>
        /// <returns></returns>
        private GroupDTOList GetGroupChild(List<Group> groups)
        {
            GroupDTOList gdtolist = new GroupDTOList();
            if (groups == null)
            {
                return gdtolist;
            }
            else
            {
                groups.OrderByDescending(g => g.Index);
                groups.ForEach(g =>
                {
                    GroupDTO dto = new GroupDTO();
                    dto.CreateDate = g.CreateDate;
                    dto.Creator = g.Creator;
                    dto.Description = g.Description;
                    dto.EditDate = g.EditDate;
                    dto.ID = g.ID.ToString();
                    dto.Name = g.Name;
                    dto.Index = g.Index;
                    dto.ParentID = g.ParentGroup != null ? g.ParentGroup.ID : Guid.Empty;
                    dto.ParentName = g.ParentGroup != null ? g.ParentGroup.Name : string.Empty;
                    dto.Status = (Wings.DataObjects.Status)g.Status;

                    if (g.ChildGroup != null && g.ChildGroup.Count > 0)
                    {
                        dto.ChildGroup = GetGroupChild(g.ChildGroup);
                    }
                    gdtolist.Add(dto);
                });
            }
            return gdtolist;
        }
        /// <summary>
        /// 根据分组id获取分组信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GroupDTO GetGroupByID(Guid id)
        {
            var group = groupRespository.Find(Specification<Group>.Eval(g => g.ID.Equals(id)));
            var groupdto = Mapper.Map<Group, GroupDTO>(group);
            GroupDTO dto = new GroupDTO();
            dto.ID = groupdto.ID;
            dto.Index = groupdto.Index;
            dto.Name = groupdto.Name;
            dto.Description = groupdto.Description;
            dto.ParentGroup = new GroupDTO();
            if (groupdto.ParentGroup != null)
            {
                dto.ParentID = Guid.Parse(groupdto.ParentGroup.ID);
                dto.ParentName = groupdto.ParentGroup.Name; ;
            }

            dto.Status = groupdto.Status;
            dto.Version = groupdto.Version;
            return dto;
        }
        /// <summary>
        /// 获取所有分组信息
        /// </summary>
        /// <returns></returns>
        public GroupDTOList GetAllGroups()
        {
            var groups = groupRespository.FindAll().ToList();
            GroupDTOList gdtolist = GetGroupChild(groups);
            return gdtolist;
        }
        /// <summary>
        /// 赋予用户组权限
        /// </summary>
        /// <param name="groupid"></param>
        /// <param name="moduleids"></param>
        /// <returns></returns>
        public void AssignGroupPermission(Guid groupid, Guid webid, List<Guid> moduleids)
        {
            List<Guid> mids = moduleids;

            var group = groupRespository.Find(Specification<Group>.Eval(r => r.ID.Equals(groupid)));
            var oldmodule = group.Modules;
            group.Modules = null;
            oldmodule.RemoveAll(m => m.Web.ID.Equals(webid));

            var newmodules = moduleRepository.GetAll(Specification<Module>.Eval(m => (mids.Contains(m.ID)))
                .And(Specification<Module>.Eval(m => m.Web.ID.Equals(webid)))).ToList();
            oldmodule.AddRange(newmodules);
            group.Modules = oldmodule;
            groupRespository.Update(group);
            Context.Commit();
        }
        public List<Guid> GetGroupPermissionIDS(Guid groupid, Guid webid)
        {
            List<Guid> ids = null;
            var group = groupRespository.Get(Specification<Group>.Eval(r => r.ID.Equals(groupid)));
            var permission = moduleRepository.FindAll((Specification<Module>.Eval(m => m.Web.ID.Equals(webid))));

            if (permission != null)
            {
                permission = permission.Where(p => p.Groups.Contains(group));
                ids = new List<Guid>();
                permission.ToList().ForEach(p =>
                {
                    ids.Add(p.ID);
                });
            }
            return ids;
        }
        /// <summary>
        /// 获取所有的有效站点模块
        /// </summary>
        /// <returns></returns>
        public WebDTOList GetAllWebModules()
        {
            var webs = webRepository.GetAll(Specification<Web>.Eval(w => w.Status == Wings.Domain.Model.Status.Active));
            WebDTOList wdtolist = new WebDTOList();
            foreach (var item in webs)
            {
                item.Modules.RemoveAll(m => m.Status != Wings.Domain.Model.Status.Active);
            }
            foreach (var item in webs)
            {
                wdtolist.Add(Mapper.Map<Web, WebDTO>(item));
            }
            return wdtolist;
        }


        public void DeleteUser(IDList UserIDs)
        {
            UserDTOList users = new UserDTOList();
            Guid temp = Guid.Empty;
            UserIDs.ForEach(
                r =>
                {
                    if (Guid.TryParse(r, out temp))
                    {
                        users.Add(new UserDTO() { ID = temp.ToString() });
                    }
                }
                );
            PerformUpdateObjects<UserDTOList, UserDTO, User>(users, userRepository, g => g.ID, (g, gdto) =>
            {
                g.Status = Wings.Domain.Model.Status.Deleted;
            });
        }

        public void DeleteRole(IDList roleid)
        {
            RoleDTOList roles = new RoleDTOList();
            Guid temp = Guid.Empty;
            roleid.ForEach(
                r =>
                {
                    if (Guid.TryParse(r, out temp))
                    {
                        roles.Add(new RoleDTO() { ID = temp.ToString() });
                    }
                }
                );
            PerformUpdateObjects<RoleDTOList, RoleDTO, Role>(roles, roleRepository, g => g.ID, (g, gdto) =>
            {
                g.Status = Wings.Domain.Model.Status.Deleted;
            });
        }
    }
}

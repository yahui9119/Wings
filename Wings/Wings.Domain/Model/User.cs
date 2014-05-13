using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Events;
using Wings.Framework.Plugin.Contracts;

namespace Wings.Domain.Model
{
    /// <summary>
    /// 表示用户领域的值的对象
    /// </summary>
    public class User : AggregateRoot
    {
        public User()
        {
            Roles = new List<Role>();
            Webs = new List<Web>();
            Groups = new List<Group>();
        }
        /// <summary>
        /// 分组id集合
        /// 忽略
        /// </summary>
        public string[] GroupIDS { get; set; }
        /// <summary>
        /// 角色id集合
        /// 忽略
        /// </summary>
        public string[] RoleIDS { get; set; }
        /// <summary>
        /// 站点id集合
        /// 忽略
        /// </summary>
        public string[] WebIDS { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public virtual string Account { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public virtual string RealName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public virtual string Password { get; set; }
        /// <summary>
        /// 性别是否是男人
        /// </summary>
        public virtual bool IsMan { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public virtual DateTime Birthday { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public virtual string Email { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public virtual string PhoneNum { get; set; }
        /// <summary>
        /// 邮编号码
        /// </summary>
        public virtual string Zip { get; set; }
        /// <summary>
        /// QQ账号
        /// </summary>
        public virtual string QQ { get; set; }
        /// <summary>
        /// 阿里旺旺账号
        /// </summary>
        public virtual string ALiWangWang { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public virtual string Address { get; set; }
        /// <summary>
        /// 最后登陆时间
        /// </summary>
        public virtual DateTime LastloginTime { get; set; }
        /// <summary>
        /// 用户拥有角色列表 多对多
        /// </summary>
        public virtual List<Role> Roles { get; set; }
        /// <summary>
        /// 用户拥有站点列表 多对多
        /// </summary>
        public virtual List<Web> Webs { get; set; }
        /// <summary>
        /// 用户所属部门列表 多对多
        /// </summary>
        public virtual List<Group> Groups { get; set; }
        /// <summary>
        /// 此用户拥有的模块
        /// </summary>
        public virtual List<Module> ModuleAllow { get; set; }
        /// <summary>
        /// 此用户禁止使用的模块
        /// </summary>
        public virtual List<Module> ModuleBan { get; set; }
        /// <summary>
        /// 已经拥有的角色
        /// </summary>
        public string HaveRoles
        {
            get
            {
                string result = string.Empty;
                Roles.ForEach(r =>
                {
                    if (r.Status == Status.Active)
                    {
                        result += string.Format("{0},", r.Name);
                    }

                });
                if (!string.IsNullOrWhiteSpace(result))
                {
                    result = result.Substring(0, result.Length - 1);
                }
                return result;
            }
        }
        /// <summary>
        /// 已经拥有的分组
        /// </summary>
        public string HaveGroups
        {
            get
            {
                string result = string.Empty;
                Groups.ForEach(r =>
                {
                    if (r.Status == Status.Active)
                    {
                        result += string.Format("{0},", r.Name);
                    }

                });
                if (!string.IsNullOrWhiteSpace(result))
                {
                    result = result.Substring(0, result.Length - 1);
                }
                return result;
            }
        }
        /// <summary>
        /// 已经拥有的站点
        /// </summary>
        public string HaveWebs
        {
            get
            {
                string result = string.Empty;
                Webs.ForEach(r =>
                {
                    if (r.Status == Status.Active)
                    {
                        result += string.Format("{0},", r.Name);
                    }

                });
                if (!string.IsNullOrWhiteSpace(result))
                {
                    result = result.Substring(0, result.Length - 1);
                }
                return result;
            }
        }
        /// <summary>
        /// 禁用该用户
        /// </summary>
        public void Forbidden()
        {
            Events.DomainEvent.Publish<UserForbiddenEvent>(new UserForbiddenEvent(this) { ForbinddenDate = DateTime.Now, UserEmail = Email, UserID = this.ID, UserName = this.RealName });
        }
        /// <summary>
        /// 启用该帐号
        /// </summary>
        public void Enabled()
        {
            Events.DomainEvent.Publish<UserEnabledEvent>(new UserEnabledEvent(this) { EnableDate = DateTime.Now, UserEmail = Email, UserID = this.ID, UserName = this.RealName });
        }
        /// <summary>
        /// 角色更新
        /// </summary>
        public void UpdateRole()
        {
            Events.DomainEvent.Publish<UserRoleUpdateEvent>(new UserRoleUpdateEvent(this) { Email = Email, UpdateTime = DateTime.Now, UserID = this.ID, UserName = this.RealName });
        }
        /// <summary>
        /// 分组更新
        /// </summary>
        public void UpdateGroup()
        {
            DomainEvent.Publish<UserGroupUpdateEvent>(new UserGroupUpdateEvent(this)
            {
                UpdateTime = DateTime.Now,
                Email = this.Email,
                UserID = this.ID,
                UserName = this.RealName
            });
        }
        /// <summary>
        /// 使用站点更新
        /// </summary>
        public void UpdateWeb()
        {
            DomainEvent.Publish<UserWebUpdateEvent>(new UserWebUpdateEvent(this)
            {
                UpdateTime = DateTime.Now,
                Email = this.Email,
                UserID = this.ID,
                UserName = this.RealName
            });
        }
        /// <summary>
        /// 用户权限更新
        /// </summary>
        public void UpdatePermission(Guid WebID)
        {
            DomainEvent.Publish<UserUpdatePermissionEvent>(new UserUpdatePermissionEvent(this)
            {
                UserID = this.ID,
                WebID = WebID,
              
            });
        }
        /// <summary>
        /// 用户上线
        /// </summary>
        /// <param name="WebID"></param>
        public void Online(Guid WebID)
        {
            DomainEvent.Publish<UserOnlineEvent>(new UserOnlineEvent(this)
            {
                UserID = this.ID,
                WebID = WebID
            });
        }
        /// <summary>
        /// 用户下线
        /// </summary>
        /// <param name="WebID"></param>
        public void OffLine(Guid WebID)
        {
            DomainEvent.Publish<UserOfflineEvent>(new UserOfflineEvent(this)
            {
                UserID = this.ID,
                WebID = WebID
            });
        }
    }
}

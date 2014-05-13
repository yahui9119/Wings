using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;
using Wings.Framework;

namespace Wings.Domain.Repositories
{
    public interface IUserRepository:IRepository<User>
    {
        /// <summary>
        /// 帐户名是否已经存在
        /// </summary>
        /// <param name="account">帐户名</param>
        /// <returns></returns>
        bool IsExistsAccount(string account);
        /// <summary>
        /// 邮箱是否已经存在
        /// </summary>
        /// <param name="Email">邮箱</param>
        /// <returns></returns>
        bool EmailExists(string Email);
        /// <summary>
        /// 验证密码是否正确
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="Password">密码</param>
        /// <returns></returns>
        bool CheckPassword(string UserName, string Password);
        /// <summary>
        /// 通过邮件获取用户
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        User GetUserByEmail(string Email);
        /// <summary>
        /// 更新用户信息 并且更新用户的分组角色使用站点等信息
        /// </summary>
        /// <param name="user"></param>
        /// <param name="GroupIDS"></param>
        /// <param name="RoleIDS"></param>
        /// <param name="WebIDS"></param>
        /// <returns></returns>
        void EditUser(User user, List<Guid> GroupIDS, List<Guid> RoleIDS, List<Guid> WebIDS);
        ///// <summary>
        ///// 根据分页信息获取用户列表
        ///// </summary>
        ///// <param name="pageNum"></param>
        ///// <param name="pageSize"></param>
        ///// <param name="TotalPages"></param>
        ///// <param name="groupid"></param>
        ///// <param name="likeUserName"></param>
        ///// <returns></returns>
        //PagedResult<User> GetUsersWithPaged(int pageNum , int pageSize , out int TotalPages,int? groupid,string likeUserName);
    }
}

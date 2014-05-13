using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;

namespace Wings.Domain.Repositories
{
    /// <summary>
    /// 标示模块的仓库接口
    /// </summary>
    public interface IModuleRepository:IRepository<Module>
    {
        /// <summary>
        /// 获取此站点用户可用的所有模块
        /// 此数据是权限过滤后的
        /// </summary>
        /// <param name="webuser"></param>
        /// <returns></returns>
        List<Module> GetModuleByWebUser(User webuser);
    }
}

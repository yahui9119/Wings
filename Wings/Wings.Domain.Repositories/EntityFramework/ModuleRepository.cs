using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;

namespace Wings.Domain.Repositories.EntityFramework
{
    public class ModuleRepository : EntityFrameworkRepository<Model.Module>, IModuleRepository
    {
        public ModuleRepository(IRepositoryContext Context)
            : base(Context)
        {

        }
        /// <summary>
        /// 获取此站点用户可用的所有模块
        /// 只涉及单个领域
        /// 此数据是此操作未经过权限过滤
        /// </summary>
        /// <param name="webuser"></param>
        /// <returns></returns>
        public List<Module> GetModuleByWebUser(User user)
        {
            return null;
        }
    }
}

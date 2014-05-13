using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;

namespace Wings.Domain.Repositories
{
    /// <summary>
    /// 标示站点的仓库接口
    /// </summary>
    public interface IWebRepository : IRepository<Web>
    {
        /// <summary>
        /// 站点名字是否已经存在
        /// </summary>
        /// <param name="webname"></param>
        /// <returns></returns>
        bool WebNameExists(string webname);
        /// <summary>
        /// 站点域名是否已经存在
        /// </summary>
        /// <param name="webdomain"></param>
        /// <returns></returns>
        bool WebDomainExists(string webdomain);
    }
}

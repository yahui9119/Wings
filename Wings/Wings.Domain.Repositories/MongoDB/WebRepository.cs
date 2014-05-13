using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;
using Wings.Domain.Repositories.Specifications;

namespace Wings.Domain.Repositories.MongoDB
{
    public class WebRepository : MongoDBRepository<Web>, IWebRepository
    {
        public WebRepository(IRepositoryContext context) : base(context) { }
        /// <summary>
        /// 站点名字是否已经存在
        /// </summary>
        /// <param name="webname"></param>
        /// <returns></returns>
        public bool WebNameExists(string webname)
        {
            return Exists(new WebNameEqualsSpecification(webname));
        }
        /// <summary>
        /// 站点域名是否已经存在
        /// </summary>
        /// <param name="webdomain"></param>
        /// <returns></returns>
        public bool WebDomainExists(string webdomain)
        {
            return Exists(new WebDomainEqualsSpecification(webdomain));
        }
    }
}

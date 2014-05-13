using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Domain.Repositories.Specifications
{
    internal class WebDomainEqualsSpecification:WebStringEqualsSpecification
    {
        public WebDomainEqualsSpecification(string domain)
            : base(domain)
        {
 
        }
        public override System.Linq.Expressions.Expression<Func<Model.Web, bool>> GetExpression()
        {
            return w => w.Domain == Value;
        }
    }
}

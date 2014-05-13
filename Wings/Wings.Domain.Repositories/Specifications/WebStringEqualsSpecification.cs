using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;
using Wings.Domain.Specifications;

namespace Wings.Domain.Repositories.Specifications
{
    public class WebStringEqualsSpecification : Specification<Web>
    {
        public string Value { get;set; }
        public WebStringEqualsSpecification(string value)
        {
            this.Value = value;
        }
        public override System.Linq.Expressions.Expression<Func<Web, bool>> GetExpression()
        {
            throw new NotImplementedException();
        }
    }
}

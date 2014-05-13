using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;
using Wings.Domain.Specifications;

namespace Wings.Domain.Repositories.Specifications
{
    internal class UserNameEqualsSpecification:Specification<User>
    {
        public string Name { get; set; }
        public UserNameEqualsSpecification(string name)
        {
            this.Name = name;
        }
        public override System.Linq.Expressions.Expression<Func<User, bool>> GetExpression()
        {
            return u => u.Account == this.Name;
        }
    }
}

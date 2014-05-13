using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;
using Wings.Domain.Specifications;

namespace Wings.Domain.Repositories.Specifications
{
    public class UserPasswordEqualsSpecification : Specification<User>
    {
        public string Password { get; set; }
        public UserPasswordEqualsSpecification(string password)
        {
            this.Password = password;
        }
        public override System.Linq.Expressions.Expression<Func<User, bool>> GetExpression()
        {
            return u => u.Password == Password;
        }
    }
}

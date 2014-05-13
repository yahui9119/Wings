using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;
using Wings.Domain.Specifications;

namespace Wings.Domain.Repositories.Specifications
{
    /// <summary>
    /// 用户邮箱相等的规约
    /// </summary>
    internal class UserEmailEqualsSpecification : Specification<User>
    {
        private string Email { get; set; }
        public UserEmailEqualsSpecification(string email)
        {
            this.Email = email;
        }
        public override System.Linq.Expressions.Expression<Func<User, bool>> GetExpression()
        {
            return u => u.Email == Email;
        }
    }
}

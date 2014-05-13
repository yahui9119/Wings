using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;
using Wings.Domain.Repositories.Specifications;
using Wings.Domain.Specifications;
using Wings.Framework;

namespace Wings.Domain.Repositories.EntityFramework
{
    public class UserRepository : EntityFrameworkRepository<User>, IUserRepository
    {
        public UserRepository(IRepositoryContext context) : base(context) { }
        public bool IsExistsAccount(string UserName)
        {
            return Exists(new UserNameEqualsSpecification(UserName));
        }

        public bool EmailExists(string Email)
        {
            return Exists(new UserEmailEqualsSpecification(Email));
        }

        public bool CheckPassword(string UserName, string Password)
        {
            return Exists(new UserNameEqualsSpecification(UserName).And(new UserPasswordEqualsSpecification(Password)));
        }

        public User GetUserByEmail(string Email)
        {
            return Get(new UserEmailEqualsSpecification(Email));
        }


        public void EditUser(User user, List<Guid> GroupIDS, List<Guid> RoleIDS, List<Guid> WebIDS)
        {
            DoUpdate(user);
        }
    }
}

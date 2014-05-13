using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wings.Domain.Repositories.EntityFramework;
using Wings.Domain.Model;
using Wings.Domain.Specifications;
using System.Collections.Generic;

namespace Wings.Repository.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InitDB()
        {
            List<string> strs=new List<string> ();
            strs.Add("test11");
            strs.Add("test22");

            EntityFrameworkRepositoryContext context = new EntityFrameworkRepositoryContext();
            UserRepository ur = new UserRepository(context);
            User user = new User();
            user.Account = "test11";
            user.RealName = "张三";
            user.Password = "123456";
            user.PhoneNum = "15267189886";
            user.QQ = "123123123";
            user.Zip = "450000";
            user.Address = "sdfd";
            user.CreateDate = DateTime.Now;
            user.Creator = Guid.NewGuid();
            user.EditDate = DateTime.Now;
            user.Email = "sdf@df.com";
            user.LastloginTime = DateTime.Now;
            ur.Add(user);

            var getuser = ur.GetUserByEmail("sdf@df.com");
            var user2 = ur.Find(Specification<User>.Eval(u => strs.Contains(u.Account)));
            
           
            //user2.Name = "test11";
            //user2.Password = "123456";
            //user2.PhoneNum = "15267189886";
            //user2.QQ = "123123123";
            //user2.Zip = "450000";
            //user2.Address = "sdfd";
            //user2.CreateDate = DateTime.Now;
            //user2.Creator = Guid.NewGuid();
            //user2.EditDate = DateTime.Now;
            //user2.Email = "sdf@df.com";
            //user2.LastloginTime = DateTime.Now;
            //ur.Remove(user2);
            //Wings.Domain.Model.Action parentaction = new Domain.Model.Action();
            //parentaction.Status = Status.Active;
            //parentaction.IsButton = true;
            //parentaction.ActionName = "testaction";
            //parentaction.Description = "sdfsdf";
            //parentaction.Controller = "testcontroller";
            //parentaction.CreateDate = DateTime.Now;
            //parentaction.EditDate = DateTime.Now;
            // EntityFrameworkRepositoryContext context = new EntityFrameworkRepositoryContext();
            //ActionRepository repository = new ActionRepository(context);
            //parentaction.ChildAction = new List<Domain.Model.Action>();
            //for (int i = 0; i < 2; i++)
            //{
            //    Wings.Domain.Model.Action action = new Domain.Model.Action();
            //    action.Description = "sdfsdf"+i;
            //    action.Status = Status.Active;
            //    action.IsButton = true;
            //    action.ActionName = "testaction"+i;
            //    action.Controller = "testcontroller"+i;
            //    action.CreateDate = DateTime.Now;
            //    action.EditDate = DateTime.Now;
            //    parentaction.ChildAction.Add(action);
               
            //}

            //repository.Add(parentaction);
            //context.Commit();
            //context.Dispose();
            //EntityFrameworkRepositoryContext context1 = new EntityFrameworkRepositoryContext();
            //ActionRepository repository1 = new ActionRepository(context1);
            //var resul2 = repository1.Get(Specification<Wings.Domain.Model.Action>.Eval(a => a.ID == Guid.Parse("CBFC2460-0FAF-E311-BEE4-D067E50A7F1D")));
            ////List<Wings.Domain.Model.Action> result = (List<Wings.Domain.Model.Action>)repository1.GetAll(Specification<Wings.Domain.Model.Action>.Eval(a => a.ChildAction.Count != 0));
           
            ////var actionget = result.Find(a => a.ID.Equals(Guid.Parse("CBFC2460-0FAF-E311-BEE4-D067E50A7F1D")));
            ////actionget.ActionName = "1111111111111";
            ////actionget.ChildAction.RemoveAt(0);
           
            ////repository1.Update(actionget);
            ////context1.Commit();
        }
    }
}

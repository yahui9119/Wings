using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wings.Domain.Model;
using Wings.Domain.Repositories.EntityFramework;
using System.Collections.Generic;

namespace Wings.Repository.Test.EntityFramework
{
    [TestClass]
    public class inittest
    {
        [TestMethod]
        public void TestMethod1()
        {
            ////Wings.Domain.Model.Action parentaction = new Domain.Model.Action();
            //parentaction.Status = Status.Active;
            //parentaction.IsButton = true;
            //parentaction.ActionName = "testaction";
            //parentaction.Description = "sdfsdf";
            //parentaction.Controller = "testcontroller";
            //parentaction.CreateDate = DateTime.Now;
            //parentaction.EditDate = DateTime.Now;
            //EntityFrameworkRepositoryContext context = new EntityFrameworkRepositoryContext();
            ////ActionRepository repository = new ActionRepository(context);
            ////parentaction.ChildAction = new List<Domain.Model.Action>();
            ////for (int i = 0; i < 2; i++)
            ////{
            ////    Wings.Domain.Model.Action action = new Domain.Model.Action();
            ////    action.Description = "sdfsdf" + i;
            ////    action.Status = Status.Active;
            ////    action.IsButton = true;
            ////    action.ActionName = "testaction" + i;
            ////    action.Controller = "testcontroller" + i;
            ////    action.CreateDate = DateTime.Now;
            ////    action.EditDate = DateTime.Now;
            ////    parentaction.ChildAction.Add(action);

            ////}
            ////repository.Add(parentaction);
            //context.Commit();
            //context.Dispose();
           
        }
    }
}

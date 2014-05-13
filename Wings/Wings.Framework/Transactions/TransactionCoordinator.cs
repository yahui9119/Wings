using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Framework.Infrastructure;

namespace Wings.Framework.Transactions
{
    public abstract class TransactionCoordinator : DisposableObject,ITransactionCoordinator
    {
        private readonly List<IUnitOfWork> managedUnitOfWorks = new List<IUnitOfWork>();
        public TransactionCoordinator(params IUnitOfWork[] unitOfWorks)
        {
            if (unitOfWorks != null && unitOfWorks.Length > 0)
            {
                foreach (var item in unitOfWorks)   
                {
                    managedUnitOfWorks.Add(item);
                }
            }
        }
        protected override void Dispose(bool disposing)
        {
             
        }


        #region IUnitOfWork Members
        public bool DistributedTransactionSupported
        {
            get { return true; }//没有意义
        }

        public bool Committed
        {
            get { return true; }//没有意义
        }

        public virtual void Commit()
        {
            if (managedUnitOfWorks.Count > 0)
            {
                foreach (var item in managedUnitOfWorks)
                {
                    item.Commit();
                }
            }
        }
        #endregion

        public virtual void Rollback()//基本上没有意义
        {
 
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Framework.Infrastructure;

namespace Wings.Framework.Transactions
{
    public static class TransactionCoordinatorFactory
    {
        public static ITransactionCoordinator Create(params IUnitOfWork[] args)
        {
            bool ret = true;
            foreach (var arg in args)
                ret = ret && arg.DistributedTransactionSupported;
            if (ret)
                return new DistributedTransactionCoordinator(args);
            else
                return new SuppressedTransactionCoordinator(args);
        }
    }
}

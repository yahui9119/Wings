using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Framework.Infrastructure;

namespace Wings.Framework.Transactions
{
    internal sealed class SuppressedTransactionCoordinator : TransactionCoordinator
    {
        public SuppressedTransactionCoordinator(params IUnitOfWork[] unitOfWorks)
            : base(unitOfWorks)
        {
        }

    }
}

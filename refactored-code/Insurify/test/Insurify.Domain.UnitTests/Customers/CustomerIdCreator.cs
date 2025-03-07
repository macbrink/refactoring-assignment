using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurify.Domain.Abstractions;

namespace Insurify.Domain.UnitTests.Customers
{
    class CustomerIdCreator : IIdCreator
    {
        public int CreateId()
        {
            return 100;
        }
    }
}

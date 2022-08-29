using Apache.Ignite.Core.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Liquid.DistributedCache.Ignite
{
    public interface IIgniteClientFactory
    {
        IIgniteClient GetClient();
    }
}

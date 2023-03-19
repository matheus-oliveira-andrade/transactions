using System.Collections.Generic;

namespace Seed.Domain.Interfaces.Bus
{
    public interface IBusService
    {
        void PublishBatch(string exchangeName, string key, List<string> messages);
    }
}
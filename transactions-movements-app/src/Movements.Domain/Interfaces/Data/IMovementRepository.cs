using System.Threading;
using System.Threading.Tasks;
using Movements.Domain.Entities;

namespace Movements.Domain.Interfaces.Data
{
    public interface IMovementRepository
    {
        public Task AddAsync(Movement movement, CancellationToken cancellationToken = default);
    }
}
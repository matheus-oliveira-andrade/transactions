﻿using System.Threading.Tasks;
using Movements.Domain.Entities;
using Movements.Domain.Interfaces.Data;
using Movements.Infrastructure.Data.Models;

namespace Movements.Infrastructure.Data.Repositories
{
    public class MovementRepository : IMovementRepository
    {
        private readonly MovementsDbContext _movementsDbContext;

        public MovementRepository(MovementsDbContext movementsDbContext)
        {
            _movementsDbContext = movementsDbContext;
        }

        public async Task AddAsync(Movement movement)
        {
            _movementsDbContext.Movements.Add(movement.ToModel());
            await _movementsDbContext.SaveChangesAsync();
        }
    }
    
    
}
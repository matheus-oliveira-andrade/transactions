﻿using System;

namespace Movements.Domain.Entities
{
    public class Movement
    {
        public Guid Id { get; }
        public Guid TransactionId { get; }
        public string AccountId { get; }
        public DateTime Date { get; }
        public decimal Value { get; }
        public string Category { get; }
        public string Description { get; }

        public Movement(
            Guid transactionId,
            string accountId,
            DateTime date,
            decimal value,
            string category,
            string description)
        {
            if (transactionId == Guid.Empty)
                throw new ArgumentException("Can not be empty", nameof(transactionId));

            if (date == DateTime.MinValue || date == DateTime.MaxValue)
                throw new ArgumentException($"Can not be ${DateTime.MinValue} or ${DateTime.MaxValue}", nameof(date));

            if (value <= 0)
                throw new ArgumentException("Can not be less or equals 0", nameof(value));

            Id = Guid.NewGuid();
            TransactionId = transactionId;
            AccountId = accountId ?? throw new ArgumentNullException(nameof(accountId));
            Date = date;
            Value = value;
            Category = category ?? throw new ArgumentNullException(nameof(category));
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }
    }
}
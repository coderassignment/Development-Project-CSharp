using System;
using System.Collections.Generic;
using Sparcpoint.Domain.SeedWork;

namespace Sparcpoint.Domain.ValueObjects
{
    public class Money : ValueObject
    {
        public decimal Amount { get; }

        public Currency Currency { get; }

        public Money(decimal amount, Currency currency = null)
        {
            Amount = amount;
            Currency = currency;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return Amount;
            yield return Currency;
        }
    }
}

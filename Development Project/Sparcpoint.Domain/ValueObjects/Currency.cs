using System;
using System.Collections.Generic;
using Sparcpoint.Domain.SeedWork;
using UAL.ATW.Core.Extensions;

namespace Sparcpoint.Domain.ValueObjects
{
    public class Currency : ValueObject
    {
        public static readonly Currency USD = new Currency("USD", "$");

        public string Code { get; private set; }
        public string Symbol { get; private set; }

        public Currency()
        {
            this.Code = USD.Code;
            this.Symbol = USD.Symbol;
        }

        public Currency(string code, string symbol)
        {
            // EVAL: Defensive Coding - Can be replaced with a Guard Library
            PreConditions.StringNotNullOrWhitespace(code, nameof(code));
            PreConditions.StringNotNullOrWhitespace(symbol, nameof(symbol));

            if (code.Length != 3)
            {
                throw new ArgumentException("Currency Code is not valid");
            }

            this.Code = code;
            this.Symbol = symbol;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return Code;
            yield return Symbol;
        }
    }
}

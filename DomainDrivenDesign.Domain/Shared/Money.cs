using DomainDrivenDesign.Domain.Shared.DomainDrivenDesign.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Shared
{
    public sealed record Money
    {
        public decimal Amount { get; }
        public Currency Currency { get; }

        public Money(decimal amount, Currency currency)
        {
            if (currency == null || currency == Currency.None)
                throw new ArgumentException("Geçersiz para birimi.");

            Amount = amount;
            Currency = currency;
        }

        public static Money Zero(Currency currency) => new(0, currency);

        public bool IsZero() => Amount == 0;

        public static Money operator +(Money a, Money b)
        {
            EnsureSameCurrency(a, b);
            return new Money(a.Amount + b.Amount, a.Currency);
        }

        public static Money operator -(Money a, Money b)
        {
            EnsureSameCurrency(a, b);
            return new Money(a.Amount - b.Amount, a.Currency);
        }

        public static Money operator *(Money a, decimal multiplier)
        {
            return new Money(a.Amount * multiplier, a.Currency);
        }

        public static Money operator /(Money a, decimal divisor)
        {
            if (divisor == 0)
                throw new DivideByZeroException("Bölme sıfıra yapılamaz.");

            return new Money(a.Amount / divisor, a.Currency);
        }

        private static void EnsureSameCurrency(Money a, Money b)
        {
            if (a.Currency != b.Currency)
                throw new InvalidOperationException("Farklı para birimleriyle işlem yapılamaz.");
        }

        public override string ToString() => $"{Amount} {Currency}";
    }

}

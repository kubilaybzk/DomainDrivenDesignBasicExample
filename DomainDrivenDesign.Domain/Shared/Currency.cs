using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Shared
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace DomainDrivenDesign.Domain.Shared
    {
        public sealed class Currency : IEquatable<Currency>
        {
            public string Code { get; }

            // Özel flag ile boş string'e izin veriyoruz sadece None için
            private Currency(string code, bool allowEmpty = false)
            {
                if (!allowEmpty && string.IsNullOrWhiteSpace(code))
                    throw new ArgumentException("Para birimi boş olamaz.", nameof(code));

                Code = code.ToUpperInvariant();
            }

            // Sabit tanımlar
            public static readonly Currency None = new("", allowEmpty: true);
            public static readonly Currency Usd = new("USD");
            public static readonly Currency Try = new("TRY");
            public static readonly Currency Eur = new("EUR");

            // Tüm tanımlı Currency’leri liste halinde sunuyoruz
            public static readonly IReadOnlyCollection<Currency> All = new[] { Usd, Try, Eur };

            // Koddan Currency nesnesi üretmek için helper
            public static Currency FromCode(string code)
            {
                if (string.IsNullOrWhiteSpace(code))
                    throw new ArgumentException("Para birimi kodu boş olamaz.", nameof(code));

                return All.FirstOrDefault(c => c.Code == code.ToUpperInvariant())
                       ?? throw new ArgumentException($"Tanımsız para birimi: {code}");
            }

            // Eşitlik tanımı
            public bool Equals(Currency? other) => other?.Code == Code;

            public override bool Equals(object? obj) => obj is Currency other && Equals(other);

            public override int GetHashCode() => Code.GetHashCode();

            public override string ToString() => Code;
        }
    }


}

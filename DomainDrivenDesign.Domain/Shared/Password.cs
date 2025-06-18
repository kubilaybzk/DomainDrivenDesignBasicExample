using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Shared
{
    public sealed record Password
    {
        public string Value { get; init; }

        public Password(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Password alanı boş olamaz!");

            if (value.Length < 6)
                throw new ArgumentException("Password en az 6 karakter olmalıdır.");

            if (!value.Any(char.IsUpper))
                throw new ArgumentException("Password en az 1 büyük harf içermelidir.");

            if (!value.Any(char.IsLower))
                throw new ArgumentException("Password en az 1 küçük harf içermelidir.");

            if (!value.Any(ch => !char.IsLetterOrDigit(ch)))
                throw new ArgumentException("Password en az 1 özel karakter içermelidir (örnek: !, @, #, vs).");

            Value = value;
        }
    }

}

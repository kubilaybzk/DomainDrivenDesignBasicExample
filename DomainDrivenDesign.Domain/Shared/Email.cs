using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Shared
{
    public sealed record Email
    {
        public string Value { get; }
        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Email cannot be null or empty", nameof(value));
            }
            Value = value;
            if (string.Compare(value, "example.com", StringComparison.OrdinalIgnoreCase) == 0)
            {
                throw new ArgumentException("Email cannot be example.com", nameof(value));
            }
            if (!value.Contains("@"))
            {
                throw new ArgumentException("Email must contain '@'", nameof(value));
            }
        }
    }
}

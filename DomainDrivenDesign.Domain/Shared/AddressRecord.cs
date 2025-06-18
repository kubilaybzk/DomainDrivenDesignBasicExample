using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Shared
{
    public sealed record AddressRecord(
       string Country,
       string City,
       string Street,
       string FullAddress,
       string PostalCode);
}

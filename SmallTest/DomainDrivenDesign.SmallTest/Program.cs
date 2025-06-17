using System;

namespace SmallTest.DomainDrivenDesign.SmallTest
{
    public sealed class Address
    {
        public string Street { get; }
        public string City { get; }
        public string Country { get; }

        public Address(string street, string city, string country)
        {
            Street = street;
            City = city;
            Country = country;
        }

        public override bool Equals(object obj)
        {
            if (obj is not Address other)
                return false;

            return Street == other.Street &&
                   City == other.City &&
                   Country == other.Country;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Street, City, Country);
        }
    }

    public class ExampleClass
    {
        public Guid Id { get; }

        public ExampleClass(Guid id)
        {
            Id = id;
        }
    }

    public class Program
    {
        public static void Main()
        {
            Guid oneTimeCreatedGuid = Guid.NewGuid();

            ExampleClass example1 = new(oneTimeCreatedGuid);
            ExampleClass example2 = new(oneTimeCreatedGuid);

            Console.WriteLine(example1.Id == example2.Id);
            Console.WriteLine(example1.Equals(example2));
            Console.WriteLine(example1 == example2);

            Address address1 = new Address("Gül Sk", "İstanbul", "Türkiye");
            Address address2 = new Address("Gül Sk", "İstanbul", "Türkiye");
            Console.WriteLine("Address bilgiler");
            Console.WriteLine(address1.Equals(address2)); // True – içerik aynı
        }
    }
}

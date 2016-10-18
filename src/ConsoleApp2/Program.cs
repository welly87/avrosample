using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Hadoop.Avro;

namespace ConsoleApp2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serializer = new DynamicAvroSerializer();

            var bytes = serializer.Ser(new Person
            {
                Age = 1,
                FirstName = "Joe",
                LastName = "satriani"
            });

            var person = (Person)serializer.Deser<Person>(bytes);

            Console.WriteLine(person.FirstName);
            Console.WriteLine(person.LastName);
            Console.WriteLine(person.Age);

            var bytes2 = serializer.Ser(new Account
            {
                Person = new Person { Age = 1, FirstName = "Joe", LastName = "satriani" },
                Balance = 9000.0
            });

            var account = (Account)serializer.Deser<Account>(bytes2);

            Console.WriteLine(account.Person.FirstName);
            Console.WriteLine(account.Balance);
        }
    }
}

using Flunt.Validations;
using FormApp.Domain.ValueObjects.common;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApp.Domain.ValueObjects;
public class Name : ValueObject
{
    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;

        AddNotifications(new Contract<Name>()
                .Requires()
                .IsGreaterThan(firstName, 3, "Primeiro Nome", "O primeiro nome deve ter pelo menos 3 caractéres.")
                .IsGreaterThan(lastName, 3, "Sobrenome", "O sobrenome deve ter pelo menos 3 caractéres"));
    }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
}

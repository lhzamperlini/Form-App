using FormApp.Domain.Models.common;
using FormApp.Domain.ValueObjects;

namespace FormApp.Domain.Models;
public class User : EntityBase
{
    public User(Name name)
    {
        Name = name;
    }

    public Name Name { get; private set; }
}

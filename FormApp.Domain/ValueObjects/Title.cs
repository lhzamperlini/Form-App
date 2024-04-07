using Flunt.Validations;
using FormApp.Domain.ValueObjects.common;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApp.Domain.ValueObjects;
public class Title : ValueObject
{
    public Title(string text)
    {
        Text = text;
        AddNotifications(new Contract<Title>()
                .Requires()
                .IsGreaterThan(text, 5, "Titulo", "O primeiro nome deve ter pelo menos 5 caractéres."));
    }

    public string Text { get; private set; }

}

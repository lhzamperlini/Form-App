using Flunt.Validations;
using FormApp.Domain.Models.common;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApp.Domain.Models;
public class Option : EntityBase
{
    public Option(string optionText, bool correctOption, Question question)
    {
        Question = question;
        OptionText = optionText;
        QuestionId = question.Id;

        AddNotifications(new Contract<Option>()
                    .Requires()
                    .IsFalse(string.IsNullOrEmpty(optionText), "Texto da Opção", "O texto da opção não pode estar nulo")
                    .IsFalse(question.Options?.Any(x => x.OptionText.Equals(optionText)) ?? false, "Texto da opção", "Uma opção com esse texto já existe na questão"));
    }

    public Guid QuestionId { get; private set; }
    public string OptionText { get; private set; }
    public bool CorrectOption { get; private set; }
    public virtual Question Question { get; private set; }
}

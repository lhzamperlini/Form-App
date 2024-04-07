using Flunt.Validations;
using FormApp.Domain.Enums;
using FormApp.Domain.Models.common;
using FormApp.Domain.ValueObjects;
using System.Diagnostics.Contracts;

namespace FormApp.Domain.Models;
public class Question : EntityBase
{
    private readonly ICollection<Option> _options;

    public Question(Title title, Guid formId, EQuestionType questionType)
    {
        Title = title;
        FormId = formId;
        QuestionType = questionType;

        _options = new List<Option>();

    }

    public void AddOption(Option option)
    {
        var optionAlreadyAdded = _options.Any(x => x.Id.Equals(option.Id) || x.OptionText.Equals(option.OptionText));

        if(!optionAlreadyAdded) 
            _options.Add(option);

        AddNotifications(new Contract<Question>()
                .Requires()
                .IsTrue(option.IsValid, "Option", "A opção inserida possuí erros.")
                .IsFalse(optionAlreadyAdded, "Option", "Essa opção já foi inserida na questão."));
    }

    public Guid FormId { get; private set; }
    public Title Title { get; private set; }
    public EQuestionType QuestionType { get; private set; }

    public virtual ICollection<Option>? Options { get { return _options.ToArray(); } }
}

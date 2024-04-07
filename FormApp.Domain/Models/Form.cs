using Flunt.Validations;
using FormApp.Domain.Models.common;
using FormApp.Domain.ValueObjects;

namespace FormApp.Domain.Models;
public class Form : EntityBase
{
    private ICollection<Question> _questions;
    public Form(Title title, string description)
    {
        Title = title;
        Description = description;
        _questions = new List<Question>();
    }

    public void AddQuestion(Question question)
    {
        var questionAlreadyAdded = _questions.Any(x => x.Title.Text.Equals(question.Title.Text) || x.Id.Equals(question.Id));

        if(!questionAlreadyAdded)
            _questions.Add(question);


        AddNotifications(new Contract<Question>()
                .Requires()
                .IsTrue(question.IsValid, "Question", "A questão inserida possuí erros.")
                .IsFalse(questionAlreadyAdded, "Question", "Essa questão já foi inserida no formulário."));
    }

    public Title Title { get; private set; }
    public string Description { get; private set; }

    public virtual ICollection<FormResponse>? SubmittedForms { get; }
    public virtual ICollection<Question> Questions { get { return _questions.ToArray();} }
}

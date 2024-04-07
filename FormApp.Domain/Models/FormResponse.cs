using FormApp.Domain.Models.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApp.Domain.Models;
public class FormResponse : EntityBase
{
    public FormResponse(Guid formId, Guid userId, User user, Form form, ICollection<QuestionResponse> responses)
    {
        FormId = formId;
        UserId = userId;
        SubmittedAt = DateTime.Now;
        User = user;
        Form = form;
        Responses = responses;
    }

    public Guid FormId { get; set; }
    public Guid UserId { get; set; }
    public DateTime SubmittedAt { get; set; }
    public virtual User User { get; set; }
    public virtual Form Form { get; set; }
    public virtual ICollection<QuestionResponse> Responses { get; set; }
}

using FormApp.Domain.Models.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApp.Domain.Models;
public class QuestionResponse : EntityBase
{
    public QuestionResponse(Question question, FormResponse formResponse)
    {
        
    }

    public Guid? OptionId { get; set; }
    public Guid QuestionId { get; set; }
    public Guid FormResponseId { get; set; }
    public string? AnswerText { get; set; }

    public virtual Option Option { get; set; }
    public virtual Question Question { get; set; }
    public virtual FormResponse FormResponse { get; set; }
}

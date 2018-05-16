using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milionaire.DAL.Entity
{
    public class Question
    {
      public int Id { get; set; }
      public string  QuestContent { get; set; }
      public string AnswerA { get; set; }
      public string AnswerB { get; set; }
      public string AnswerC { get; set; }
      public string AnswerD { get; set; }
      public string Correct { get; set; }


    }
}

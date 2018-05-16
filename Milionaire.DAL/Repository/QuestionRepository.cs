using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Milionaire.DAL.Entity;

namespace Milionaire.DAL.Repository
{
    public class QuestionRepository
    {
        public static List<Question> ListConvert()
        {
            List<Question> questions = new List<Question>();
            using (var context = new MilionsContext())
            {
                questions = context.Questions.ToList();
            }
            return questions;
        }

        public static void AddQuestion(string qContent, string answA, string answB, string answC, string answD, char correct)
        {
            var question = new Question
            {
                QuestContent = qContent,
                AnswerA = answA,
                AnswerB = answB,
                AnswerC = answC,
                AnswerD = answD,
                Correct = correct.ToString()
            };
            using (var context = new MilionsContext())
            {
                context.Questions.Add(question);
                context.SaveChanges();
            }

        }
    }
}

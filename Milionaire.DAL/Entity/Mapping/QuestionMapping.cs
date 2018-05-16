using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milionaire.DAL.Entity.Mapping
{
    class QuestionMapping : EntityTypeConfiguration<Question>
    {
        public QuestionMapping()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Table & Column Mappings
            this.ToTable("Questions");
            this.Property(t => t.QuestContent).HasColumnName("QuestContent");
            this.Property(t => t.AnswerA).HasColumnName("AnswerA");
            this.Property(t => t.AnswerB).HasColumnName("AnswerB");
            this.Property(t => t.AnswerC).HasColumnName("AnswerC");
            this.Property(t => t.AnswerD).HasColumnName("AnswerD");
            this.Property(t => t.Correct).HasColumnName("Correct");
        }
    }
}

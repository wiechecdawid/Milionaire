using Milionaire.DAL.Entity.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milionaire.DAL.Entity
{
    public class MilionsContext : DbContext
    {
        static MilionsContext()
        {
            Database.SetInitializer<MilionsContext>(null);
        }

        public MilionsContext()
           : base("name=MilionsContext")
        {
        }

        public DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new QuestionMapping());
        }

    }
}


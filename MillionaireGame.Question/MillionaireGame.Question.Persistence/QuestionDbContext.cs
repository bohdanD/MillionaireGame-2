using Microsoft.EntityFrameworkCore;
using MillionaireGame.Question.Domain;

namespace MillionaireGame.Question.Persistence
{
    public class QuestionDbContext : DbContext
    {
        public DbSet<Domain.Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Complexity> Complexities { get; set; }

    }
}

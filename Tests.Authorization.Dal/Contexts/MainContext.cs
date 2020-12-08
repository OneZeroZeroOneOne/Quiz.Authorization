using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Tests.Authorization.Dal.Models;

#nullable disable

namespace Tests.Authorization.Dal.Contexts
{
    public partial class MainContext : DbContext
    {
        private string _connString;
        public MainContext(string connString)
        {
            _connString = connString;
        }

        public MainContext(DbContextOptions<MainContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<AnswerTamplate> AnswerTamplate { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<JwtOption> JwtOption { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<QuestionTemplate> QuestionTemplate { get; set; }
        public virtual DbSet<QuestionType> QuestionType { get; set; }
        public virtual DbSet<Quiz> Quiz { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserAnswer> UserAnswer { get; set; }
        public virtual DbSet<UserEmployee> UserEmployee { get; set; }
        public virtual DbSet<UserQuiz> UserQuiz { get; set; }
        public virtual DbSet<UserSecurity> UserSecurity { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(_connString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "C.UTF-8");

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.ToTable("Answer");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("Answer_QuestionId_fkey");
            });

            modelBuilder.Entity<AnswerTamplate>(entity =>
            {
                entity.ToTable("AnswerTamplate");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.QuestionTamplate)
                    .WithMany(p => p.AnswerTamplates)
                    .HasForeignKey(d => d.QuestionTamplateId)
                    .HasConstraintName("AnswerTamplate_QuestionTamplateId_fkey");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");
            });

            modelBuilder.Entity<JwtOption>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Question");

                entity.HasOne(d => d.QuestionType)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.QuestionTypeId)
                    .HasConstraintName("Question_QuestionTypeId_fkey");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.QuizId)
                    .HasConstraintName("Question_QuizId_fkey");
            });

            modelBuilder.Entity<QuestionTemplate>(entity =>
            {
                entity.ToTable("QuestionTemplate");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.QuestionType)
                    .WithMany(p => p.QuestionTemplates)
                    .HasForeignKey(d => d.QuestionTypeId)
                    .HasConstraintName("QuestionTemplate_QuestionTypeId_fkey");
            });

            modelBuilder.Entity<QuestionType>(entity =>
            {
                entity.ToTable("QuestionType");
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.ToTable("Quiz");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Quizzes)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("Quiz_StatusId_fkey");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("User_RoleId_fkey");
            });

            modelBuilder.Entity<UserAnswer>(entity =>
            {
                entity.ToTable("UserAnswer");

                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.UserAnswers)
                    .HasForeignKey(d => d.AnswerId)
                    .HasConstraintName("UserAnswer_AnswerId_fkey");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.UserAnswers)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("UserAnswer_EmployeeId_fkey");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.UserAnswers)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("UserAnswer_QuestionId_fkey");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.UserAnswers)
                    .HasForeignKey(d => d.QuizId)
                    .HasConstraintName("UserAnswer_QuizId_fkey");
            });

            modelBuilder.Entity<UserEmployee>(entity =>
            {
                entity.ToTable("UserEmployee");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.UserEmployees)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("UserEmployee_EmployeeId_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserEmployees)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("UserEmployee_UserId_fkey");
            });

            modelBuilder.Entity<UserQuiz>(entity =>
            {
                entity.ToTable("UserQuiz");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.UserQuizzes)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("UserQuiz_EmployeeId_fkey");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.UserQuizzes)
                    .HasForeignKey(d => d.QuizId)
                    .HasConstraintName("UserQuiz_QuizId_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserQuizzes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("UserQuiz_UserId_fkey");
            });

            modelBuilder.Entity<UserSecurity>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("UserSecurity_pkey");

                entity.ToTable("UserSecurity");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserSecurity)
                    .HasForeignKey<UserSecurity>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserSecurity_UserId_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

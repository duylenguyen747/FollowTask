using FollowTask.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FollowTask.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Relationship Of Tasks
            modelBuilder.Entity<Tasks>()
                .HasOne(x => x.Status)
                .WithMany(x => x.Tasks)
                .HasForeignKey(x => x.StatusId)
                .HasConstraintName("FK_Tasks_Status"); 
            modelBuilder.Entity<Tasks>()
                .HasMany(c => c.Comment)
                .WithOne(t => t.Task)
                .HasForeignKey(c => c.TaskId)
                .HasConstraintName("FK_Comment_Task");
            modelBuilder.Entity<Tasks>()
                .HasMany(c => c.TaskData)
                .WithOne(t => t.Task)
                .HasForeignKey(c => c.TaskId)
                .HasConstraintName("FK_TaskData_Task");
            modelBuilder.Entity<Tasks>()
                .HasMany(c => c.TaskChangedLog)
                .WithOne(t => t.Task)
                .HasForeignKey(c => c.TaskId)
                .HasConstraintName("FK_TaskChangedLog_Task");

            // RelationShip of Comment
            modelBuilder.Entity<Comment>()
                .HasMany(td => td.TaskData)
                .WithOne(c => c.Comment)
                .HasForeignKey(c => c.CommentId)
                .HasConstraintName("FK_TaskData_Comment");

            // Relatinship Of Status
            modelBuilder.Entity<Status>()
                .HasMany(ot => ot.OldStatus)
                .WithOne(s => s.OldStatus)
                .HasForeignKey(o => o.OldStatusId)
                .HasConstraintName("FK_OldStatus_Status");
            modelBuilder.Entity<Status>()
                .HasMany(ot => ot.NewStatus)
                .WithOne(s => s.NewStatus)
                .HasForeignKey(o => o.NewStatusId)
                .HasConstraintName("FK_NewStatus_Status");


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<TaskChangedLog> TasksChangedLogs { get; set;}
        public DbSet<TaskData> TaskDatas { get; set; }


    }
}

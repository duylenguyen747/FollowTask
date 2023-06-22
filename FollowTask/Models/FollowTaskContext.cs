using Microsoft.EntityFrameworkCore;

namespace FollowTask.Models;

public partial class FollowTaskContext : DbContext
{
    public FollowTaskContext()
    {
    }

    public FollowTaskContext(DbContextOptions<FollowTaskContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Tasks> Tasks { get; set; }

    public virtual DbSet<TaskChangedLog> TaskChangedLogs { get; set; }

    public virtual DbSet<TaskData> TaskDatas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=FollowTask;Trusted_Connection=True;Integrated Security=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.Property(e => e.CommentBy).HasMaxLength(225);
            entity.Property(e => e.CommentTime).HasColumnType("datetime");

            entity.HasOne(d => d.Task).WithMany(p => p.Comments)
                .HasForeignKey(d => d.TaskId)
                .HasConstraintName("FK_Comments_Tasks");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("Status");

            entity.Property(e => e.Name).HasMaxLength(225);
        });

        modelBuilder.Entity<Tasks>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Task");

            entity.Property(e => e.AssignTo).HasMaxLength(50);
            entity.Property(e => e.CreateBy).HasMaxLength(50);
            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(225);

            entity.HasOne(d => d.Status).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tasks_Status");
        });

        modelBuilder.Entity<TaskChangedLog>(entity =>
        {
            entity.ToTable("TaskChangedLog");

            entity.Property(e => e.ChangedBy).HasMaxLength(50);
            entity.Property(e => e.ChangedTime).HasColumnType("datetime");

            entity.HasOne(d => d.Task).WithMany(p => p.TaskChangedLogs)
                .HasForeignKey(d => d.TaskId)
                .HasConstraintName("FK_TaskChangedLog_Tasks");
        });

        modelBuilder.Entity<TaskData>(entity =>
        {
            entity.Property(e => e.Data).HasMaxLength(50);
            entity.Property(e => e.FileName).HasMaxLength(50);

            entity.HasOne(d => d.Comment).WithMany(p => p.TaskData)
                .HasForeignKey(d => d.CommentId)
                .HasConstraintName("FK_TaskDatas_Comments");

            entity.HasOne(d => d.Taks).WithMany(p => p.TaskData)
                .HasForeignKey(d => d.TaksId)
                .HasConstraintName("FK_TaskDatas_Tasks");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

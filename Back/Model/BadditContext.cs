using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Back.Model;

public partial class BadditContext : DbContext
{
    public BadditContext()
    {
    }

    public BadditContext(DbContextOptions<BadditContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Forum> Forums { get; set; }

    public virtual DbSet<ImageDatum> ImageData { get; set; }

    public virtual DbSet<LocationPhoto> LocationPhotos { get; set; }

    public virtual DbSet<ParticipantForum> ParticipantForums { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolePermission> RolePermissions { get; set; }

    public virtual DbSet<UpvoteDownvote> UpvoteDownvotes { get; set; }

    public virtual DbSet<UserBaddit> UserBaddits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Baddit;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comment__3214EC277D2B8C02");

            entity.ToTable("Comment");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CommentText).IsUnicode(false);

            entity.HasOne(d => d.ParticipantNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.Participant)
                .HasConstraintName("FK__Comment__Partici__3C69FB99");

            entity.HasOne(d => d.PostCommentNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostComment)
                .HasConstraintName("FK__Comment__PostCom__3D5E1FD2");
        });

        modelBuilder.Entity<Forum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Forum__3214EC277CDD8188");

            entity.ToTable("Forum");

            entity.HasIndex(e => e.ForumName, "UQ__Forum__F372648A7D1A216D").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Creator)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DescriptionForum)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ForumName)
                .HasMaxLength(55)
                .IsUnicode(false);

            entity.HasOne(d => d.CreatorNavigation).WithMany(p => p.Forums)
                .HasPrincipalKey(p => p.Email)
                .HasForeignKey(d => d.Creator)
                .HasConstraintName("FK__Forum__Creator__29572725");
        });

        modelBuilder.Entity<ImageDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ImageDat__3214EC277923D883");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<LocationPhoto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Location__3214EC279DB241FB");

            entity.ToTable("LocationPhoto");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nome)
                .HasMaxLength(60)
                .IsUnicode(false);

            entity.HasOne(d => d.ParticipantNavigation).WithMany(p => p.LocationPhotos)
                .HasForeignKey(d => d.Participant)
                .HasConstraintName("FK__LocationP__Parti__46E78A0C");

            entity.HasOne(d => d.PhotoNavigation).WithMany(p => p.LocationPhotos)
                .HasForeignKey(d => d.Photo)
                .HasConstraintName("FK__LocationP__Photo__45F365D3");
        });

        modelBuilder.Entity<ParticipantForum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Particip__3214EC279D3DA500");

            entity.ToTable("ParticipantForum");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ParticipantForum1).HasColumnName("ParticipantForum");

            entity.HasOne(d => d.ForumNavigation).WithMany(p => p.ParticipantForums)
                .HasForeignKey(d => d.Forum)
                .HasConstraintName("FK__Participa__Forum__34C8D9D1");

            entity.HasOne(d => d.ParticipantForum1Navigation).WithMany(p => p.ParticipantForums)
                .HasForeignKey(d => d.ParticipantForum1)
                .HasConstraintName("FK__Participa__Parti__35BCFE0A");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Permissi__3214EC27BDD37E14");

            entity.ToTable("Permission");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PermissionName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Post__3214EC27CF9C7D4F");

            entity.ToTable("Post");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PostDate).HasColumnType("date");
            entity.Property(e => e.PostText).IsUnicode(false);
            entity.Property(e => e.Tittle)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.ForumNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.Forum)
                .HasConstraintName("FK__Post__Forum__38996AB5");

            entity.HasOne(d => d.ParticipantNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.Participant)
                .HasConstraintName("FK__Post__Participan__398D8EEE");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC27D2DACCAD");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.RoleName)
                .HasMaxLength(55)
                .IsUnicode(false);

            entity.HasOne(d => d.ForumNavigation).WithMany(p => p.Roles)
                .HasForeignKey(d => d.Forum)
                .HasConstraintName("FK__Roles__Forum__2C3393D0");
        });

        modelBuilder.Entity<RolePermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RolePerm__3214EC27CAAA1533");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.Permission).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.PermissionId)
                .HasConstraintName("FK__RolePermi__Permi__31EC6D26");

            entity.HasOne(d => d.Role).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__RolePermi__RoleI__30F848ED");
        });

        modelBuilder.Entity<UpvoteDownvote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UpvoteDo__3214EC271A83F89A");

            entity.ToTable("UpvoteDownvote");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.ParticipantNavigation).WithMany(p => p.UpvoteDownvotes)
                .HasForeignKey(d => d.Participant)
                .HasConstraintName("FK__UpvoteDow__Parti__403A8C7D");

            entity.HasOne(d => d.PostNavigation).WithMany(p => p.UpvoteDownvotes)
                .HasForeignKey(d => d.Post)
                .HasConstraintName("FK__UpvoteDown__Post__412EB0B6");
        });

        modelBuilder.Entity<UserBaddit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User_Bad__3214EC272CB8B2AF");

            entity.ToTable("User_Baddit");

            entity.HasIndex(e => e.NickUser, "UQ__User_Bad__7B84F30D21423166").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__User_Bad__A9D105341DE584BB").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DateBirth).HasColumnType("date");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.NickUser)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.SaldPassword).IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(55)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

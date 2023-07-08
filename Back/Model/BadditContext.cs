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

    public virtual DbSet<ListParticipantsForum> ListParticipantsForums { get; set; }

    public virtual DbSet<LocationPhoto> LocationPhotos { get; set; }

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
            entity.HasKey(e => e.Id).HasName("PK__Comment__3214EC07B1751572");

            entity.ToTable("Comment");

            entity.Property(e => e.CommentText).IsUnicode(false);

            entity.HasOne(d => d.ParticipantNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.Participant)
                .HasConstraintName("FK__Comment__Partici__3D5E1FD2");

            entity.HasOne(d => d.PostCommentNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostComment)
                .HasConstraintName("FK__Comment__PostCom__3E52440B");
        });

        modelBuilder.Entity<Forum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Forum__3214EC07BE939571");

            entity.ToTable("Forum");

            entity.HasIndex(e => e.ForumName, "UQ__Forum__F372648AF2300192").IsUnique();

            entity.Property(e => e.DescriptionForum)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ForumName)
                .HasMaxLength(55)
                .IsUnicode(false);

            entity.HasOne(d => d.CreatorNavigation).WithMany(p => p.Forums)
                .HasForeignKey(d => d.Creator)
                .HasConstraintName("FK__Forum__Creator__29572725");
        });

        modelBuilder.Entity<ImageDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ImageDat__3214EC27F1FD6E5E");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<ListParticipantsForum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ListPart__3214EC071AB49C5C");

            entity.ToTable("ListParticipantsForum");

            entity.HasOne(d => d.ForumNavigation).WithMany(p => p.ListParticipantsForums)
                .HasForeignKey(d => d.Forum)
                .HasConstraintName("FK__ListParti__Forum__35BCFE0A");

            entity.HasOne(d => d.ParticipantNavigation).WithMany(p => p.ListParticipantsForums)
                .HasForeignKey(d => d.Participant)
                .HasConstraintName("FK__ListParti__Parti__36B12243");
        });

        modelBuilder.Entity<LocationPhoto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Location__3214EC2722C243D3");

            entity.ToTable("LocationPhoto");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nome)
                .HasMaxLength(60)
                .IsUnicode(false);

            entity.HasOne(d => d.ParticipantNavigation).WithMany(p => p.LocationPhotos)
                .HasForeignKey(d => d.Participant)
                .HasConstraintName("FK__LocationP__Parti__47DBAE45");

            entity.HasOne(d => d.PhotoNavigation).WithMany(p => p.LocationPhotos)
                .HasForeignKey(d => d.Photo)
                .HasConstraintName("FK__LocationP__Photo__46E78A0C");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Permissi__3214EC279B2CD80E");

            entity.ToTable("Permission");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PermissionName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Post__3214EC277B161005");

            entity.ToTable("Post");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PostDate).HasColumnType("date");
            entity.Property(e => e.PostText).IsUnicode(false);
            entity.Property(e => e.Tittle)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.ForumNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.Forum)
                .HasConstraintName("FK__Post__Forum__398D8EEE");

            entity.HasOne(d => d.ParticipantNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.Participant)
                .HasConstraintName("FK__Post__Participan__3A81B327");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC274E844947");

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
            entity.HasKey(e => e.Id).HasName("PK__RolePerm__3214EC277EF029CF");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.Permission).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.PermissionId)
                .HasConstraintName("FK__RolePermi__Permi__32E0915F");

            entity.HasOne(d => d.Role).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__RolePermi__RoleI__31EC6D26");
        });

        modelBuilder.Entity<UpvoteDownvote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UpvoteDo__3214EC27A06E37F3");

            entity.ToTable("UpvoteDownvote");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.ParticipantNavigation).WithMany(p => p.UpvoteDownvotes)
                .HasForeignKey(d => d.Participant)
                .HasConstraintName("FK__UpvoteDow__Parti__412EB0B6");

            entity.HasOne(d => d.PostNavigation).WithMany(p => p.UpvoteDownvotes)
                .HasForeignKey(d => d.Post)
                .HasConstraintName("FK__UpvoteDown__Post__4222D4EF");
        });

        modelBuilder.Entity<UserBaddit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User_Bad__3214EC07F0AA70A9");

            entity.ToTable("User_Baddit");

            entity.HasIndex(e => e.NickUser, "UQ__User_Bad__7B84F30D184F3993").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__User_Bad__A9D105343588A481").IsUnique();

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
            entity.Property(e => e.PasswordUser).IsUnicode(false);
            entity.Property(e => e.SaltPassword).IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(55)
                .IsUnicode(false);

            entity.HasOne(d => d.UserPhotoNavigation).WithMany(p => p.UserBaddits)
                .HasForeignKey(d => d.UserPhoto)
                .HasConstraintName("FK__User_Badd__UserP__48CFD27E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

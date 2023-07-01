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
            entity.HasKey(e => e.Id).HasName("PK__Comment__3214EC27686EBC56");

            entity.ToTable("Comment");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CommentText).IsUnicode(false);

            entity.HasOne(d => d.ParticipantNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.Participant)
                .HasConstraintName("FK__Comment__Partici__412EB0B6");

            entity.HasOne(d => d.PostCommentNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostComment)
                .HasConstraintName("FK__Comment__PostCom__4222D4EF");
        });

        modelBuilder.Entity<Forum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Forum__3214EC27939A7C8E");

            entity.ToTable("Forum");

            entity.HasIndex(e => e.ForumName, "UQ__Forum__F372648A0E4DC88B").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DescriptionForum)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.ForumName)
                .HasMaxLength(55)
                .IsUnicode(false);

            entity.HasOne(d => d.CreatorNavigation).WithMany(p => p.Forums)
                .HasForeignKey(d => d.Creator)
                .HasConstraintName("FK__Forum__Creator__2E1BDC42");
        });

        modelBuilder.Entity<ImageDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ImageDat__3214EC2768BC21D4");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<LocationPhoto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Location__3214EC27D2BC67FC");

            entity.ToTable("LocationPhoto");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nome)
                .HasMaxLength(60)
                .IsUnicode(false);

            entity.HasOne(d => d.ParticipantNavigation).WithMany(p => p.LocationPhotos)
                .HasForeignKey(d => d.Participant)
                .HasConstraintName("FK__LocationP__Parti__4BAC3F29");

            entity.HasOne(d => d.PhotoNavigation).WithMany(p => p.LocationPhotos)
                .HasForeignKey(d => d.Photo)
                .HasConstraintName("FK__LocationP__Photo__4AB81AF0");
        });

        modelBuilder.Entity<ParticipantForum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Particip__3214EC2732DCABC9");

            entity.ToTable("ParticipantForum");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ParticipantForum1).HasColumnName("ParticipantForum");

            entity.HasOne(d => d.ForumNavigation).WithMany(p => p.ParticipantForums)
                .HasForeignKey(d => d.Forum)
                .HasConstraintName("FK__Participa__Forum__398D8EEE");

            entity.HasOne(d => d.ParticipantForum1Navigation).WithMany(p => p.ParticipantForums)
                .HasForeignKey(d => d.ParticipantForum1)
                .HasConstraintName("FK__Participa__Parti__3A81B327");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Permissi__3214EC2796666CC4");

            entity.ToTable("Permission");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PermissionName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Post__3214EC278DD93DB9");

            entity.ToTable("Post");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PostDate).HasColumnType("date");
            entity.Property(e => e.PostText).IsUnicode(false);
            entity.Property(e => e.Tittle)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.ForumNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.Forum)
                .HasConstraintName("FK__Post__Forum__3D5E1FD2");

            entity.HasOne(d => d.ParticipantNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.Participant)
                .HasConstraintName("FK__Post__Participan__3E52440B");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC270E5FAA2A");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.RoleName)
                .HasMaxLength(55)
                .IsUnicode(false);

            entity.HasOne(d => d.ForumNavigation).WithMany(p => p.Roles)
                .HasForeignKey(d => d.Forum)
                .HasConstraintName("FK__Roles__Forum__30F848ED");
        });

        modelBuilder.Entity<RolePermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RolePerm__3214EC270D0E139B");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.Permission).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.PermissionId)
                .HasConstraintName("FK__RolePermi__Permi__36B12243");

            entity.HasOne(d => d.Role).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__RolePermi__RoleI__35BCFE0A");
        });

        modelBuilder.Entity<UpvoteDownvote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UpvoteDo__3214EC279F881A07");

            entity.ToTable("UpvoteDownvote");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.ParticipantNavigation).WithMany(p => p.UpvoteDownvotes)
                .HasForeignKey(d => d.Participant)
                .HasConstraintName("FK__UpvoteDow__Parti__44FF419A");

            entity.HasOne(d => d.PostNavigation).WithMany(p => p.UpvoteDownvotes)
                .HasForeignKey(d => d.Post)
                .HasConstraintName("FK__UpvoteDown__Post__45F365D3");
        });

        modelBuilder.Entity<UserBaddit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User_Bad__3214EC27BE76AFB9");

            entity.ToTable("User_Baddit");

            entity.HasIndex(e => e.NickUser, "UQ__User_Bad__7B84F30DC36588EB").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__User_Bad__A9D10534D4CCA8B4").IsUnique();

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
            entity.Property(e => e.PasswordUser).IsUnicode(false);
            entity.Property(e => e.SaltPassword).IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.Userphoto).HasColumnName("USERPHOTO");

            entity.HasOne(d => d.UserphotoNavigation).WithMany(p => p.UserBaddits)
                .HasForeignKey(d => d.Userphoto)
                .HasConstraintName("FK__User_Badd__USERP__4CA06362");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

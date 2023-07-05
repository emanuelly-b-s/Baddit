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

    public virtual DbSet<Role> Roles {  get; set; }

    public virtual DbSet<RolePermission> RolePermissions { get; set; }

    public virtual DbSet<UpvoteDownvote> UpvoteDownvotes { get; set; }

    public virtual DbSet<UserBaddit> UserBaddits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CT-C-0013M\\SQLEXPRESS;Initial Catalog=Baddit;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comment__3214EC076A2EE054");

            entity.ToTable("Comment");

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
            entity.HasKey(e => e.Id).HasName("PK__Forum__3214EC07994D9235");

            entity.ToTable("Forum");

            entity.HasIndex(e => e.ForumName, "UQ__Forum__F372648A4F4AF441").IsUnique();

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
            entity.HasKey(e => e.Id).HasName("PK__ImageDat__3214EC27A65F8F9B");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<ListParticipantsForum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ListPart__3214EC074B58D127");

            entity.ToTable("ListParticipantsForum");

            entity.HasOne(d => d.ForumNavigation).WithMany(p => p.ListParticipantsForums)
                .HasForeignKey(d => d.Forum)
                .HasConstraintName("FK__ListParti__Forum__34C8D9D1");

            entity.HasOne(d => d.ParticipantNavigation).WithMany(p => p.ListParticipantsForums)
                .HasForeignKey(d => d.Participant)
                .HasConstraintName("FK__ListParti__Parti__35BCFE0A");
        });

        modelBuilder.Entity<LocationPhoto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Location__3214EC27AB6B3B4D");

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

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Permissi__3214EC274C973803");

            entity.ToTable("Permission");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PermissionName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Post__3214EC274E29E339");

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
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC27D0D88E16");

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
            entity.HasKey(e => e.Id).HasName("PK__RolePerm__3214EC2723E27765");

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
            entity.HasKey(e => e.Id).HasName("PK__UpvoteDo__3214EC27F76D8C56");

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
            entity.HasKey(e => e.Id).HasName("PK__User_Bad__3214EC0761454C2D");

            entity.ToTable("User_Baddit");

            entity.HasIndex(e => e.NickUser, "UQ__User_Bad__7B84F30DCD58ABBF").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__User_Bad__A9D10534867E7C48").IsUnique();

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
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
